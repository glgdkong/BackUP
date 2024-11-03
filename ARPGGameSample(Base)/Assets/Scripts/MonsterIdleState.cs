using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ��� ���� ó�� ������Ʈ
public class MonsterIdleState : MonsterState
{
    [SerializeField] protected float time; // �ð� ����

    [SerializeField] protected float checkTime; // ��� üũ �ð�

    [SerializeField] protected Vector2 checkTimeRange; // ��� üũ �ð�(�ּ�, �ִ�)


    public override void EnterState(MonsterFSMController.STATE state, object date = null)
    {
        base.EnterState(state);

        // ���� üũ �ֱ� �ð��� ��÷��
        time = 0;
        checkTime = Random.Range(checkTimeRange.x, checkTimeRange.y);

        NavigationStop();

        // ��� �ִϸ��̼� ���
        animator.SetInteger("State",(int)state);
    }

    public override void ExitState()
    {
        time = 0;
    }

    public override void UpdateState()
    {
        //Debug.Log("���� ���ʹ� Idle ������!!");
        time += Time.deltaTime; // ���ð� ���

        // �÷��̾ ���� ���� �Ÿ� �ȿ� ���Դٸ�
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance)
        {
            // ���� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }
        // �÷��̾ ���� ���� �Ÿ��ȿ� ���Դٸ�
        if(controller.GetPlayerDistance() <= fsmInfo.DetectDistance)
        {
            // ���� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }
        // ��� ���°� �����ٸ�
        if(time > checkTime)
        {
            int selectState = Random.Range(0, 2); // ��� ��ȸ ���� ��÷
            switch (selectState)
            {
                case 0:
                    // �ٽ� ��� ���� ����
                    time = 0;
                    checkTime = Random.Range(checkTimeRange.x, checkTimeRange.y);
                    break;
                case 1:
                    // ��ȸ ���·� ��ȯ
                    controller.TransactionToState(MonsterFSMController.STATE.WANDER);
                    return;
            }
        }
    }
}
