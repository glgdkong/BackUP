using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 수평 스윙 공격 스킬 컴포넌트
public class HSwingSkillAttack : SkillAttack
{
    // 수평 스윙 공격 스킬 애니메이션 이벤트
    public void HSwingSkillHitAnimationEvent()
    {
        // 타겟 범위 공격(데미지 부여) 실행
        RangeAngleTargetAttack();
    }
}
