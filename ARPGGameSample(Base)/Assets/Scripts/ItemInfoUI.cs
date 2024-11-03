using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 선택된 아이템 정보 표시 및 취급 처리 컴포넌트
public class ItemInfoUI : MonoBehaviour
{
    // 아이템 이름 출력 텍스트
    [SerializeField] private Text itemNameText;
    // 아이템 설명 출력 텍스트
    [SerializeField] private Text itemDescriptionText;
    // 아이템 버튼 텍스트
    [SerializeField] private Text itemButtonText;

    private InventoryUI inventoryUI;
    private Item item;

    // 아이템 정보 출력하기
    public void ShowItemInfo(InventoryUI inventoryUI, Item item)
    {
        // 선택 아이템 설정
        this.inventoryUI = inventoryUI;
        this.item = item;   

        if(this.item.ItemType == EnumTypes.ITEM_TYPE.WP)
        {
            if(this.item.IsEquip)
            {
                itemButtonText.text = "해제하기";
            }
            else
            {
                itemButtonText.text = "착용하기";
            }
        }
        else
        {
            itemButtonText.text = "사용하기";
        }
        // 아이템 정보패널 활성화 및 아이템정보 출력
        gameObject.SetActive(true);
        itemNameText.text = $"{item.ItemName} [{(item.ItemCount > 0 ? item.ItemCount : "1")}]";
        itemDescriptionText.text = $"{item.ItemDescription}";
    }

    public void HideItemInfo()
    {
        gameObject.SetActive(false);
    }

    // 아이템 버리기 버튼 클릭
    public void OnRemoveItemButtonClick()
    {
        // Debug.Log($"{item.ItemName} 아이템 버리기 버튼 클릭");
        inventoryUI.RemoveItem(item);
    }

    // 아이템 사용하기 버튼 클릭
    public void OnUseItemButtonClick()
    {
        // Debug.Log($"{item.ItemName} 아이템 사용하기 버튼 클릭");

        // 이미 착용한 아이템의 경우
        if(item.IsEquip)
        {
            Debug.Log("아이템을 장착 해제함");
        }
        else // 소모성 아이템이거나 착용하지 않은 아이템의 경우
        {
            Debug.Log("아이템을 착용 또는 사용함");
            inventoryUI.UseItem(item);
        }
    }


}
