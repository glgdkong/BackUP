using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스킬 입력 처리 및 스킬 수행 컴포넌트
public class InputSkillAttack : MonoBehaviour
{
    private Animator animator; // 애니메이터
    private AnimatorStateInfo currentStateInfo; // 현재 애니메이션 상태 정보

    public enum SKILLS { HORI_SKILL, VERT_SKILL }; // 스킬 이넘 타입

    [SerializeField] private string[] skillHashNames; // 스킬 애니메이션 해시 네임

    // 스킬 애니메이션 해시 배열
    private int[] hashSkillAttacks;

    [SerializeField] private SkillAttack[] skillAttacks; // 공격 스킬 컴포넌트(근접)

    // Start is called before the first frame update
    void Start()
    {
        // 스킬 해시 배열
        hashSkillAttacks = new int[skillHashNames.Length];

        // 스킬 이름을 통해 스킬 애니메이션 해시 정보를 참조함
        for (int i = 0; i < skillHashNames.Length; i++)
        {
            hashSkillAttacks[i] = Animator.StringToHash(skillHashNames[i]);
        }
        // 애니메이터 컴포넌트 참조
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 스킬 애니메이션이 동작중이면 패쓰
        // * 현재 타이머가 정용된 경우 큰 의미는 없음
        if (IsSkillAnimation()) return;

        // 스킬 1, 스킬 2 애니메이션 재생
        if (Input.GetButtonDown("TriangleButton") && !skillAttacks[(int)SKILLS.HORI_SKILL].IsSkill)
        {
            skillAttacks[(int)SKILLS.HORI_SKILL].StartSkill(); // 스킬 1 동작 시작
            // 애니메이션 발동 초기화
            animator.ResetTrigger(hashSkillAttacks[(int)SKILLS.HORI_SKILL]);
            animator.SetTrigger(hashSkillAttacks[(int)SKILLS.HORI_SKILL]);
        }
        else if (Input.GetButtonDown("CircleButton") && !skillAttacks[(int)SKILLS.VERT_SKILL].IsSkill)
        {
            skillAttacks[(int)SKILLS.VERT_SKILL].StartSkill(); // 스킬 2 동작 시작
            animator.ResetTrigger(hashSkillAttacks[(int) SKILLS.VERT_SKILL]);
            animator.SetTrigger(hashSkillAttacks[(int) SKILLS.VERT_SKILL]);
        }
    }

    // 스킬 애니메이션 재생 중 상태 체크 (애니메이션 해시 코드 기반)
    public bool IsSkillAnimation()
    {
        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0); // 현재 재생중인 애니메이션 정보
        
        if (currentStateInfo.shortNameHash == hashSkillAttacks[(int)SKILLS.HORI_SKILL] ||
            currentStateInfo.shortNameHash == hashSkillAttacks[(int)SKILLS.VERT_SKILL])
        { return true; }
        return false;
    }
}
