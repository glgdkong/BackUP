using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : MonsterState
{
    // ���� ��Ȱ��ȭ �ִϸ��̼� �̺�Ʈ �޼ҵ�
    public void AttackDesableAnimationEvent()
    {
        // ���� ��Ȱ��ȭ
        fsmInfo.IsAttackable = false;
    }


    // ���� ���� ����
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        // ���� ����� �ֽ���
        LookAtTarget();

        // ������ ���� �̵� ����
        NavigationStop();

        // ���� ���� �ִϸ��̼� ���
        animator.SetInteger("State", (int)state);
    }

    public override void ExitState()
    {
        fsmInfo.IsAttackable = true;
    }

    public override void UpdateState()
    {
        // ���� ����� �ֽ���
        LookAtTarget();

        // ���� ��Ȱ��ȭ�� ���¸�
        if (!fsmInfo.IsAttackable)
        {
            // ��� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.IDLE);
            return;
        }


        // ���� ����� ���� ���� �Ÿ����� �־����ٸ�
        if (controller.GetPlayerDistance() > fsmInfo.AttackDistance)
        {
            controller.TransactionToState(MonsterFSMController.STATE.GIVEUP);
            return;
        }

        

    }
}
