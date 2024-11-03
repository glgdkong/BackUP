using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMeleeAttack : PlayerController
{
    // ���� ���� �ڷ�ƾ ����
    private WaitForSeconds attackInputWait;
    private Coroutine attackWaitCoroutine;
    [SerializeField] private float attackInputDuration;

    // ���� �Է� ���
    public bool isAttackInput;


    // ���� �ִϸ��̼� �Ķ���� �ؽ�
    private int hashMeleeAttack = Animator.StringToHash("MeleeAttack"); // ���� Ʈ���� �Ķ����
    private int hashStateTime = Animator.StringToHash("StateTime"); // �ִϸ��̼� �����(�ð�)

    // �޺� ���� �ִϸ��̼� ��� �ؽ�
    private int hashCombo1 = Animator.StringToHash("Combo1");
    private int hashCombo2 = Animator.StringToHash("Combo2");
    private int hashCombo3 = Animator.StringToHash("Combo3");
    private int hashCombo4 = Animator.StringToHash("Combo4");

    // �ִϸ��̼� ���� 
    private AnimatorStateInfo currentStateInfo;

    // �ִϸ��̼� ����� 
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
        // ���� �Է� ���� ó��
        if (Input.GetButtonDown("NormalAttack") && !isAttackInput)
        {
            if (attackWaitCoroutine != null)
                StopCoroutine(attackWaitCoroutine);
            attackWaitCoroutine = StartCoroutine(AttackWait());
        }

        // ���� �Է��� �ִٸ�
        if (Input.GetButtonDown("NormalAttack"))
        {
            isAttackInput = true; // ���� �Է� ����
        }

        // ���� �ִϸ��̼� ����� �����(0 ~ 1f : �ð�) ����
        animationNormalTime = Mathf.Repeat(animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 1f);

        // �ִϸ��̼� ���̾� ���� ����(�ۼ�Ʈ) ������ �ִϸ��̼� ���� �ð����� �ݺ� ����
        animator.SetFloat(hashStateTime, animationNormalTime);
        // ���� Trigger ����
        animator.ResetTrigger(hashMeleeAttack);

        // ���� �ִϸ��̼� ���
        if (isAttackInput)
        {
            animator.SetTrigger(hashMeleeAttack);
            isAttackInput = false;
        }

    }

    // ���� �Է� ���� �ڷ�ƾ
    IEnumerator AttackWait()
    {
        // ���� �Է� ����
        isAttackInput = true;

        yield return attackInputWait;

        isAttackInput = false;
    }

    // ���� �ִϸ��̼� ��� ���� üũ
    public bool IsPlayAttackAniamtion()
    {
        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // ���� ���� ���� �ִϸ��̼��� ��� ���̸�
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
