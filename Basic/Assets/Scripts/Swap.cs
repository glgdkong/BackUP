using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public int a;
    public int b;
    private void Start()
    {
        // a, b의 값을 서로 바꿔보세요
        Debug.Log($"a : {a}");
        Debug.Log($"b : {b}");
        int c = a;
        a = b;
        b = c;
        // swap 로직이 프로그래밍하면서 앞으로도 계속 나온다..
        // 지금있는 조건만으로 문제해결을 할 수 없을 때 새로운 변수를 고민해봐라.

        Debug.Log($"a : {a}");
        Debug.Log($"b : {b}");
    }
    // 1. 오늘 배운 개념들을 이용해서 
    // 본인 만의 class를 만들어 오세요.
    // 만든 사용자 정의 class가 의미가 있어야 합니다.
    // 논리적으로 구조가 맞아야 합니다.
    // 주제는 알아서 자유롭게
    
    // 2. Swap 풀어오세요
    // 양심껏 검색 금지.
}
