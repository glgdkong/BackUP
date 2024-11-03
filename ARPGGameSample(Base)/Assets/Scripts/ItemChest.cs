using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    // ������ ����
    [SerializeField] private ItemInfo itemInfo;
    // ���� ���� ������ ���̵� ����
    [SerializeField] private Vector2 idWPRange;
    // ���� �Ҹ� ������ ���̵� ����
    [SerializeField] private Vector2 idCBRange;

    public ItemInfo ItemInfo { get => itemInfo; set => itemInfo = value; }

    private void Awake()
    {
        // ������ ������(��� or �Ҹ�) �� ������ ������
        EnumTypes.ITEM_TYPE itemType = (EnumTypes.ITEM_TYPE)Random.Range(0,2);
        int itemId = 0;

        switch (itemType)
        {
            case EnumTypes.ITEM_TYPE.WP:
                itemId = Random.Range((int)idWPRange.x, (int)idWPRange.y);
                break;
            case EnumTypes.ITEM_TYPE.CB:
                itemId = Random.Range((int)idCBRange.x, (int)idCBRange.y);
                break;
            default:
                break;
        }
        
        Init(itemType, itemId);
    }

    // ������ ���� ���� ����
    public void Init(EnumTypes.ITEM_TYPE itemType, int ItemId)
    { 
        // ���� ������ ���̵� �� Ÿ�� ���� 
        itemInfo.ItemId = ItemId;
        itemInfo.ItemType = itemType;
    }

}
