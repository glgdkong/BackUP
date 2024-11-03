using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGiveUpState : MonsterRoamingState
{
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        // ���� �׺���̼� �̵��ӵ� ����
        navMeshAgent.speed = fsmInfo.GiveUpMoveSpeed;

        base.EnterState(state, data);

        // �ٽ� ��ȸ ó��
        NewRandomDestination(false);    
    }
}
