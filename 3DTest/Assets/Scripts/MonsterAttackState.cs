using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : MonsterState
{
    // 공격 비활성화 애니메이션 이벤트 메소드
    public void AttackDesableAnimationEvent()
    {
        // 공격 비활성화
        fsmInfo.IsAttackable = false;
    }


    // 공격 상태 시작
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        // 공격 대상을 주시함
        LookAtTarget();

        // 공격을 위해 이동 중지
        NavigationStop();

        // 공겨 상태 애니메이션 재생
        animator.SetInteger("State", (int)state);
    }

    public override void ExitState()
    {
        fsmInfo.IsAttackable = true;
    }

    public override void UpdateState()
    {
        // 공격 대상을 주시함
        LookAtTarget();

        // 공격 비활성화된 상태면
        if (!fsmInfo.IsAttackable)
        {
            // 대기 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.IDLE);
            return;
        }


        // 공격 대상이 공격 가능 거리보다 멀어졌다면
        if (controller.GetPlayerDistance() > fsmInfo.AttackDistance)
        {
            controller.TransactionToState(MonsterFSMController.STATE.GIVEUP);
            return;
        }

        

    }
}
