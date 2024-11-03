using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
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
    //[SerializeField] protected GameObject hitAnimEffectPrefab;

    // ���� ������
    [SerializeField] protected int damage;
    // �˹� ũ��
    [SerializeField] protected float knockbackForce;

    public virtual void RangeAngleTargetAttack()
    {
        // �浹 ���� üũ
        Collider[] hits = Physics.OverlapSphere(attackTransform.position, attackRadius, targetLayer);

        foreach(Collider hit in hits)
        {
            // Ÿ���� ���� ���� ���͸� ����
            Vector3 directionToTarget = hit.transform.position - transform.position;
            directionToTarget = new Vector3(directionToTarget.x, transform.position.y, directionToTarget.z);

            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if(angleToTarget < hitAngle)
            {
                IHitAble h = hit.GetComponent<IHitAble>();
                if(!h.IsHit && !h.IsDeath)
                { 
                    h.Hit(damage, knockbackForce);
                }
            }
        }
    }
}
