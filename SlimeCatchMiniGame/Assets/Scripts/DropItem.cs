using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 슬라임 아이템 드랍기능 컴포넌트
public class DropItem : MonoBehaviour
{
    // 드랍 아이템 
    [SerializeField] private GameObject itemPrefab;

    // 아이템 드랍 메소드
    public void Drop()
    {
        // 확률 뽑기( 0 ~ 100 퍼센트)
        float randomPercent = Random.Range(0f, 100f);
        // 50프로 확률로
        if(randomPercent > 50f )
            // 아이템을 떨굼
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
    }
}
