using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetectState : MonsterState
{
    public override void EnterState(MonsterFSMController.STATE state, object date = null)
    {
        base.EnterState(state);

        // ���� �ӵ� ����
        navMeshAgent.speed = fsmInfo.DetectMoveSpeed;

        // ���� �ִϸ��̼� ���
        animator.SetInteger("State", (int)state);
    }

    public override void ExitState()
    {
        // (�ӽ�) �ִϸ��̼� ��� �ӵ� ����
        animator.speed = 1;
    }

    public override void UpdateState()
    {

        // �÷��̾ ���� ���� �Ÿ��ȿ� ������
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance && !pHp.IsDeath)
        {
            // ���� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.IDLE);
            return;
        }

        // ���� ����� ���� ���ɰŸ��� �Ѿ ���� ���ٸ�
        if (controller.GetPlayerDistance() > fsmInfo.DetectDistance || pHp.IsDeath)
        {
            // ����(��ȸ ��ġ)�� ������
            controller.TransactionToState(MonsterFSMController.STATE.GIVEUP);
            return;
        }

        // ���� ��� ���� ó��
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(controller.Player.transform.position);
    }
}
