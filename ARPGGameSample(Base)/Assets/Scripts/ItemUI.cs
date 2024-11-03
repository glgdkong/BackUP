using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 아이템 썸네일 표시 컴포넌트
public class ItemUI : MonoBehaviour
{
    // 아이템 배경 이미지
    [SerializeField] private Image itemBackgroundImage;
    // 아이템 이미지
    [SerializeField] private Image itemImage;
    // 아이템 흭득 객수
    [SerializeField] private Text itemCountText;
    // 아이템 카운트 표시 백그라운드
    [SerializeField] private GameObject itemCountBackground;
    // 아이템 장착 표시 백그라운드
    [SerializeField] private GameObject itemEquipBackground;
    // 인벤토리 UI
    private InventoryUI inventoryUI;

    // 아이템 정보
    private Item item = null;
    // 아이템 선택 여부
    [SerializeField] private bool isSelected = false;
    [SerializeField] private Color32 selectColor;
    [SerializeField] private Color32 deSelectColor;

    // 인벤토리 슬롯 초기화
    public void Init(InventoryUI inventoryUI)
    {
        this.inventoryUI = inventoryUI;
    }

    // 아이템 표시 UI설정
    public void Show(Item item)
    {
        // 아이템 참조
        this.item = item;

        // 아이템 아이콘 설정
        itemImage.sprite = this.item.ItemIconImage;

        // 소모성 아이템의 경우 아이템 갯수 표시
        if (this.item.ItemCount > 0)
        {
            itemCountBackground.SetActive(true);
            itemCountText.text = this.item.ItemCount.ToString();
        }
        // 장비 장착/ 장착해제 처리
    }

    // 아이템 정보 초기화
    public void ClearItemUI()
    {

        // 아이템 썸네일 정보를 초기화 함
        item = null;    // 아이템 데이터 초기화
        itemBackgroundImage.color = deSelectColor; // 아이템 백그라운드 색상 초기화
        itemImage.sprite = null; // 아이템 스프라이트 이미지 초기화
        itemCountBackground.SetActive(false); // 아이템 갯수 백그라운드 비활성화
        itemCountText.text = "0"; // 아이템 카운트 텍스트 초기화
    }

    // 아이템 선택 처리 
    public void ItemSelect()
    {
        // 아이템이 설정되지 않았다면 패쓰
        if (item == null)
        {
            // 이전 선택 아이템의 선택 상태를 해제함
            inventoryUI?.ItemAllDeSelect();
            return;
        }

        // 선택한 아이템 정보를 인벤토리 아래쪽에 출력함
        inventoryUI.ItemSelect(item);

        // 선택이 안된 상태면
        if (!isSelected)
        {
            // 아이템 선택된 상태로 색상을 표시함
            itemBackgroundImage.color = selectColor;
            Debug.Log("아이템 선택을 처리함");
            isSelected = true;
        }
    }

    // 아이템 선택 해제
    public void ItemDeSelect()
    {
        // 이미 선택된 상황이면
        if (isSelected)
        {
            // 아이템이 선택 해제된 상태로 색상을 표시함
            itemBackgroundImage.color = deSelectColor;
            Debug.Log("아이템 선택을 해제함");
            isSelected = false;
        }
    }
}
