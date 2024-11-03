using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NavigationMovement : MonoBehaviour
{
    // �׺�޽�������Ʈ
    private NavMeshAgent navMeshAgent;
    // �ִϸ�����
    private Animator animator;
    // �̵� ����
    private bool isMoving;
    // �ٴ� ���̾�
    [SerializeField] private LayerMask layerMask;
    // �̵� Ÿ�� ��Ŀ
    [SerializeField] private TargetPicker targetPicker;
    // ���� ����
    [SerializeField] private float jumpHeight;
    // ���� ���ӽð�
    [SerializeField] private float jumpDuration;
    // �����޽���ũ �̵� �ӵ�
    [SerializeField] private float offMeshLinkSpeed;
    // ���� �̵��ӵ�
    private float originalSpeed;
    // �������� ����
    private bool isJump;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // ������Ʈ �̵��ӵ� ���
        originalSpeed = navMeshAgent.speed; 
        
    }

    IEnumerator Jump()
    {
        isJump = true; // ���� ���� ���� ����

        // * OffMeshLinkData : ����������ũ ����
        // - startPos : OffMeshLink ���� ��ġ
        // - endPos : OffMeshLink ���� ��ġ
        // - linkType : ���������, �ܹ������� ����
        // - area : �׺���̼� Area
        // - activated : OffMeshLink Ȱ������ ����
        OffMeshLinkData data = navMeshAgent.currentOffMeshLinkData;

        // ���� ���� ��ġ�� ���� ������Ʈ ��ġ�� ����
        Vector3 startPos = navMeshAgent.transform.position;

        // ���� ���� ��ġ�� ����
        Vector3 endPos = data.endPos + Vector3.up * navMeshAgent.baseOffset;

        // ���� ��� �ð� (����)
        float elapsedTime = 0f;

        // ������ ���ӵǴ� ���� ���� ǥ�� ó��
        while (elapsedTime < jumpDuration)
        {
            // ��� �ð��� ���� ������ ����� ���
            float t = elapsedTime / jumpDuration;

            // �ð��� ���� ������ ���̸� ���� (���� �ĵ� ó��)
            float height = Mathf.Sin(Mathf.PI * t) * jumpHeight;

            animator.SetFloat("Vertical", height);
            
            // ���� �߿� ������Ʈ�� ���� ��ġ�� ���� �̵� ó����(�ε巴�� ������ �̵��� ǥ��)
            navMeshAgent.transform.position = Vector3.Lerp(startPos, endPos, t) + Vector3.up * height;

            // ����ð� ������Ʈ 
            elapsedTime += Time.deltaTime;

            // Update ���� �ֱ�ȭ ������
            yield return null;

        }
        // �����޽���ũ �̵��� �Ϸ���
        navMeshAgent.CompleteOffMeshLink();

        // ���� �Ϸ� ���·� ����
        isJump = false;

    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���콺 ��ư�� Ŭ����
        if (Input.GetMouseButtonDown(0))
        {
            // ȭ�� ��ġ ���̸� ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ȭ�� ��ġ �浿 ����
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                // ���콺�� Ŭ���� ��ġ�� ������Ʈ�� �̵���Ŵ
                // * navMeshAgent.SetDestination(�̵� ��ġ); : ������ �̵� ��ġ�� ������Ʈ�� �̵���Ŵ
                navMeshAgent.SetDestination(hit.point);
                // * navMeshAgent.isStopped : ������Ʈ�� �̵� ���� ����
                // navMeshAgent.isStopped = true;
                isMoving = true;

                // Ÿ����Ŀ ǥ��(�浹��ġ, �浹��������)
                targetPicker.Show(hit.point, hit.normal);
            }
        }

        // * navMeshAgent.pathPending : �׺���̼��� ��θ� ��� �� ����
        if (!navMeshAgent.pathPending && isMoving)
        {
            // * navMeshAgent.remainingDistance : ��ǥ �����ϱ������ ���� �Ÿ�
            // * navMeshAgent.StoppingDistance : �����ϱ� ���� ���ߴ� ���� �Ÿ�
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                // * navMeshAgent.hasPath : ��ȿ�� �̵� ��θ������� �ִ��� ����
                // * navMeshAgent.velocity.sqrMagnitude : ���� ������Ʈ�� �̵� �ӵ�
                if (navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    isMoving = false;

                    // Ÿ�� ��Ŀ ����
                    targetPicker.Hide();
                }
            }
        }
        // �̵� �ִϸ��̼� ���
        animator.SetBool("IsMoving", isMoving);

        // * navMeshAgent.isOnOffMeshLink : ���� �����޽���ũ ���� �ִ��� ����
        // ���� ĳ���Ͱ� �����޽���ũ�� ���������� ���� ������ ���ߴٸ�
        if (navMeshAgent.isOnOffMeshLink && !isJump)
        {
            // �����޽���ũ �̵��ӵ��� ������Ʈ �ӵ��� ����
            navMeshAgent.speed = offMeshLinkSpeed;
            // ���� �ִϸ��̼� ����
            animator.SetTrigger("Jump");

            // ���� ȿ�� �ڷ�ƾ ����
            StartCoroutine(Jump());
        }
        else // ���� ĳ���Ͱ� �����޽���ũ�� ����� ������ �̷���� ���¸�
        {
            // ������Ʈ�� �ӵ��� �̵��ӵ��� ������
            navMeshAgent.speed = originalSpeed;
        }
    }
}
