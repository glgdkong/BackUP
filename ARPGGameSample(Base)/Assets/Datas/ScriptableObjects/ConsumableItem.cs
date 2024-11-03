using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")] // 스크립터블 오브젝트 생성 메뉴 정의
public class ConsumableItem : Item
{
    // 소모성 아이템 타입
    [SerializeField] protected EnumTypes.CB_TYPE cbType;

    // 아이템 수치
    [SerializeField] protected int upValue;

    public EnumTypes.CB_TYPE CbType { get => cbType; set => cbType = value; }
    public int UpValue { get => upValue; set => upValue = value; }

    public virtual void Consume() // 아이템 소모 처리 메소드
    {
        Debug.Log("소모성 아이템 기능을 실행함");
    }
}
