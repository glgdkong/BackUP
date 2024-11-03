using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * 큐(자료구조)
// - 선입선출(FIFO) 방식의 콜렉션으로 데이터의 요소를 추가하고 가장 먼저 추가된 요소부터 추출하는 방식의 자료구조이다.

public class QueueAPITest : MonoBehaviour
{
    // 문자열 큐 생성
    private Queue<string> strQueue = new Queue<string>();

    void Start()
    {
        // 큐에 문자열 데이터 추가 (선입)
        strQueue.Enqueue("물풍선");
        strQueue.Enqueue("바나나");
        strQueue.Enqueue("미사일");
        strQueue.Enqueue("얼음벽");
        strQueue.Enqueue("우주선");

        // 큐에서 데이터 탐색  (시간복잡도 O(n) => 요소가 많아질수록 성능이 떨어짐)
        Debug.Log($"큐안에는 미사일이 있는가? {strQueue.Contains("미사일")}");
        Debug.Log($"큐안에는 하트생명이 있는가? {strQueue.Contains("하트생명")}");

        // 큐에 추가된 아이템 갯수 확인
        Debug.Log($"큐에 추가한 아이템 갯수 : {strQueue.Count}");

        // 큐에서 문자열 데이터 추출 (선출)
        string itemName = strQueue.Dequeue();
        Debug.Log($"큐에서 추출한 아이템 이름 : {itemName}");

        // * Dequeue()랑 Peek의 차이
        // - Dequeue는 추출시 큐에서 데이터를 소진함
        // - Peek는 추출시 큐에서 데이터를 소진하지 않음 (확인용)
        if (strQueue.Count > 0 )
        Debug.Log($"큐에 추출할 아이템 확인 : {strQueue.Peek()}");

        itemName = strQueue.Dequeue();
        Debug.Log($"큐에서 추출한 아이템 이름 : {itemName}");


        // 큐에 저장된 전체 목록 조회
        // * foreach (단일요소타입 변수 in 목록컬렉션또는 배열) {... 반복코드진행 ...}
        // - 반복을 진행하면서 목록컬렉션또는배열의 요소를 하나씩 꺼내면서 순차적으로 접근할 수 있는 일종의 반복문
        foreach (string name in strQueue)
        {
            Debug.Log($"큐에서 저장된 아이템 요소 이름 : {name}");
        }

        // 전체 목록 순회를 위해 큐를 배열로 전환
        string[] strArray = strQueue.ToArray();
        for (int i = 0; i < strArray.Length; i++) 
        {
            Debug.Log($"큐(배열)에서 저장된 아이템 요소 이름 : {strArray[i]}");
        }

        Debug.Log("큐 비우기 실행");
        // 큐 안에 모든 데이터를 제거함
        strQueue.Clear();
        Debug.Log($"큐에 추가한 아이템 갯수 : {strQueue.Count}");
    }
}
