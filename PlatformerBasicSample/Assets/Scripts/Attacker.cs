using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �浹 ������ �ο� ���ӿ�����Ʈ ������Ʈ
public class Attacker : MonoBehaviour
{
    [SerializeField] protected int damage;
    public int Damage { get => damage; set => damage = value; }

    public virtual void Disappear() { }
}
