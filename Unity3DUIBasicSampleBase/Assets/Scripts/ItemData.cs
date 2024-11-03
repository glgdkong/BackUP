using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ������ Ŭ����
public class ItemData
{
    // ������ Ÿ��
    private string type;
    // ������ �̸�
    private string itemName;
    // ������ ����
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
