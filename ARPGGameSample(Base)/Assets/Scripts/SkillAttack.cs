using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스킬 공격 컴포넌트
public class SkillAttack : MeleeAttack
{
    [SerializeField] private bool isSkill; // 스킬 시연 중

    [SerializeField] private float timeDuration; // 스킬 사용 시간 (지연 시간)

    public bool IsSkill { get => isSkill; set => isSkill = value; }

    [SerializeField] private SkillTimer skillTimer; // 스킬 타이머

    // 스킬 사용 시작
    public void StartSkill()
    {
        IsSkill = true; // 스킬 사용 중 설정

        // 스킬 타이머 구동
        skillTimer.StartTimer(this, timeDuration);
    }

    // 스킬 사용 끝
    public void EndSkill()
    {
        // 스킬 사용 끝 설정
        IsSkill = false;
    }

}
