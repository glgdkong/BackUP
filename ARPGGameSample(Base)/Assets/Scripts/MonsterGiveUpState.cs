using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� ���� ó�� ������Ʈ
public class MonsterGiveUpState : MonsterRoamingState
{
    public override void EnterState(MonsterFSMController.STATE state, object date = null)
    {
        // ���� �׺���̼� �̵� �ӵ� ����
        navMeshAgent.speed = fsmInfo.GiveUpMoveSpeed;

        base.EnterState(state);

        // �ٽ� ��ȸ ó��
        NewRandomDestination(false);
    }
}
