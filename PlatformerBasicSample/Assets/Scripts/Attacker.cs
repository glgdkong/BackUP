using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 충돌 데미지 부여 게임오브젝트 컴포넌트
public class Attacker : MonoBehaviour
{
    [SerializeField] protected int damage;
    public int Damage { get => damage; set => damage = value; }

    public virtual void Disappear() { }
}
