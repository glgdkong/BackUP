using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 플레이어 추적 상태 처리 컴포넌트
public class MonsterDetectState : MonsterState
{
    public override void EnterState(MonsterFSMController.STATE state, object date = null)
    {
        base.EnterState(state);

        // 추적 속도 설정
        navMeshAgent.speed = fsmInfo.DetectMoveSpeed;

        // 추적 애니메이션 재생
        animator.SetInteger("State", (int)state);
    }

    public override void ExitState()
    {
        // (임시) 애니메이션 재생 속도 복원
        animator.speed = 1;
    }

    public override void UpdateState()
    {
        //Debug.Log("현재 몬스터는 Detect 상태임!!");

        // 추적하던 공격 대상이 공격 가능 거리 안으로 들오왔다면
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance)
        {
            // 공격 상태로 전환함
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }

        // 추적 대상이 추적 가능거리를 넘어서 도망 갔다면
        if(controller.GetPlayerDistance() > fsmInfo.DetectDistance)
        {
            // 기지(배회 위치)로 복귀함
            controller.TransactionToState(MonsterFSMController.STATE.GIVEUP);
            return;
        }

        // 공격 대상 추적 처리
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(controller.Player.transform.position);
    }
}
