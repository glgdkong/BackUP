using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ��ũ���ͺ� ������Ʈ
public abstract class Item : ScriptableObject
{
    // ������ Ÿ�� 
    [SerializeField] protected EnumTypes.ITEM_TYPE iTEM_TYPE;
    // ������ ���̵�
    [SerializeField] protected int itemId;
    // ������ �̸�
    [SerializeField] protected string itemName;
    // ������ ����
    [SerializeField] protected string itemDescription;
    // ������ ������ �̹���
    [SerializeField] protected Sprite itemIconImage;
    // ������ ����
    [SerializeField] protected int itemPrice;
    // ������ ����
    [SerializeField] protected int itemCount;
    // ������ ����
    [SerializeField] protected bool isEquip;


    public EnumTypes.ITEM_TYPE ItemType { get => iTEM_TYPE; set => iTEM_TYPE = value; }
    public int ItemId { get => itemId; set => itemId = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public string ItemDescription { get => itemDescription; set => itemDescription = value; }
    public Sprite ItemIconImage { get => itemIconImage; set => itemIconImage = value; }
    public int ItemPrice { get => itemPrice; set => itemPrice = value; }
    public int ItemCount { get => itemCount; set => itemCount = value; }
    public bool IsEquip { get => isEquip; set => isEquip = value; }

    // ������ ����
    public Item Clone()
    {
        // ���� ��ũ���ͺ� ������Ʈ�� �ν��Ͻ��� �����Ͽ� ���ο� �ν��Ͻ��� ����
        Item newItem = Instantiate(this);
        return newItem;
    }
}
