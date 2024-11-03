using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMeleeAttack : PlayerController
{
    // 공격 지연 코루틴 관련
    private WaitForSeconds attackInputWait;
    private Coroutine attackWaitCoroutine;
    [SerializeField] private float attackInputDuration;

    // 공격 입력 기능
    public bool isAttackInput;


    // 공격 애니메이션 파라미터 해시
    private int hashMeleeAttack = Animator.StringToHash("MeleeAttack"); // 공격 트리거 파라미터
    private int hashStateTime = Animator.StringToHash("StateTime"); // 애니메이션 진행률(시간)

    // 콤보 공격 애니메이션 노드 해시
    private int hashCombo1 = Animator.StringToHash("Combo1");
    private int hashCombo2 = Animator.StringToHash("Combo2");
    private int hashCombo3 = Animator.StringToHash("Combo3");
    private int hashCombo4 = Animator.StringToHash("Combo4");

    // 애니메이션 상태 
    private AnimatorStateInfo currentStateInfo;

    // 애니메이션 진행률 
    [SerializeField] private float animationNormalTime;

    

    private void Start()
    {
        attackInputWait = new WaitForSeconds(attackInputDuration);
        
    }

    private void Update()
    {
        if (playerHp.IsHit || playerHp.IsDeath)
        {
            return; 
        }
        // 공격 입력 지연 처리
        if (Input.GetButtonDown("NormalAttack") && !isAttackInput)
        {
            if (attackWaitCoroutine != null)
                StopCoroutine(attackWaitCoroutine);
            attackWaitCoroutine = StartCoroutine(AttackWait());
        }

        // 공격 입력이 있다면
        if (Input.GetButtonDown("NormalAttack"))
        {
            isAttackInput = true; // 공격 입력 설정
        }

        // 현재 애니메이션 노드의 진행률(0 ~ 1f : 시간) 저장
        animationNormalTime = Mathf.Repeat(animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 1f);

        // 애니메이션 레이어 진행 상태(퍼센트) 정보를 애니메이션 상태 시간으로 반복 설정
        animator.SetFloat(hashStateTime, animationNormalTime);
        // 공격 Trigger 리셋
        animator.ResetTrigger(hashMeleeAttack);

        // 공격 애니메이션 재생
        if (isAttackInput)
        {
            animator.SetTrigger(hashMeleeAttack);
            isAttackInput = false;
        }

    }

    // 공격 입력 지연 코루틴
    IEnumerator AttackWait()
    {
        // 공격 입력 가능
        isAttackInput = true;

        yield return attackInputWait;

        isAttackInput = false;
    }

    // 공격 애니메이션 재생 상태 체크
    public bool IsPlayAttackAniamtion()
    {
        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 만약 현재 공격 애니메이션을 재생 중이면
        if (currentStateInfo.shortNameHash == hashMeleeAttack ||
           currentStateInfo.shortNameHash == hashCombo1 ||
           currentStateInfo.shortNameHash == hashCombo2 ||
           currentStateInfo.shortNameHash == hashCombo3 ||
           currentStateInfo.shortNameHash == hashCombo4)
        {
            return true;
        }
        return false;
    }

}
