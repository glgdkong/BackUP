using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

// Collection : 동일한 데이터타입을 여러 개 다룰 때 하나의 변수로 관리 하는 것.
// 컬렉션 : 컨테이너라고 합니다.
public class ArrayExample : MonoBehaviour
{
    int a = 0;
    int b = 1;
    int c = 2;

    // 배열 Array
    // 배열의 선언 : 접근제한자 데이터타입[] 변수명 = new 데이터타입[배열의 크기];
    // 배열은 프로그램의 시작부터 종료까지 변치않는 크기를 다률 때 사용합니다.
    // 즉 배열의 크기를 프로그램이 실행 중에 변경할 수 없습니다.

    // 정수 100개를 담는 배열을 선언
    public int[] numbers = new int[100];
    // 배열의 선언과 동시에 값을 할당
    public string[] names = { "강철웅", "이태언", "조성환", "남택연", "서원빈" };
    void Start()
    {
        // 배열의 원소에 접근 방법
        // 변수명[index]
        // 배열의 원소에 값을 할당 
        // index의 특징 : 프로그래밍에서 첫 번째는 0이다. => 계산의 효율성, 역사적 흐름 등등에 의해 0으로 정해짐
        numbers[0] = 1;  // 첫 번쨰
        numbers[99] = 1; // 100 번쨰

        // 어떠한 행위를 반복해서 하고 있다면, 반복문을 사용해보는 것을 고려해야 한다.
        // 배열.Length : 배열의 크기
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
            Debug.Log("numbers ["+ i +"] : " + numbers[i]);
        }
    }
}
