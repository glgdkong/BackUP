using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 대기 상태 처리 컴포넌트
public class MonsterIdleState : MonsterState
{
    [SerializeField] protected float time; // 시간 계산용

    [SerializeField] protected float checkTime; // 대기 체크 시간

    [SerializeField] protected Vector2 checkTimeRange; // 대기 체크 시간(최소, 최대)


    public override void EnterState(MonsterFSMController.STATE state, object date = null)
    {
        base.EnterState(state);

        // 상태 체크 주기 시간을 추첨함
        time = 0;
        checkTime = Random.Range(checkTimeRange.x, checkTimeRange.y);

        NavigationStop();

        // 대기 애니메이션 재생
        animator.SetInteger("State",(int)state);
    }

    public override void ExitState()
    {
        time = 0;
    }

    public override void UpdateState()
    {
        //Debug.Log("현재 몬스터는 Idle 상태임!!");
        time += Time.deltaTime; // 대기시간 계산

        // 플레이어가 공격 가능 거리 안에 들어왔다면
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance)
        {
            // 공격 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }
        // 플레이어가 추적 가능 거리안에 들어왔다면
        if(controller.GetPlayerDistance() <= fsmInfo.DetectDistance)
        {
            // 추적 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }
        // 대기 상태가 지났다면
        if(time > checkTime)
        {
            int selectState = Random.Range(0, 2); // 대기 배회 상태 추첨
            switch (selectState)
            {
                case 0:
                    // 다시 대기 상태 유지
                    time = 0;
                    checkTime = Random.Range(checkTimeRange.x, checkTimeRange.y);
                    break;
                case 1:
                    // 배회 상태로 전환
                    controller.TransactionToState(MonsterFSMController.STATE.WANDER);
                    return;
            }
        }
    }
}
