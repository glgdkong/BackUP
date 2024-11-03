using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 복귀 상태 처리 컴포넌트
public class MonsterGiveUpState : MonsterRoamingState
{
    public override void EnterState(MonsterFSMController.STATE state, object date = null)
    {
        // 복귀 네비게이션 이동 속도 설정
        navMeshAgent.speed = fsmInfo.GiveUpMoveSpeed;

        base.EnterState(state);

        // 다시 배회 처리
        NewRandomDestination(false);
    }
}
