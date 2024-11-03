using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeathState : MonsterState
{
    // ��� �Ϸ� ó�� �ð�
    protected float time;

    [SerializeField] protected float deathDelayTime;
    // �ǰ� ��ƼŬ ������Ʈ
    [SerializeField] protected ParticleSystem hitParticle;

    // ��� ó�� ����Ʈ
    [SerializeField] protected GameObject destroyParticlePrefab;

    // ��� ó�� ��ƼŬ ��ġ
    [SerializeField] protected Transform destroyParticleTr;

    // �ǰ� �˹� �ð�
    [SerializeField] protected float knockbackTime;
    // �ǰ� �˹� ��
    [SerializeField] protected float knockbackForce;

    // �˹� ó�� �ڷ�ƾ
    private IEnumerator ApplyDeathKnockback(Vector3 hitDirection, float force)
    {
        // �׺���̼� ����
        navMeshAgent.isStopped = true;

        // �˹� �̵� ó�� ����
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

        // �ǰ� ȿ�� ó��
        hitParticle.Play();

        // ��� �ִϸ��̼� ���
        animator.SetBool("Dead", true);

        // �˹� ������ ����
        float force = knockbackForce;
        if (data != null)
        {
            force = (float)data;
        }
        // �ǰ� �˹� ó�� �ڷ�ƾ ����
        StartCoroutine(ApplyDeathKnockback(-transform.forward, force));


    }
    public override void ExitState()
    {
        // ���Ͱ� �Ҹ��
        Instantiate(destroyParticlePrefab, destroyParticleTr.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public override void UpdateState()
    {
        time += Time.deltaTime;

        // ��� ó�� �����ð��� �����ٸ�
        if (time >= deathDelayTime)
        {
            ExitState();
        }
    }
}
