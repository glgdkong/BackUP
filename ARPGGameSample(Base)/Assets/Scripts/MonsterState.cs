using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// ���� ���� �߻� Ŭ����
public abstract class MonsterState : MonoBehaviour
{
    // ���� ���ѻ��±�� ��Ʈ�ѷ�
    protected MonsterFSMController controller;

    // �ִϸ����� ������Ʈ
    protected Animator animator;

    // �׺���̼� ������Ʈ
    protected NavMeshAgent navMeshAgent;

    protected MonsterFSMInfo fsmInfo; // ���� ����

    [Range(1f, 2f)]
    [SerializeField] protected float animSpeed; // �ִϸ��̼� ��� �ӵ�

    protected virtual void Awake()
    {
        controller = GetComponent<MonsterFSMController>();
        animator = GetComponent<Animator>();    
        navMeshAgent = GetComponent<NavMeshAgent>();
        fsmInfo = GetComponent<MonsterFSMInfo>();
    }

    // ���� ���� ���� �������̽�(�����������̽� �ƴ�) �޼ҵ� ����

    // ���� ���� ����(�ٸ����¿��� ���̵�) �޼ҵ�
    public virtual void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        animator.speed = animSpeed; // (�ӽ�) �ִϸ��̼� �ӵ� ����
    }

    // ���� ���� ������Ʈ �߻� �޼ҵ� (���� ���� ����)
    public abstract void UpdateState();

    // ���� ���� ����(�ٸ� ���·� ���̵�) �߻� �޼ҵ�
    public abstract void ExitState();

    protected virtual void NavigationStop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0f;
    }


}
