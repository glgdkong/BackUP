using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // ��Ӱ��迡���� ���ٰ����� ���� ������ : protected
    // ���͸� �����ϴ� �Ӽ�
    protected string Name;
    protected int hp;
    protected int level;
    protected float damage;
    protected int gold;

    //������ ������ ����ϴ� ���
    protected void MonsterInfo()
    {
        Debug.Log(name + " ü�� : " + hp);
        Debug.Log(name + " ���� : " + level);
        Debug.Log(name + " ������ : " + damage);
        Debug.Log(name + " ��� : " + gold);
    }

}
