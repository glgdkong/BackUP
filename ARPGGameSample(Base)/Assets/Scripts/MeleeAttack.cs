using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 근접 공격 처리 컴포넌트(공통)
public  class MeleeAttack : MonoBehaviour
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
    [SerializeField] protected GameObject hitAnimEffectPrefab;

    // 공격 데미지
    [SerializeField] protected int damage;
    
    // 넉벡 크기
    [SerializeField] protected float knockbackForce;

    public virtual void RangeAngleTargetAttack()
    {
        // * Collider[] hits = Physics.OverlapSphere(충돌 체크 중심점위치, 충돌체크 범위, 대상 레이어);
        // - 레이 캐스트 처럼 해당 메소드가 실행 되는 순간 설정 영역안에 있는 충돌 대상들을 검출함
        Collider[] hits = Physics.OverlapSphere(attackTransform.position, attackRadius, targetLayer);

        // 피격된 대상들중 지정된 각도 안에 있는 대상을 타격함
        foreach (Collider hit in hits)
        {
            // 플레이어가 타격을 향한 방향벡터를 구함
            Vector3 directionToTarget = hit.transform.position - transform.position;
            directionToTarget = new Vector3(directionToTarget.x, transform.position.y, directionToTarget.z);

            // 타격 대상과의 시선 각도를 구함
            float angleToTarget = Vector3.Angle(transform.forward,  directionToTarget);

            if(angleToTarget < hitAngle)
            {
                //Debug.Log($"{hit.name} 몬스터를 타격함");

                // 몬스터 타격
                hit.GetComponent<MonsterHealth>().Hit(damage, knockbackForce);
            }
        }
    }
}
