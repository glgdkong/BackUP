using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 데이터 클래스
public class ItemData
{
    // 아이템 타입
    private string type;
    // 아이템 이름
    private string itemName;
    // 아이템 가격
    private string itemPrice;

    public ItemData(string type, string itemName, string itemPrice)
    {
        Type = type;
        ItemName = itemName;
        ItemPrice = itemPrice;
    }

    public string Type { get => type; set => type = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public string ItemPrice { get => itemPrice; set => itemPrice = value; }
}
