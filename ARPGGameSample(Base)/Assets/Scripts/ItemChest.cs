using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    // 아이템 정보
    [SerializeField] private ItemInfo itemInfo;
    // 랜덤 무기 아이템 아이디 범위
    [SerializeField] private Vector2 idWPRange;
    // 랜덤 소모성 아이템 아이디 범위
    [SerializeField] private Vector2 idCBRange;

    public ItemInfo ItemInfo { get => itemInfo; set => itemInfo = value; }

    private void Awake()
    {
        // 랜덤한 아이템(장비 or 소모성) 을 정보를 설정함
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

    // 아이템 상자 정보 설정
    public void Init(EnumTypes.ITEM_TYPE itemType, int ItemId)
    { 
        // 랜덤 아이템 아이디 및 타입 설정 
        itemInfo.ItemId = ItemId;
        itemInfo.ItemType = itemType;
    }

}
