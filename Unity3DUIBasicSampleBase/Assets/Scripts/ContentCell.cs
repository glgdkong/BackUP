using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 아이템 정보 표시 셀 컴포넌트
public class ContentCell : MonoBehaviour
{
    // 타입 표시 텍스트
    [SerializeField] private Text typeText;
    // 아이템 네임 표시 텍스트
    [SerializeField] private Text itemNameText;
    // 아이템 가격 표시 텍스트
    [SerializeField] private Text itmePriceText;

    // 아이템 셀 표시 정보 초기화
    public void Init(ItemData itemData)
    {
        typeText.text = itemData.Type;
        itemNameText.text = itemData.ItemName;

        // 세자리 숫자 콤파 처리
        long number = long.Parse(itemData.ItemPrice);
        // N0 세자리마다 , 를 넣어준다
        itmePriceText.text = number.ToString("N0") + "원";
    }

    // 아이템 셀 삭제
    public void OnDeleteButtonClick()
    {
        Destroy(gameObject);
    }
}
