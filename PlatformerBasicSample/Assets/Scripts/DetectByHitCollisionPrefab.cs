using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 피격을 당할 때 이펙트 프맅펩을 생성
public class DetectByHitCollisionPrefab : DetectByHitCollisionColor
{
    // 충돌 이펙트 
    [SerializeField] protected GameObject collisionEffectPrefab;

    // 이펙트 파괴 시간
    [SerializeField] private float effectDestoryTime;


    protected override void HitProcess(Collider2D collider)
    {
        // 피격 색상 표기가 참이면 피격 색상 표시를 수행함
        if(showHitColor) ShowHitColor();

        // 충돌 위치 설정
        Vector2 hitPosition = collider.transform.position;  
        Quaternion rot = Quaternion.identity;

        // 피격된 대상이 방향 회전 이동 처리 컴포넌트를 가지고 있다면
        DirectionMovement directionAngleMovement = collider.GetComponent<DirectionMovement>();
        if(directionAngleMovement != null)
        {
            // 이동 방향에 대한 회전 값을 적용한 회전 쿼터니언을 생성함
            rot = Quaternion.Euler(0f, 0f, directionAngleMovement.Angle + 90f);
        }


        // 충돌 이펙트 생성
        GameObject explosion = Instantiate(collisionEffectPrefab, hitPosition, rot);
        Destroy(explosion, effectDestoryTime);

        HitDamage(collider);
    }
}
