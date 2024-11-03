using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterState : MonoBehaviour
{
    // ���� ���ѻ��±�� ��Ʈ�ѷ�
    protected MonsterFSMController controller;

    // �ִϸ����� ������Ʈ
    protected Animator animator;

    // �׺���̼� ������Ʈ
    protected NavMeshAgent navMeshAgent;

    // ���� ���� ����
    protected MonsterFSMInfo fsmInfo;

    // �÷��̾� ü�� ������Ʈ
    protected PlayerHealthController pHp;

    [Range(1f, 2f)]
    [SerializeField] protected float animSpeed; // �ִϸ��̼� ����ӵ�

    protected virtual void Awake()
    {
        controller = GetComponent<MonsterFSMController>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        fsmInfo = GetComponent<MonsterFSMInfo>();
        pHp = FindObjectOfType<PlayerHealthController>();
    }

    // ���� ����� ���� ������ ���
    protected void LookAtTarget()
    {
        Vector3 direction = (controller.Player.transform.position - transform.position).normalized;

        // ȸ�� ���ʹϾ� ���
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // �ε巴�� ȸ��
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * fsmInfo.LookAtMaxSpeed);
    }

    // ���� ���� ���� �޼ҵ�
    public virtual void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        // (�ӽ�) �ִϸ��̼� ��� �ӵ� ����
        animator.speed = animSpeed;
    }

    // ���� ���� ������Ʈ �߻� �޼ҵ�
    public abstract void UpdateState();

    // ���� ���� ���� �߻� �޼ҵ�
    public abstract void ExitState();

    protected virtual void NavigationStop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0f;
    }

    
}
