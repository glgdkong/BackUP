using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� ���� ó�� ������Ʈ
public class MonsterIdleState : MonsterState
{
    [SerializeField] protected float time; // �ð� ����
    [SerializeField] protected float checkTime; // ��� üũ �ð�
    [SerializeField] protected Vector2 checkTimeRange; // ��� üũ �ð�(�ּ�, �ִ�)

    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        // ���� üũ �ֱ� �ð��� ��÷��
        time = 0f;
        checkTime = Random.Range(checkTimeRange.x, checkTimeRange.y);

        NavigationStop();

        // ��� �ִϸ��̼� ���
        animator.SetInteger("State", (int)state);
    }

    public override void ExitState()
    {
        time = 0f;
    }

    public override void UpdateState()
    {
        time += Time.deltaTime; // ���ð� ���

        // �÷��̾ ���� ���� �Ÿ��ȿ� ������
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance && time > fsmInfo.AttackSpeed && !pHp.IsDeath)
        {
            // ���� ����� �ٶ�
            LookAtTarget();
            // ���� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }
        // �÷��̾ ���� ���� �Ÿ��ȿ� ������
        if (controller.GetPlayerDistance() <= fsmInfo.DetectDistance && controller.GetPlayerDistance() > fsmInfo.AttackDistance && !pHp.IsDeath)
        {
            // ���� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }

        // ��� ���°� �����ٸ�
        if (time > checkTime)
        {
            int selectState = Random.Range(0, 2); // ��� ��ȸ���� ��÷
            switch (selectState)
            {
                case 0:
                    // ��� ���� ����
                    time = 0f;
                    checkTime = Random.Range(checkTimeRange.x, checkTimeRange.y);
                    break;
                case 1:
                    controller.TransactionToState(MonsterFSMController.STATE.WANDER);
                    break;
            }
        }
        
    }
}
