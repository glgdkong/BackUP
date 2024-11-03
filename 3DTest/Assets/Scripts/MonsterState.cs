using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterState : MonoBehaviour
{
    // 몬스터 유한상태기계 컨트롤러
    protected MonsterFSMController controller;

    // 애니메이터 컴포넌트
    protected Animator animator;

    // 네비게이션 컴포넌트
    protected NavMeshAgent navMeshAgent;

    // 몬스터 상태 정보
    protected MonsterFSMInfo fsmInfo;

    // 플레이어 체력 컴포넌트
    protected PlayerHealthController pHp;

    [Range(1f, 2f)]
    [SerializeField] protected float animSpeed; // 애니메이션 재생속도

    protected virtual void Awake()
    {
        controller = GetComponent<MonsterFSMController>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        fsmInfo = GetComponent<MonsterFSMInfo>();
        pHp = FindObjectOfType<PlayerHealthController>();
    }

    // 공격 대상을 향한 방향을 계산
    protected void LookAtTarget()
    {
        Vector3 direction = (controller.Player.transform.position - transform.position).normalized;

        // 회전 쿼터니언 계산
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // 부드럽게 회전
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * fsmInfo.LookAtMaxSpeed);
    }

    // 몬스터 상태 시작 메소드
    public virtual void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        // (임시) 애니메이션 재생 속도 보정
        animator.speed = animSpeed;
    }

    // 몬스터 상태 업데이트 추상 메소드
    public abstract void UpdateState();

    // 몬스터 상태 종료 추상 메소드
    public abstract void ExitState();

    protected virtual void NavigationStop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0f;
    }

    
}
