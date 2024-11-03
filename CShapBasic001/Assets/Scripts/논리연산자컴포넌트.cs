using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 논리연산자컴포넌트 : MonoBehaviour
{
    public int 버스카드잔액;   // 버스카드 잔액
    public int 나이;          // 탑승자 나이

    private bool 탑승가능여부 = false;

    // Start is called before the first frame update
    void Start()
    {
        // 자연어 기반의 조건
        // -> 현재 버스탑승 가능자는 (나이가 60세 이상)이거나 (버스카드 잔액이 1000원 이상)인 사람입니다.

        // 프로그래밍 언어기반의 버스탑승조건
        // -> 탑승가능여부 = (나이 >= 60) || (버스카드잔액 >= 1000);

        탑승가능여부 = (나이 >= 60) || (버스카드잔액 >= 1000);

        Debug.Log($"현재 탑승자의 탑승여부는 {탑승가능여부}입니다.");

    }
}
