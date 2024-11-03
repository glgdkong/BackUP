using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일반 근접 공격 컴포넌트
public class NormalMeleeAttack : MeleeAttack
{
    // 일반 공격 애니메이션 피격 이벤트
    public void MeleeAttackHitAnimationEvent()
    {
        // 범위 타겟들 공격 처리
        RangeAngleTargetAttack();
    }
}
