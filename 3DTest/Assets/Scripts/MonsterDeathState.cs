using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeathState : MonsterState
{
    // 사망 완료 처리 시간
    protected float time;

    [SerializeField] protected float deathDelayTime;
    // 피격 파티클 컴포넌트
    [SerializeField] protected ParticleSystem hitParticle;

    // 사망 처리 이펙트
    [SerializeField] protected GameObject destroyParticlePrefab;

    // 사망 처리 파티클 위치
    [SerializeField] protected Transform destroyParticleTr;

    // 피격 넉백 시간
    [SerializeField] protected float knockbackTime;
    // 피격 넉백 힘
    [SerializeField] protected float knockbackForce;

    // 넉백 처리 코루틴
    private IEnumerator ApplyDeathKnockback(Vector3 hitDirection, float force)
    {
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
    }

    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state);

        // 피격 효과 처리
        hitParticle.Play();

        // 사망 애니메이션 재생
        animator.SetBool("Dead", true);

        // 넉백 사이즈 설정
        float force = knockbackForce;
        if (data != null)
        {
            force = (float)data;
        }
        // 피격 넉백 처리 코루틴 생성
        StartCoroutine(ApplyDeathKnockback(-transform.forward, force));


    }
    public override void ExitState()
    {
        // 몬스터가 소멸된
        Instantiate(destroyParticlePrefab, destroyParticleTr.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public override void UpdateState()
    {
        time += Time.deltaTime;

        // 사망 처리 지연시간이 지났다면
        if (time >= deathDelayTime)
        {
            ExitState();
        }
    }
}
