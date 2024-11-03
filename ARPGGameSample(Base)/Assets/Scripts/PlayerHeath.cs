using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : CharacterHeath
{
    protected override void Start()
    {
    }
    public void HpUp(int UpValue)
    {
        currentHp += UpValue;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
    }
}
