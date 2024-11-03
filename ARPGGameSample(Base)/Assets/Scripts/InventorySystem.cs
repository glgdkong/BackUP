using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Linq 사용

public class InventorySystem : MonoBehaviour
{
    // 아이템 리스트(스크립터블 오브젝트) <------ 기준 아이템 정보(정적 아이템 데이터)
    [SerializeField] private ItemList[] itemLists;
    // 인벤토리 크기(슬롯 갯수)
    [SerializeField] private int inventorySize;

    // 흭득한 아이템 리스트 <----- 유저가 소유한 아이템 목록
    [SerializeField] private List<Item> hasItemList = new List<Item>();
    public List<Item> HasItemList { get => hasItemList; set => hasItemList = value; }

    // 인벤토리 UI
    [SerializeField] private InventoryUI inventoryUI;

    void Start()
    {
        /*//Debug.Log($"무기 아이템 목록 갯수 : {itemLists[(int)EnumTypes.ITEM_TYPE.WP].List.Count}");
        
        //foreach (Item item in itemLists[(int)EnumTypes.ITEM_TYPE.WP].List)
        //{
        //    Debug.Log($"{item.ItemName}");
        //}

        //Debug.Log($"소모성 아이템 목록 갯수 : {itemLists[(int)EnumTypes.ITEM_TYPE.CB].List.Count}");
        
        //foreach (Item item in itemLists[(int)EnumTypes.ITEM_TYPE.CB].List) 
        //{
        //    Debug.Log($"{item.ItemName}");
        //}
        
        //Debug.Log($"소유한 인벤토리 아이템 목록 갯수 : {hasItemList.Count}");*/

        // 인벤토리 UI 초기화
        inventoryUI.InitInventoryUI();
    }

    public bool AddItem(ItemInfo itemInfo)
    {
        // 흭득한 아이템이 무기 아이템이라면
        if (itemInfo.ItemType == EnumTypes.ITEM_TYPE.WP)
        {
            // 현재 인벤토리가 가득 찼다면
            if (HasItemList.Count >= inventorySize)
            {
                Debug.Log("인벤토리가 가득 찼음");

                // 인벤토리 아이템 추가 실패
                return false;
            }
            // 흭득한 아이템의 정보를 찾음
            Item item = itemLists[(int)EnumTypes.ITEM_TYPE.WP].List.FirstOrDefault(item => item.ItemId == itemInfo.ItemId).Clone();
            if (item != null)
            {
                Debug.Log($"{item.ItemName} 무기 아이템을 흭득함");

                // 흭득 아이템에 아이템 추가
                HasItemList.Add(item);
            }
        }
        // 흭득한 아이템이 소모성 아이템이라면
        else if (itemInfo.ItemType == EnumTypes.ITEM_TYPE.CB)
        {
            // 확보한 아이템이 존재하는지를 탐색함
            ConsumableItem hasItem = (ConsumableItem)HasItemList.FirstOrDefault(item => item.ItemId == itemInfo.ItemId);

            // 이미 해당 아이템을 흭득한 상태면
            if (hasItem != null)
            {
                Debug.Log($"[{hasItem.ItemName} 소모성 아이템을 추가 흭득함]");

                // 해당 아이템의 흭득 카운트를 증가함
                hasItem.ItemCount++;
            }
            else
            {
                // 현재 인벤토리가 가득 찼다면
                if (HasItemList.Count >= inventorySize) 
                {
                    Debug.Log("인벤토리가 가득 찼음");

                    // 인벤토리 아이템 추가 실패
                    return false;
                }

                // 흭득한 아이템의 정보를 찾음
                Item item = itemLists[(int)EnumTypes.ITEM_TYPE.CB].List.FirstOrDefault(item => item.ItemId == itemInfo.ItemId).Clone();
                if (item != null)
                {
                    Debug.Log($"{item.ItemName} 소모성 아이템을 흭득함");

                    // 흭득 아이템을 추가함
                    HasItemList.Add(item);
                }
            }
        }
        // 추가된 아이템에 대한 인벤토리 UI 갱신
        inventoryUI.UpdateInventoryUI();

        return true;
    }

    // 인벤토리 아이템 제거
    public void RemoveItem(Item item)
    {
        // 제거할 아이템을 보유하고 있으면
        if(HasItemList.Contains(item))
        {
            // 보유 아이템을 제거함
            HasItemList.Remove(item);
        }
        // 제거된 아이템에 대한 인벤토리 UI 갱신
        inventoryUI.UpdateInventoryUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.OpenUI();
        }
    }
}
