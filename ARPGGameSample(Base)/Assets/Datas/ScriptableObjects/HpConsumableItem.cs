using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 체력 증가 소모성 아이템
[CreateAssetMenu(fileName = "HpConsumableItem", menuName = "Item/HpConsumableItem")] // 스크립터블 오브젝트 생성 메뉴 정의
public class HpConsumableItem : ConsumableItem
{
    // 아이템을 사용함
    public override void Consume()
    {
        base.Consume();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerHeath>().HpUp(upValue);        
    }
}
