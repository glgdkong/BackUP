using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// 인벤토리 UI 관리
public class InventoryUI : MonoBehaviour
{
    // 아이템 슬롯 배열
    [SerializeField] private RectTransform[] itemUISlots;
    // 아이템 표시 UI 배열
    [SerializeField] private ItemUI[] itemUIs;
    // 아이템 표시 UI 프리펩
    [SerializeField] private GameObject itemUIPrefab;
    // 인벤토리 시스템 
    [SerializeField] private InventorySystem inventorySystem;

    // 아이템 정보 표시 UI 
    [SerializeField] private ItemInfoUI itemInfoUI;

    // 보유 아이템 갯수
    [SerializeField] private Text hasItemCountText;

    // 인벤토리 UI 초기화
    public void InitInventoryUI()
    {
        // 아이템 표시 UI들을 생성함
        itemUIs = new ItemUI[itemUISlots.Length];

        for (int i = 0; i < itemUISlots.Length; i++)
        {
            itemUIs[i] = Instantiate(itemUIPrefab, itemUISlots[i]).GetComponent<ItemUI>();
            itemUIs[i].Init(this); // 아이템 선택 이벤트 관련 참조 설정
        }

    }

    void Update()
    {
        // 아이템 갯수 출력
        hasItemCountText.text = $"[{inventorySystem.HasItemList.Count.ToString()}]";
    }

    // 아이템 버리기
    public void RemoveItem(Item item) 
    {
        // 아이템 표시 UI의 선택
        inventorySystem.RemoveItem(item);
    }

    // 모든 아이템 선택 상태를 해제함
    public void ItemAllDeSelect()
    {
        // 아이템 표시 UI의 선택 표기 상태를 새제함
        for (int i = 0;i < itemUISlots.Length;i++)
        {
            itemUIs[i].ItemDeSelect();
        }
        // 아이템 정보 패널을 숨김
        itemInfoUI.HideItemInfo();
    }

    // 인벤토리 아이템 선택
    public void ItemSelect(Item item) 
    { 
        // 모든 아이템 선택 상태를 해제함
        ItemAllDeSelect();

        // 선택한 아이템 정보를 표시함
        itemInfoUI.ShowItemInfo(this, item);
    }

    // 인벤토리 UI 업데이트
    public void UpdateInventoryUI()
    {
        // 인벤토리 아이템 UI 요소를 초기화함
        for (int i = 0; i < itemUISlots.Length; i++)
        {
            itemUIs[i].ClearItemUI();
        }

        // 흭득한 아이템 정보를 아이템 UI로 표시함
        for (int i = 0; i < inventorySystem.HasItemList.Count; i++) 
        {
            Item item = inventorySystem.HasItemList[i];
            itemUIs[i].Show(item);
        }

        // 선택 아이템 정보 표시 패널을 비활성화함
        itemInfoUI.HideItemInfo();
        // 아이템 선택 상태를 비활성화홤
        ItemAllDeSelect();
    }

    private void OnEnable()
    {
        // 취소 이벤트 델리게이트 메소드 등록
        GameManager.onCancelDelegate += OnCancel;
    }

    private void OnDisable()
    {
        // 취소 이벤트 델리게이트 메소드 등록 해제
        GameManager.onCancelDelegate -= OnCancel;
    }

    // 취소 이벤트 메소드
    public void OnCancel()
    {
        // 아이템 닫기 처리
        CloseUI();
    }

    // 인벤토리 UI 열기
    public void OpenUI()
    {
        // transform.parent : 현재 게임오브젝트의 부모 게임오브젝트의 Transform 참조
        // transform.root   : 현재 게임오브젝트의 최상위 게임오브젝트의 Transform 참조
        transform.parent.gameObject.SetActive(true);
    }
    // 인벤토리 UI 닫기 처리
    public void CloseUI()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void UseItem(Item item)
    {

        // 사용한 아이템이 무기 아이템이면
        if(item.ItemType == EnumTypes.ITEM_TYPE.WP)
        {
            // 아이템 장착 기능 수행
            return;
        }
        else // 사용한 아이템이 소모성 아이템이면
        {
            // 소모성 아이템의 갯수가 2개 이상이면
            if(item.ItemCount > 1)
            {
                Debug.Log($"{item.ItemName} 소모성 아이템 하나를 사용함");
                // 해당 아이템의 보유 갯수를 감소함
                item.ItemCount--;

                // 소모성 아이템 기능을 실행함
                ((ConsumableItem)item).Consume(); 

                UpdateInventoryUI();
                return;
            }
        }

        Debug.Log($"{item.ItemName} 마지막 소모성 아이템 하나를 사용함");
        ((ConsumableItem)item).Consume();
        // 착용 또는 소진항 아이템을 삭제함
        inventorySystem.RemoveItem(item);
    }


}
