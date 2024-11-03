using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �÷��̾� ���� ���� ó�� ������Ʈ
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
        //Debug.Log("���� ���ʹ� Detect ������!!");

        // �����ϴ� ���� ����� ���� ���� �Ÿ� ������ ����Դٸ�
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance)
        {
            // ���� ���·� ��ȯ��
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }

        // ���� ����� ���� ���ɰŸ��� �Ѿ ���� ���ٸ�
        if(controller.GetPlayerDistance() > fsmInfo.DetectDistance)
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
