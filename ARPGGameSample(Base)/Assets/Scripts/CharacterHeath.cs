using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeath : MonoBehaviour
{
    // �ִ� ü��
    [SerializeField] protected int maxHp;

    // ���� ü��
    [SerializeField] protected int currentHp;

    public int CurrentHp { get => currentHp; set => currentHp = value; }
    
    protected virtual void Start()
    {
        currentHp = maxHp;
    }




}
