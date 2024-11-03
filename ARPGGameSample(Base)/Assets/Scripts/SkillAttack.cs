using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ų ���� ������Ʈ
public class SkillAttack : MeleeAttack
{
    [SerializeField] private bool isSkill; // ��ų �ÿ� ��

    [SerializeField] private float timeDuration; // ��ų ��� �ð� (���� �ð�)

    public bool IsSkill { get => isSkill; set => isSkill = value; }

    [SerializeField] private SkillTimer skillTimer; // ��ų Ÿ�̸�

    // ��ų ��� ����
    public void StartSkill()
    {
        IsSkill = true; // ��ų ��� �� ����

        // ��ų Ÿ�̸� ����
        skillTimer.StartTimer(this, timeDuration);
    }

    // ��ų ��� ��
    public void EndSkill()
    {
        // ��ų ��� �� ����
        IsSkill = false;
    }

}
