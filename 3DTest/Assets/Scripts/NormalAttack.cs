using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : MeleeAttack
{
    // �Ϲ� ���� �ִϸ��̼� �̺�Ʈ �޼ҵ�
    public void MeleeAttackAniamtionEvent()
    {
        // ���� Ÿ�ٵ� ���� ó��
        RangeAngleTargetAttack();
    }
}
