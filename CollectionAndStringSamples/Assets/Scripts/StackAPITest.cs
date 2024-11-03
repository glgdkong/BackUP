using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * 스택(자료구조)
// - 후입선출(LIFO) 방식의 콜렉션으로 데이터의 요소를 추가하고 가장 최근에 추가된 요소부터 추출하는 방식의 자료구조이다.

public class StackAPITest : MonoBehaviour
{
    // 문자열 스택 생성
    private Stack<string> strStack = new Stack<string>();

    void Start()
    {
        // 스택에 문자열 데이터 추가 (선입)
        strStack.Push("물풍선");
        strStack.Push("바나나");
        strStack.Push("미사일");
        strStack.Push("얼음벽");
        strStack.Push("우주선");

        // 스택에서 데이터 탐색  (시간복잡도 O(n) => 요소가 많아질수록 성능이 떨어짐)
        Debug.Log($"스택안에는 미사일이 있는가? {strStack.Contains("미사일")}");
        Debug.Log($"스택안에는 하트생명이 있는가? {strStack.Contains("하트생명")}");

        // 스택에 추가된 아이템 갯수 확인
        Debug.Log($"스택에 추가한 아이템 갯수 : {strStack.Count}");

        // 스택에서 문자열 데이터 추출 (선출)
        string itemName = strStack.Pop();
        Debug.Log($"스택에서 추출한 아이템 이름 : {itemName}");

        // - Peek는 추출시 스택에서 데이터를 소진하지 않음 (확인용)
        if (strStack.Count > 0 )
        Debug.Log($"스택에서 추출할 아이템 확인 : {strStack.Peek()}");

        itemName = strStack.Pop();
        Debug.Log($"스택에서 추출한 아이템 이름 : {itemName}");


        // 스택에 저장된 전체 목록 조회
        foreach (string name in strStack)
        {
            Debug.Log($"스택에 저장된 아이템 요소 이름 : {name}");
        }

        // 전체 목록 순회를 위해 스택을 배열로 전환
        string[] strArray = strStack.ToArray();
        for (int i = 0; i < strArray.Length; i++) 
        {
            Debug.Log($"스택(배열)에 저장된 아이템 요소 이름 : {strArray[i]}");
        }

        Debug.Log("스택 비우기 실행");
        // 스택안에 모든 데이터를 제거함
        strStack.Clear();
        Debug.Log($"스택에 추가한 아이템 갯수 : {strStack.Count}");
    }
}
