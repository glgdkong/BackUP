using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ϲ� ���� ���� ������Ʈ
public class NormalMeleeAttack : MeleeAttack
{
    // �Ϲ� ���� �ִϸ��̼� �ǰ� �̺�Ʈ
    public void MeleeAttackHitAnimationEvent()
    {
        // ���� Ÿ�ٵ� ���� ó��
        RangeAngleTargetAttack();
    }
}
