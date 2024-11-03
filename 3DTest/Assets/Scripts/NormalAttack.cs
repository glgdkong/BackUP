using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : MeleeAttack
{
    // 일반 공격 애니메이션 이벤트 메소드
    public void MeleeAttackAniamtionEvent()
    {
        // 범위 타겟들 공격 처리
        RangeAngleTargetAttack();
    }
}
