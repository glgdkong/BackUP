using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 피격 및 충돌 처리 컴포넌트
public abstract class DetectByHitCollision : MonoBehaviour
{
    // 피격 대상 인식 태그명
    [SerializeField] protected string collisionTag;

    // 피격 대상에게 부여할 데미지
    [SerializeField] protected int damage;

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        // 피격 대상이 맞으면
        if (collider.tag.Equals(collisionTag))
        {
            // 피격 처리를 진행함
            HitProcess(collider);
        }
    }

    // 피격 처리 추상 메소드
    protected abstract void HitProcess(Collider2D collider);

    // 피격 대상에게 데미지를 부여함
    protected virtual void HitDamage(Collider2D collider)
    {
        // ? 연산자 : ? 연산자가 설정된 참조변수의 참조값이 null이 아닐때만 메소드 호출하는 연산자
        
        // 충돌한 오브젝트가 충돌을 통해 데미지를 부여할 대상이면
        Attacker attacker = collider.GetComponent<Attacker>();
        if (attacker == null) return;

        // 현재 캐릭터가 피격이 당할 수 있는 대상이면
        IHitable hitable = GetComponent<IHitable>();
        // 현재 캐릭터의 피격 처리
        hitable?.Hit(attacker.Damage);
        // 충돌 공격 대상 자동 파괴 처리
        attacker.Disappear();

    }
}
