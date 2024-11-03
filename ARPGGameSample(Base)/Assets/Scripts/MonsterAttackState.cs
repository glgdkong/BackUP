using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 공격 상태 처리 컴포넌트
public class MonsterAttackState : MonsterState
{
   protected void LookAtTarget()
   {
        

        // 공격 대상을 향한 방향을 계산
        Vector3 direction = (controller.Player.transform.position - transform.position).normalized;
        // transform.LookAt(transform.positon + direction)

        // 회전 쿼터니언 계산
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f , direction.z));

        // 부드럽게 회전
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * fsmInfo.LookAtMaxSpeed);
   }

    // 공격 상태 시작
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        // 공격을 위래 이동 중지
        NavigationStop();
        // 공격 상태 애니메이션 재생
        animator.SetInteger("State", (int)state);
    }

    public override void ExitState()
    {

    }
    // 공격 상태 진행
    public override void UpdateState()
    {
        // 공격 대상이 공격 가능 거리보다 멀어졌다면
        if (controller.GetPlayerDistance() > fsmInfo.AttackDistance) 
        {
            // 배회 위치로 복귀
            controller.TransactionToState(MonsterFSMController.STATE.GIVEUP);
            return;
        }

        // 공격 대상을 주시함
        LookAtTarget();

    }
}
