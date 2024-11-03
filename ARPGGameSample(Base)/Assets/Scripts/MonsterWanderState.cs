using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
// 몬스터 배회 상태 처리 컴포넌트
public class MonsterWanderState : MonsterRoamingState
{
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        // 배회 속도 설정
        navMeshAgent.speed = fsmInfo.WanderMoveSpeed;

        base.EnterState(state, data);

        // 새로운 배회 위치를 탐색
        NewRandomDestination(true);
    }
}
