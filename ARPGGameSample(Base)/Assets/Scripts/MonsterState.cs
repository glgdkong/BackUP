using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 몬스터 상태 추상 클래스
public abstract class MonsterState : MonoBehaviour
{
    // 몬스터 유한상태기계 컨트롤러
    protected MonsterFSMController controller;

    // 애니메이터 컴포넌트
    protected Animator animator;

    // 네비게이션 컴포넌트
    protected NavMeshAgent navMeshAgent;

    protected MonsterFSMInfo fsmInfo; // 상태 정보

    [Range(1f, 2f)]
    [SerializeField] protected float animSpeed; // 애니메이션 재생 속도

    protected virtual void Awake()
    {
        controller = GetComponent<MonsterFSMController>();
        animator = GetComponent<Animator>();    
        navMeshAgent = GetComponent<NavMeshAgent>();
        fsmInfo = GetComponent<MonsterFSMInfo>();
    }

    // 몬스터 상태 관련 인터페이스(문법인터페이스 아님) 메소드 선언

    // 몬스터 상태 시작(다른상태에서 전이됨) 메소드
    public virtual void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        animator.speed = animSpeed; // (임시) 애니메이션 속도 보정
    }

    // 몬스터 상태 업데이트 추상 메소드 (상태 동작 수행)
    public abstract void UpdateState();

    // 몬스터 상태 종료(다릉 상태로 전이됨) 추상 메소드
    public abstract void ExitState();

    protected virtual void NavigationStop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0f;
    }


}
