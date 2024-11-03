using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    // 공격 대상 레이어
    [SerializeField] protected LayerMask targetLayer;

    // 공격 타겟 중심점 위치
    [SerializeField] protected Transform attackTransform;

    // 공격 범위
    [SerializeField] protected float attackRadius;

    // 공격 범위 각도
    [SerializeField] protected float hitAngle;

    // 피격 애니메이션 타이밍 이벤트
    //[SerializeField] protected GameObject hitAnimEffectPrefab;

    // 공격 데미지
    [SerializeField] protected int damage;
    // 넉백 크기
    [SerializeField] protected float knockbackForce;

    public virtual void RangeAngleTargetAttack()
    {
        // 충돌 범위 체크
        Collider[] hits = Physics.OverlapSphere(attackTransform.position, attackRadius, targetLayer);

        foreach(Collider hit in hits)
        {
            // 타격을 향한 방향 벡터를 구함
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
