using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �̵� ó�� ������Ʈ
public class RandomMovement : MonoBehaviour
{
    // �ٴ� ���ӿ�����Ʈ Transform ������Ʈ
    [SerializeField] protected float moveSpeed; // �̵� �ӵ�
    [SerializeField] private float rotateSpeed; // ȸ�� �ӵ�
    private float waitTime; // ���ð�
    [SerializeField] private float minWaitTime; // �ּ� ���ð�
    [SerializeField] private float maxWaitTime; // �ִ� ���ð�
    [SerializeField] protected float randomRange; // ���� ��ġ ����(x,y)

    protected Vector3 targetPosition; // �̵��� ��ġ
    protected bool isMove = false; // �̵� ����
    protected float time; // �ð� ���� ����
    protected float originSpeed; // �̵��ӵ� ������ ���� ����

    protected Animator animator; // �ִϸ����� ������Ʈ

    // �̵��� ���� ��ġ �̱�
    private void SetRandomTargetPosition()
    {
        // ���� Ÿ�� ��ġ ���� ����
        Vector3 randomPosition = new Vector3(Random.Range(-randomRange, randomRange), 0 , Random.Range(-randomRange, randomRange));
        
        // ���� ��ġ�� �̵��� ��ġ�� ����
        targetPosition = randomPosition;

        // ���ð��� �����ϰ� ��÷��
        waitTime = Random.Range(minWaitTime, maxWaitTime);

        isMove = true; // �̵� ����
        animator.SetBool("IsMove", isMove); // �̵��� ���� �ִϸ��̼� ó��
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SetRandomTargetPosition();
        originSpeed = moveSpeed; // �̵� �ӵ� ����
    }

    // Update is called once per frame
    void Update()
    {

        if (!isMove) // �̵� ���� ���¸�
        {
            // �ð� ���(Ÿ�̸�)
            time += Time.deltaTime;
            if (time >= waitTime)
            {
                // ���� ��ġ ����
                SetRandomTargetPosition();
                time = 0; // ��� �ð� ���� ���� �ʱ�ȭ
            }
        }
        else // �̵� ���¸�
        {
            // �̵� �� ȸ��ó��
            MoveTargetPosition();
        }
    }

    // Ÿ�� ��ġ�� �̵� ó��
    private void MoveTargetPosition()
    {
        // �̵� ó��
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Quaternion ���⺤�͸� ���ϴ� ȸ�� = Quaternion.LookRotation(���� ����)
        Quaternion targetRotation = Quaternion.LookRotation((targetPosition - transform.position).normalized);

        // Quaternion.RotateTowards(���� ȸ��, ȸ���Ͽ��� ȸ��, ȸ���ӵ�)
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        
        // �̵��Ϸ��� ��ġ�� ���� �����ߴٸ�
        // float �Ÿ� = Vector.Distance(��ġ1, ��ġ2);
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMove = false; // �̵� ���� ���°� ����
            animator.SetBool("IsMove", isMove); // �̵� ������ ���� �ִϸ��̼� ó��
        }
    }

    public void Stop() // �̵� ����
    {
        moveSpeed = 0; // �̵��ӵ��� 0����
    }
    public void Resume() // �̵� �簳
    {
        moveSpeed = originSpeed; // �̵��ӵ� ����
    }
}
