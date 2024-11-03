using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitAble
{
    public bool IsHit { get; set; }
    public bool IsDeath { get; set; }
    public void Hit(int damage, float knockbackForce);
}
