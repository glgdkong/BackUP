using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSwingCollisionMovement : DirectionMovement
{
    // ������ ���̾�
    [SerializeField] LayerMask detectLayer;
    // �𷺼� �Ÿ�
    [SerializeField] float detectionDistance;    
    // �̵� ���� ��ȯ üũ ��ġ
    [SerializeField] private Transform checkTransform;

    protected override void Move()
    {
        // * ����ĳ��Ʈ �浹 �޼ҵ�
        // - RaycastHit2D �����浹�������� = Physics2D.Raycast(���̻�����ġ, ����, ����, �浹���̾�);

        // ���� ��ȯ�� ���� �ü� �������� ����ĳ��Ʈ üũ�� ������
        RaycastHit2D hit = Physics2D.Raycast(checkTransform.position, MoveDirection, detectionDistance, detectLayer);

        // �浹 ������Ʈ�� �ִٸ�
        if (hit.collider != null)
        {
            // �̵� ���� ��ȯ
            MoveDirection = -MoveDirection;

            // ��������Ʈ ������
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        // �̵� ó��
        transform.Translate(MoveDirection * MoveSpeed * Time.deltaTime);

    }

    // �浹 ���� ǥ�� �����
    private void OnDrawGizmosSelected()
    {
        // ���� ǥ���� ����� ������ ������
        Gizmos.color = Color.red;

        // ����ĳ��Ʈ�� ���� ���������� ������ ����� ���� �׷���
        //  - Gizmos.DrawLine(�׸��� ���� ��ġ, �׸��� ����� ����);
        Gizmos.DrawLine(checkTransform.position, checkTransform.position + new Vector3(MoveDirection.x, 0, 0) * detectionDistance);
    }
}
