using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMeleeAttack : MonoBehaviour
{
    // ���� ���� �ڷ�ƾ ����
    private WaitForSeconds attackInputWait;
    private Coroutine attackWaitCoroutine;
    [SerializeField] private float attackInputDuration; // ���� �Է� �����ð�

    public bool isAttackInput; // ���� �Է� ���

    private Animator animator; // �ִϸ��̼� ������Ʈ

    // ���� �ִϸ��̼� �Ķ���� �ؽ�
    private int hashMeleeAttack = Animator.StringToHash("MeleeAttack"); // ���� Ʈ���� �Ķ����
    private int hashStateTime = Animator.StringToHash("StateTime"); // �ִϸ��̼� �����(�ð�)

    // �޺� ���� �ִϸ��̼� ��� �ؽ�
    private int hashCombo1 = Animator.StringToHash("Combo1"); // ����1
    private int hashCombo2 = Animator.StringToHash("Combo2"); // ����2
    private int hashCombo3 = Animator.StringToHash("Combo3"); // ����3
    private int hashCombo4 = Animator.StringToHash("Combo4"); // ����4

    // �ִϸ��̼� ����
    private AnimatorStateInfo currentStateInfo;
    // �ִϸ��̼ǳ�� �����(�ð�)
    [SerializeField]private float animationNormalTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attackInputWait = new WaitForSeconds(attackInputDuration);
    }
    private void Update()
    {
        // ���� �Է� ���� ó��
        if (Input.GetButtonDown("SquareButton") && !isAttackInput)
        {
            if (attackWaitCoroutine != null)
                StopCoroutine(attackWaitCoroutine);
            attackWaitCoroutine = StartCoroutine(AttackWait());
        }

        // ���� �Է��� �ִٸ�
        if(Input.GetButtonDown("SquareButton"))
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
        if(isAttackInput)
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
        // ���� �Է� ���� ���
        yield return attackInputWait;
        // ���� �Է� �Ұ���
        isAttackInput = false;
    }

    // ���� �ִϸ��̼� ��� ���� üũ
    public bool IsPlayAttackAnimation()
    {
        // ���� �ִϸ��̼� ���� ����
        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // ���� ���� ���� ���� �ִϸ��̼��� ��� ���̸�
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
