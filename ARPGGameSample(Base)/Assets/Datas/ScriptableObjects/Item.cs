using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 스크립터블 오브젝트
public abstract class Item : ScriptableObject
{
    // 아이템 타입 
    [SerializeField] protected EnumTypes.ITEM_TYPE iTEM_TYPE;
    // 아이템 아이디
    [SerializeField] protected int itemId;
    // 아이템 이름
    [SerializeField] protected string itemName;
    // 아이템 설명
    [SerializeField] protected string itemDescription;
    // 아이템 아이콘 이미지
    [SerializeField] protected Sprite itemIconImage;
    // 아이템 가격
    [SerializeField] protected int itemPrice;
    // 아이템 갯수
    [SerializeField] protected int itemCount;
    // 아이템 착용
    [SerializeField] protected bool isEquip;


    public EnumTypes.ITEM_TYPE ItemType { get => iTEM_TYPE; set => iTEM_TYPE = value; }
    public int ItemId { get => itemId; set => itemId = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public string ItemDescription { get => itemDescription; set => itemDescription = value; }
    public Sprite ItemIconImage { get => itemIconImage; set => itemIconImage = value; }
    public int ItemPrice { get => itemPrice; set => itemPrice = value; }
    public int ItemCount { get => itemCount; set => itemCount = value; }
    public bool IsEquip { get => isEquip; set => isEquip = value; }

    // 아이템 복제
    public Item Clone()
    {
        // 현재 스크립터블 오브젝트의 인스턴스를 복제하여 새로운 인스턴스를 생성
        Item newItem = Instantiate(this);
        return newItem;
    }
}
