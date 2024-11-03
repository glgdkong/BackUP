using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeath : MonoBehaviour
{
    // 최대 체력
    [SerializeField] protected int maxHp;

    // 현재 체력
    [SerializeField] protected int currentHp;

    public int CurrentHp { get => currentHp; set => currentHp = value; }
    
    protected virtual void Start()
    {
        currentHp = maxHp;
    }




}
