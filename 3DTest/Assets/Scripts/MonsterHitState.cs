using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MonsterHitState : MonsterState
{
    // �ǰ� ��ƼŬ ������Ʈ
    [SerializeField] protected ParticleSystem hitParticle;

    // ü��������Ʈ
    private MonsterHealth health;

    // �ǰ� �˹�ð�
    [SerializeField] protected float knockbackTime;
    // �ǰ� �˹� ��
    [SerializeField] protected float knockbackForce;
    protected override void Awake()
    {
        base.Awake();
        health = GetComponent<MonsterHealth>();
    }
    // �˹� ó�� �ڷ�ƾ
    private IEnumerator ApplyHitKnockback(Vector3 hitDirection, float force)
    {
        // �ǰ� ���� ���
        health.IsHit = true;
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

        // �׺���̼� �簡��
        navMeshAgent.isStopped = false;
        // �ǰ� ���� ����
        health.IsHit = false;

    }
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        // �˹� ������ ����
        float force = knockbackForce;
        if (data != null)
        {
            force = (float)data;
        }

        // �̵� ����
        navMeshAgent.isStopped = true;

        // �ǰ� ȿ�� ó��
        hitParticle.Play();

        // �ǰ� �ִϸ��̼� ���
        animator.SetInteger("State", (int)state);

        // �ǰ� �˹� ó�� �ڷ�ƾ ����
        StartCoroutine(ApplyHitKnockback(-transform.forward, force));

    }


    public override void ExitState()
    {
        health.IsHit = false;
    }

    public override void UpdateState()
    {
        if (health.IsHit) return;

        // �÷��̾ ���� ���� �Ÿ��ȿ� ������
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance)
        {
            // ���� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }
        // �÷��̾ ���� ���� �Ÿ��ȿ� ������
        if (controller.GetPlayerDistance() <= fsmInfo.DetectDistance)
        {
            // ���� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }
    }
}
