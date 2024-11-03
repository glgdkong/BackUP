using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 연산자

public class Operator : MonoBehaviour
{
    int a;
    int b = 1;


    // Start is called before the first frame update
    void Start()
    {
        // 대입 연산자 = : 오른쪽 값을 왼쪽에 할당함.
        a = 1;

        // a에 a + b의 값을 할당함.
        a = a + b;

        // a = a + b; 와 동일한 연산자, 보통 아래처럼 약자로 표시함
        a += b;

        // 증감 연산자 1씩 증가 또는, 1씩 감소
        a++;

        a--;

        // 관계형 연산자의 특징은 true or false의 값을 우리에게 준다.
        // 조건문에서 사용이 된다.
        // (a == b) a와 b가 같은지? true
        // (a != b) a와 b가 다른지? false

        // 논리 연산자
        // && And 연산자 : 조건A && 조건 B ==> 조건 A와 B 모두가 참이여야 true를 반환, 둘중 하나라도 거짓이면 false를 반환
        // || Or 연산자 : 조건 A || 조건 B ==> 조건 A와 B 둘 중 하나라도 참이면 true, 모두 거짓이면 false
        // ! Not 연산자 : 논리 부정 연산자 ==> 논리를 뒤집는다, true => false, false => true, ~가 아닌


    }
}
