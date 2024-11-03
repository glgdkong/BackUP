using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 컴포넌트
public class Item : MonoBehaviour
{
    [SerializeField] private GameObject showItme; // 흭득할 아이템 게임오브젝트

    [SerializeField] private float showTime; // 아이템이 표시될 지연시간

    void Start()
    {
        // 아이템 지연 표시용 처리 코루틴 생성
        StartCoroutine(ShowDelayCoroutine());
    }

    // 아이템 지연 표시용 처리 코루틴
    IEnumerator ShowDelayCoroutine()
    {
        // 지연 객체 생성
        yield return new WaitForSeconds(showTime);
        // 아이템 활성화
        showItme.SetActive(true);
    }
}
