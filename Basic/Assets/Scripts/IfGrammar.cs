using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfGrammar : MonoBehaviour
{
    // 조건문 if : 괄호안의 조건이 참일때 중괄호 안의 코드를 실행.
    // if (조건) { 우리가 실행할 코드;}
    // 범위가 커다랄 때 사용.(스위치 케이스문으로 사용하기 까다로운 모든 경우에 if문을 고려해봐야 한다.)
    [SerializeField]
    private int inputNumber;
    [SerializeField]
    private int age;

    void Start()
    {
        // if문
        if (4 % 2 == 0)
        {
            Debug.Log("4를 2로 나누면 나머지가 0입니다.");
        }

        // if ~ else : 괄호 안의 조건이 참이면 if문의 중괄호를 실행, 괄호 안의 조건이 거짓이면 else문의 중괄호를 실행
        // else문은 if문의 가장 마지막 조건으로 사용이 가능하다.
        if (inputNumber % 2 == 0)
        {
            Debug.Log("짝수");
        }
        else // 중괄호 안의 조건이 아닌 그 밖의 상황
        {
            Debug.Log("홀수");
        }

        // inputNumber = 15;
        if (inputNumber % 3 == 0)
        {
            Debug.Log("3의 배수"); // 3의 배수를 만족하므로 코드 실행
        }
        if (inputNumber % 4 == 0)
        {
            Debug.Log("4의 배수");
        }
        if (inputNumber % 5 == 0)
        {
            Debug.Log("5의 배수"); // 5의 배수를 만족하므로 코드 실행
        }
        else
        {
            Debug.Log("3, 4, 5의 배수가 아님");
        }

        // if ~ else if 문 : 상위에서 조건에 만족한다면 코드를 끝낸다.
        // inputNumber = 15;
        if (inputNumber % 3 == 0)
        {
            Debug.Log("3의 배수"); // 3의 배수를 만족하므로 코드 실행하고 if else if 문을 끝낸다.
        }
        else if (inputNumber % 4 == 0)
        {
            Debug.Log("4의 배수");
        }
        else if (inputNumber % 5 == 0)
        {
            Debug.Log("5의 배수"); // 상위에서 조건에 만족하였으므로 코드를 실행하지 않음.
        }
        else
        {
            Debug.Log("3, 4, 5의 배수가 아님");
        }


        // 여러분이 코드를 만들어 보세요.
        // 10대면 학생, 20 ~ 50대면 성인, 둘 다 아니면 유아 또는 노인
        if (age >= 10 && age < 20)
        {
            Debug.Log("학생입니다.");
        }
        else if (age >= 20 && age < 60)
        {
            Debug.Log("성인입니다.");
        }
        else
        {
            Debug.Log("유아 또는 노인입니다.");
        }
    }
}
