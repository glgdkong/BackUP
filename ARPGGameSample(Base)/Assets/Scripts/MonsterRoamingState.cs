using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterRoamingState : MonsterState // Wander, GiveUp
{
    // 배회 위치 게임오브젝트 참조
    protected Transform targetTransform = null;
    // 배회 목적지 : 위치 (기본 : 무한 위치값)
    public Vector3 targetPosition = Vector3.positiveInfinity;
    // 배회할 위치와 몬스터간의 거리
    public float targetDistance = Mathf.Infinity;

    // 배회 상태 시작
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state);

        // 배회 애니메이션 재생
        animator.SetInteger("State", (int)state);

    }

    public override void ExitState()
    {
        // 네비게이션 이동 종료
        //navMeshAgent.isStopped = true;
        NavigationStop();

        // 배회 관련 위치 정보들 초기화
        targetTransform = null;
        targetPosition = Vector3.positiveInfinity; // 무한 벡터 최대값 : (Mathf.Infinity, Mathf.Infinity, Mathf.Infinity)
        targetDistance = Mathf.Infinity; // 실수 최대값 설정

        // * 무한벡터 최소값 설정
        // - Vector3.negativeInfinity : (-Mathf.Infinity, -Mathf.Infinity, -Mathf.Infinity)
    }

    public override void UpdateState()
    {
        // 플레이어가 공격 가능 거리안에 들어오면
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance)
        {
            // 공격 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }
        // 플레이어가 추적 가능 거리안에 들어오면
        if (controller.GetPlayerDistance() <= fsmInfo.DetectDistance)
        {
            // 추적 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }
        if(targetTransform != null)
        {
            // 배회할 위치 근처에 도달 했다면
            targetDistance =Vector3.Distance(transform.position, targetPosition);
            if (targetDistance < 1f)
            {
                // 대기 상태로 전환
                controller.TransactionToState(MonsterFSMController.STATE.IDLE);
            }
        }
    }

    // 새로운 배회 위치를 탐색함
    protected virtual void NewRandomDestination(bool retry)
    {
        // 배회 위치 인덱스 추첨
        int index = Random.Range(0, fsmInfo.WanderPoints.Length);

        // 같은 배회 위치를 탐색 했다면 다시 탐색
        float distance = Vector3.Distance(fsmInfo.WanderPoints[index].position, transform.position);
        if (distance < fsmInfo.NextPointSelectDistance && retry)
        {
            // 배회할 위치를 다시 추첨함 -> 재귀 호출
            // * 재귀 함수 : 함수가 자기 자신을 호출하는 프로그래밍 기법으로,
            //              주로 복잡한 문제를 작은 문제들로 분할하여 해결할 때 사용 되며, 
            //              반드시 종료조건(기저 조건)이 있어야 무한 루프에 빠지지 않고 종료됨
            NewRandomDestination(true);
            return;
        }

        // 배회 위치로 선정
        targetTransform = fsmInfo.WanderPoints[index];

        // 배회 위치를 기준으로한 일정 범위 안의 랜덤한 위치를 재선정
        Vector3 randomDirection = Random.insideUnitSphere * fsmInfo.NextPointSelectDistance;
        randomDirection += fsmInfo.WanderPoints[index].position;
        randomDirection.y = 0f;

        // 랜덤 추첨한 배회 위치를 네비게이션 에이전트 이동 속도로 설정
        targetPosition = randomDirection;

        //Debug.Log($"배회 / 복귀 이동할 위치 : {targetPosition}");

        // 네비게이션 이동이 유효하다면
        NavMeshHit hit;
        // NavMesh.SamplePosition(randomDirection, out hit, fsmInfo.WanderNavCheckRadius, NavMesh.AllAreas)
        // 현재 내가 가려는 포인트 점이 갈수 있는 영역인지 알려주는 API
        if (NavMesh.SamplePosition(randomDirection, out hit, fsmInfo.WanderNavCheckRadius, NavMesh.AllAreas))
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.speed = fsmInfo.WanderMoveSpeed;
            navMeshAgent.SetDestination(targetPosition);
        }
    }
}
