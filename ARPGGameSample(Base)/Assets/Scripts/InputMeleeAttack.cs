using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMeleeAttack : MonoBehaviour
{
    // 공격 지연 코루틴 관련
    private WaitForSeconds attackInputWait;
    private Coroutine attackWaitCoroutine;
    [SerializeField] private float attackInputDuration; // 공격 입력 지연시간

    public bool isAttackInput; // 공격 입력 기능

    private Animator animator; // 애니메이션 컴포넌트

    // 공격 애니메이션 파라미터 해시
    private int hashMeleeAttack = Animator.StringToHash("MeleeAttack"); // 공격 트리거 파라미터
    private int hashStateTime = Animator.StringToHash("StateTime"); // 애니메이션 진행률(시간)

    // 콤보 공격 애니메이션 노드 해시
    private int hashCombo1 = Animator.StringToHash("Combo1"); // 공격1
    private int hashCombo2 = Animator.StringToHash("Combo2"); // 공격2
    private int hashCombo3 = Animator.StringToHash("Combo3"); // 공격3
    private int hashCombo4 = Animator.StringToHash("Combo4"); // 공격4

    // 애니메이션 상태
    private AnimatorStateInfo currentStateInfo;
    // 애니메이션노드 진행률(시간)
    [SerializeField]private float animationNormalTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attackInputWait = new WaitForSeconds(attackInputDuration);
    }
    private void Update()
    {
        // 공격 입력 지연 처리
        if (Input.GetButtonDown("SquareButton") && !isAttackInput)
        {
            if (attackWaitCoroutine != null)
                StopCoroutine(attackWaitCoroutine);
            attackWaitCoroutine = StartCoroutine(AttackWait());
        }

        // 공격 입력이 있다면
        if(Input.GetButtonDown("SquareButton"))
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
        if(isAttackInput)
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
        // 공격 입력 지연 대기
        yield return attackInputWait;
        // 공격 입력 불가능
        isAttackInput = false;
    }

    // 공격 애니메이션 재생 상태 체크
    public bool IsPlayAttackAnimation()
    {
        // 현재 애니메이션 상태 정보
        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 만약 현재 공격 관련 애니메이션을 재생 중이면
        if(currentStateInfo.shortNameHash == hashMeleeAttack || 
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
