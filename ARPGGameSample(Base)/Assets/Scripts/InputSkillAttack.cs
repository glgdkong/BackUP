using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ų �Է� ó�� �� ��ų ���� ������Ʈ
public class InputSkillAttack : MonoBehaviour
{
    private Animator animator; // �ִϸ�����
    private AnimatorStateInfo currentStateInfo; // ���� �ִϸ��̼� ���� ����

    public enum SKILLS { HORI_SKILL, VERT_SKILL }; // ��ų �̳� Ÿ��

    [SerializeField] private string[] skillHashNames; // ��ų �ִϸ��̼� �ؽ� ����

    // ��ų �ִϸ��̼� �ؽ� �迭
    private int[] hashSkillAttacks;

    [SerializeField] private SkillAttack[] skillAttacks; // ���� ��ų ������Ʈ(����)

    // Start is called before the first frame update
    void Start()
    {
        // ��ų �ؽ� �迭
        hashSkillAttacks = new int[skillHashNames.Length];

        // ��ų �̸��� ���� ��ų �ִϸ��̼� �ؽ� ������ ������
        for (int i = 0; i < skillHashNames.Length; i++)
        {
            hashSkillAttacks[i] = Animator.StringToHash(skillHashNames[i]);
        }
        // �ִϸ����� ������Ʈ ����
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ��ų �ִϸ��̼��� �������̸� �о�
        // * ���� Ÿ�̸Ӱ� ����� ��� ū �ǹ̴� ����
        if (IsSkillAnimation()) return;

        // ��ų 1, ��ų 2 �ִϸ��̼� ���
        if (Input.GetButtonDown("TriangleButton") && !skillAttacks[(int)SKILLS.HORI_SKILL].IsSkill)
        {
            skillAttacks[(int)SKILLS.HORI_SKILL].StartSkill(); // ��ų 1 ���� ����
            // �ִϸ��̼� �ߵ� �ʱ�ȭ
            animator.ResetTrigger(hashSkillAttacks[(int)SKILLS.HORI_SKILL]);
            animator.SetTrigger(hashSkillAttacks[(int)SKILLS.HORI_SKILL]);
        }
        else if (Input.GetButtonDown("CircleButton") && !skillAttacks[(int)SKILLS.VERT_SKILL].IsSkill)
        {
            skillAttacks[(int)SKILLS.VERT_SKILL].StartSkill(); // ��ų 2 ���� ����
            animator.ResetTrigger(hashSkillAttacks[(int) SKILLS.VERT_SKILL]);
            animator.SetTrigger(hashSkillAttacks[(int) SKILLS.VERT_SKILL]);
        }
    }

    // ��ų �ִϸ��̼� ��� �� ���� üũ (�ִϸ��̼� �ؽ� �ڵ� ���)
    public bool IsSkillAnimation()
    {
        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0); // ���� ������� �ִϸ��̼� ����
        
        if (currentStateInfo.shortNameHash == hashSkillAttacks[(int)SKILLS.HORI_SKILL] ||
            currentStateInfo.shortNameHash == hashSkillAttacks[(int)SKILLS.VERT_SKILL])
        { return true; }
        return false;
    }
}
