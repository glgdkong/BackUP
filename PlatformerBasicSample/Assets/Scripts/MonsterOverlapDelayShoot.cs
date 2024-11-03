using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� ���� ���� ����
public class MonsterOverlapDelayShoot : MonsterDelayShoot
{
    // ���� ���� ��ġ
    [SerializeField] protected Transform overlapTransform;

    // ���� ���� ���� �޼ҵ� ������
    protected override void DetectAndShoot()
    {
        // * ���� �浹 ���� 
        // - Collider2D[] ����������ݶ��̴�������Ʈ������ = Physics2D.OverlapCircleAll(������������, ����ũ��(������), �浹�������̾�)
        // - ���� : ����Ʈ(��), ����, �簢��, ĸ��, ����


        // ���� ������ ���� �浹 ��� ������ ����
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(overlapTransform.position, detectionRange, detectLayer);

        // �浹ü �߿� �÷��̾ �����ϴ����� �ľ�
        foreach (var hitCollider in hitColliders)
        {
            // �÷��̾ ���� ��� �����Ѵٸ�
            if (hitCollider.CompareTag("Player"))
            {
                // �÷��̾ ���� ���� ���͸� �����
                Vector2 targetPosition = hitCollider.transform.position;
                Vector2 monsterPosition = shootTransform.position;  

                // ���� ������ ������
                ShootDirection = (targetPosition - monsterPosition).normalized;

                // �Ѿ� �߻�
                Fire();
                return;

            }
        }
    }

    // ��� ���� ���� ����� ���� ǥ�� �̺�Ʈ �޼ҵ�
    private void OnDrawGizmosSelected()
    {
        // ���� ǥ���� ����� ������ ������
        Gizmos.color = Color.red;
        // ������ ���� ������ ���� ���������� ������ ����� ���� �׷���
        Gizmos.DrawWireSphere(overlapTransform.position, detectionRange);
    }
}
