using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� ���� ó�� ������Ʈ
public class MonsterAttackState : MonsterState
{
   protected void LookAtTarget()
   {
        

        // ���� ����� ���� ������ ���
        Vector3 direction = (controller.Player.transform.position - transform.position).normalized;
        // transform.LookAt(transform.positon + direction)

        // ȸ�� ���ʹϾ� ���
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f , direction.z));

        // �ε巴�� ȸ��
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * fsmInfo.LookAtMaxSpeed);
   }

    // ���� ���� ����
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        // ������ ���� �̵� ����
        NavigationStop();
        // ���� ���� �ִϸ��̼� ���
        animator.SetInteger("State", (int)state);
    }

    public override void ExitState()
    {

    }
    // ���� ���� ����
    public override void UpdateState()
    {
        // ���� ����� ���� ���� �Ÿ����� �־����ٸ�
        if (controller.GetPlayerDistance() > fsmInfo.AttackDistance) 
        {
            // ��ȸ ��ġ�� ����
            controller.TransactionToState(MonsterFSMController.STATE.GIVEUP);
            return;
        }

        // ���� ����� �ֽ���
        LookAtTarget();

    }
}
