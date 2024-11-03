using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterRoamingState : MonsterState
{
    // 배회 위치 게임오브젝트 참조
    protected Transform targetTransform = null;

    // 배회 목적지 
    public Vector3 targetPosition = Vector3.positiveInfinity;

    // 배회할 위치와 몬스터간의 거리
    public float targetDistance = Mathf.Infinity;

    // 배회 상태 시작
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        // 배회 애니메이션 재생
        animator.SetInteger("State", (int)state);
    }

    public override void ExitState()
    {
        // 네비게이션 이동 종료
        NavigationStop();

        // 배회 관련 위치 정보들 초기화
        targetTransform = null;
        targetPosition = Vector3.positiveInfinity;
        targetDistance = Mathf.Infinity;
    }

    public override void UpdateState()
    {
        // 플레이어가 공격 가능 거리안에 들어오면
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance && !pHp.IsDeath)
        {
            // 공격 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }
        // 플레이어가 추적 가능 거리안에 들어오면
        if (controller.GetPlayerDistance() <= fsmInfo.DetectDistance && !pHp.IsDeath)
        {
            // 추적 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }

        if (targetTransform != null)
        {
            // 배회할 위치 근처에 도달 했다면
            targetDistance = Vector3.Distance(transform.position, targetPosition);
            if(targetDistance < 1f)
            {
                controller.TransactionToState(MonsterFSMController.STATE.IDLE);
            }
        }
    }

    // 새로운 배회 위치를 탐색함
    protected virtual void NewRandomDestination(bool retry)
    {
        // 배회 인덱스 추첨
        int index = Random.Range(0, fsmInfo.WanderPoints.Length);

        // 같은 배회 위치를 탐색 했다면 다시 탐색
        float distance = Vector3.Distance(fsmInfo.WanderPoints[index].position, transform.position);
        if (distance < fsmInfo.NextPointSelectDistance && retry)
        {
            NewRandomDestination(true);
            return;
        }

        // 배회 위치로 선정
        targetTransform = fsmInfo.WanderPoints[index];

        // 배회 위치를 기준으로한 일정 범위 안의 랜덤한 위치를 재선정
        Vector3 randomDirection = Random.insideUnitSphere * fsmInfo.NextPointSelectDistance;
        randomDirection += fsmInfo.WanderPoints[index].position;
        randomDirection.y = fsmInfo.WanderPoints[index].position.y;

        // 랜덤 추첨한 배회 위치를 네비게이션 에이전트 이동 속도로 설정
        targetPosition = randomDirection;

        // 네비게이션이동이 유효 하다면
        NavMeshHit hit;

        // 현재 내가 가려는 포인트 점이 갈 수 있는 영역인지 확인
        if (NavMesh.SamplePosition(randomDirection, out hit, fsmInfo.WanderNavCheckRadius, NavMesh.AllAreas))
        { 
            navMeshAgent.isStopped = false;
            navMeshAgent.speed = fsmInfo.WanderMoveSpeed;
            navMeshAgent.SetDestination(targetPosition);
        }
    }
}
