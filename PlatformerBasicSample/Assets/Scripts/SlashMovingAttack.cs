using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �̵� ���� ������Ʈ
public class SlashMovingAttack : MonoBehaviour
{
    // ���� �� ����
    private bool isAttack = false;
    public bool IsAttack { get => isAttack; set => isAttack = value; }

    // ���� üũ Transform
    [SerializeField] private Transform checkTransform;

    // ������ ���� ���� �Ÿ�(����ĳ��Ʈ ����)
    [SerializeField] private float detectionDistance;

    // �̵� ������Ʈ 
    [SerializeField] private Movement movement;

    // �������� �̵� �ӵ�
    private float originSpeed;

    // ������ ���� �ӵ�
    [SerializeField] private float attackSpeed;

    // ���� ��� �浹 ���̾�
    [SerializeField] private LayerMask detectLayer;

    // ������ ���� �ð�
    [SerializeField] private float movingAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        originSpeed = movement.MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    // �̵� ó��
    public void Attack()
    {
        // ���� ������ ���� ����ĳ��Ʈ üũ�� ������
        RaycastHit2D hit = Physics2D.Raycast(checkTransform.position, movement.MoveDirection, detectionDistance, detectLayer);

        // ���� ��� ������Ʈ�� �ִٸ�
        if (hit.collider != null && !isAttack)
        {
            // ������ �̵� ������ ������
            StartCoroutine(MovingAttackCoroutine());
        }
    }

    // �̵� ���� ó�� �ڷ�ƾ
    IEnumerator MovingAttackCoroutine()
    {
        // ���� ����
        isAttack = true;
        // �̵� �ӵ� ����
        movement.MoveSpeed = attackSpeed; 
        // ������ ���� �ð� ���� ���
        yield return new WaitForSeconds(movingAttackTime);
        // �̵��ӵ� ����
        movement.MoveSpeed = originSpeed;
        // ���� ����
        isAttack = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(checkTransform.position, checkTransform.position + new Vector3(movement.MoveDirection.x, 0, 0) * detectionDistance);

    }
}
