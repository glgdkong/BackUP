using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MonsterHitState : MonsterState
{
    // 피격 파티클 컴포넌트
    [SerializeField] protected ParticleSystem hitParticle;

    // 체력컴포넌트
    private MonsterHealth health;

    // 피격 넉백시간
    [SerializeField] protected float knockbackTime;
    // 피격 넉백 힘
    [SerializeField] protected float knockbackForce;
    protected override void Awake()
    {
        base.Awake();
        health = GetComponent<MonsterHealth>();
    }
    // 넉백 처리 코루틴
    private IEnumerator ApplyHitKnockback(Vector3 hitDirection, float force)
    {
        // 피격 상태 잠금
        health.IsHit = true;
        // 네비게이션 중지
        navMeshAgent.isStopped = true;

        // 넉백 이동 처리 진행
        float timer = 0f;

        while (timer < knockbackTime)
        {
            navMeshAgent.Move(hitDirection * force * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        // 네비게이션 재가동
        navMeshAgent.isStopped = false;
        // 피격 상태 해제
        health.IsHit = false;

    }
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        // 넉백 사이즈 설정
        float force = knockbackForce;
        if (data != null)
        {
            force = (float)data;
        }

        // 이동 중지
        navMeshAgent.isStopped = true;

        // 피격 효과 처리
        hitParticle.Play();

        // 피격 애니메이션 재생
        animator.SetInteger("State", (int)state);

        // 피격 넉백 처리 코루틴 생성
        StartCoroutine(ApplyHitKnockback(-transform.forward, force));

    }


    public override void ExitState()
    {
        health.IsHit = false;
    }

    public override void UpdateState()
    {
        if (health.IsHit) return;

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
    }
}
