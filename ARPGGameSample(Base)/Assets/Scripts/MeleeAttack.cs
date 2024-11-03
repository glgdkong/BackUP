using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� ó�� ������Ʈ(����)
public  class MeleeAttack : MonoBehaviour
{
    // ���� ��� ���̾�
    [SerializeField] protected LayerMask targetLayer;
    
    // ���� Ÿ�� �߽��� ��ġ
    [SerializeField] protected Transform attackTransform;
    
    // ���� ����
    [SerializeField] protected float attackRadius;

    // ���� ���� ���� 
    [SerializeField] protected float hitAngle;

    // �ǰ� �ִϸ��̼� Ÿ�̹� �̺�Ʈ
    [SerializeField] protected GameObject hitAnimEffectPrefab;

    // ���� ������
    [SerializeField] protected int damage;
    
    // �˺� ũ��
    [SerializeField] protected float knockbackForce;

    public virtual void RangeAngleTargetAttack()
    {
        // * Collider[] hits = Physics.OverlapSphere(�浹 üũ �߽�����ġ, �浹üũ ����, ��� ���̾�);
        // - ���� ĳ��Ʈ ó�� �ش� �޼ҵ尡 ���� �Ǵ� ���� ���� �����ȿ� �ִ� �浹 ������ ������
        Collider[] hits = Physics.OverlapSphere(attackTransform.position, attackRadius, targetLayer);

        // �ǰݵ� ������ ������ ���� �ȿ� �ִ� ����� Ÿ����
        foreach (Collider hit in hits)
        {
            // �÷��̾ Ÿ���� ���� ���⺤�͸� ����
            Vector3 directionToTarget = hit.transform.position - transform.position;
            directionToTarget = new Vector3(directionToTarget.x, transform.position.y, directionToTarget.z);

            // Ÿ�� ������ �ü� ������ ����
            float angleToTarget = Vector3.Angle(transform.forward,  directionToTarget);

            if(angleToTarget < hitAngle)
            {
                //Debug.Log($"{hit.name} ���͸� Ÿ����");

                // ���� Ÿ��
                hit.GetComponent<MonsterHealth>().Hit(damage, knockbackForce);
            }
        }
    }
}
