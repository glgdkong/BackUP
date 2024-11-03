using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGiveUpState : MonsterRoamingState
{
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        // 복귀 네비게이션 이동속도 설정
        navMeshAgent.speed = fsmInfo.GiveUpMoveSpeed;

        base.EnterState(state, data);

        // 다시 배회 처리
        NewRandomDestination(false);    
    }
}
