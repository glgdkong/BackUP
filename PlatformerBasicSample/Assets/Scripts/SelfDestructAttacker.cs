using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �浹 ������ �ο� ���� ���ӿ�����Ʈ ������Ʈ
public class SelfDestructAttacker : Attacker
{
    // �Ҹ� ó�� �޼ҵ� ������
    public override void Disappear()
    {
        Destroy(gameObject);
    }

}
