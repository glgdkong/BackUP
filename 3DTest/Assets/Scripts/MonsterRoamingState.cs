using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterRoamingState : MonsterState
{
    // ��ȸ ��ġ ���ӿ�����Ʈ ����
    protected Transform targetTransform = null;

    // ��ȸ ������ 
    public Vector3 targetPosition = Vector3.positiveInfinity;

    // ��ȸ�� ��ġ�� ���Ͱ��� �Ÿ�
    public float targetDistance = Mathf.Infinity;

    // ��ȸ ���� ����
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        // ��ȸ �ִϸ��̼� ���
        animator.SetInteger("State", (int)state);
    }

    public override void ExitState()
    {
        // �׺���̼� �̵� ����
        NavigationStop();

        // ��ȸ ���� ��ġ ������ �ʱ�ȭ
        targetTransform = null;
        targetPosition = Vector3.positiveInfinity;
        targetDistance = Mathf.Infinity;
    }

    public override void UpdateState()
    {
        // �÷��̾ ���� ���� �Ÿ��ȿ� ������
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance && !pHp.IsDeath)
        {
            // ���� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }
        // �÷��̾ ���� ���� �Ÿ��ȿ� ������
        if (controller.GetPlayerDistance() <= fsmInfo.DetectDistance && !pHp.IsDeath)
        {
            // ���� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }

        if (targetTransform != null)
        {
            // ��ȸ�� ��ġ ��ó�� ���� �ߴٸ�
            targetDistance = Vector3.Distance(transform.position, targetPosition);
            if(targetDistance < 1f)
            {
                controller.TransactionToState(MonsterFSMController.STATE.IDLE);
            }
        }
    }

    // ���ο� ��ȸ ��ġ�� Ž����
    protected virtual void NewRandomDestination(bool retry)
    {
        // ��ȸ �ε��� ��÷
        int index = Random.Range(0, fsmInfo.WanderPoints.Length);

        // ���� ��ȸ ��ġ�� Ž�� �ߴٸ� �ٽ� Ž��
        float distance = Vector3.Distance(fsmInfo.WanderPoints[index].position, transform.position);
        if (distance < fsmInfo.NextPointSelectDistance && retry)
        {
            NewRandomDestination(true);
            return;
        }

        // ��ȸ ��ġ�� ����
        targetTransform = fsmInfo.WanderPoints[index];

        // ��ȸ ��ġ�� ���������� ���� ���� ���� ������ ��ġ�� �缱��
        Vector3 randomDirection = Random.insideUnitSphere * fsmInfo.NextPointSelectDistance;
        randomDirection += fsmInfo.WanderPoints[index].position;
        randomDirection.y = fsmInfo.WanderPoints[index].position.y;

        // ���� ��÷�� ��ȸ ��ġ�� �׺���̼� ������Ʈ �̵� �ӵ��� ����
        targetPosition = randomDirection;

        // �׺���̼��̵��� ��ȿ �ϴٸ�
        NavMeshHit hit;

        // ���� ���� ������ ����Ʈ ���� �� �� �ִ� �������� Ȯ��
        if (NavMesh.SamplePosition(randomDirection, out hit, fsmInfo.WanderNavCheckRadius, NavMesh.AllAreas))
        { 
            navMeshAgent.isStopped = false;
            navMeshAgent.speed = fsmInfo.WanderMoveSpeed;
            navMeshAgent.SetDestination(targetPosition);
        }
    }
}
