using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWanderState : MonsterRoamingState
{
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        // ��ȸ �ӵ� ����
        navMeshAgent.speed = fsmInfo.WanderMoveSpeed;

        base.EnterState(state, data);

        // ���ο� ��ȸ ��ġ�� Ž��
        NewRandomDestination(true);
    }
}
