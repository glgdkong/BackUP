using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remainder : MonoBehaviour
{
    private int a;
    private int b;

    public int inputNumber;

    // Start is called before the first frame update
    void Start()
    {
        a = 10;
        b = 2;

        // % 나머지 연산자 : a를 B로 나누고 난 [나머지 값]
        // 더 큰 수로 나누려고 하면 나눌 수 없기 때문에 고스란히 값이 나머지로 남는다.
        int c = a % b;

        // 어떤 수x를 5로 나머지 연산할 때 나올 수 있는 경우의 수
        // 0 ~ 4 (0부터 나누려고 하는 수 -1 까지의 범위)

        // 어떤 수를 10으로 나머지 연산할 때 나올 수 있는 경우의 수
        // 0 ~ 9

        // 어떤 수를 1억으로 나머지 연산할 때 나올 수 있는 경우의 수
        // 0 ~ 99,999,999

        // if () 괄호 안의 식이 참이면 코드를 실행하고, 거짓이면 싱행하지 않습니다.
        if (inputNumber % 2 == 0)
        {
            Debug.Log("2의 배수, 짝수");
        }
    }

}
