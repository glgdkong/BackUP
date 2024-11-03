using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForGrammar : MonoBehaviour
{
    // for문 (반복문)
    // for(초기 인덱스값 ; 조건문 ; 증감식) {}
    // 조건이 참이라면 {} 중괄호 코드영역을 실행하고 인덱스를 1증가시킨다.
    // 반복 횟수가 정해져있을 때 사용.
    void Start()
    {
        int sum = 0;
        // 1 ~ 100 까지 출력
        /*for (int i = 1; i <= 100; i++)
        {
            Debug.Log(i);
        }*/

        // 100부터 1까지 역출력 
        /*for (int i = 100; i >= 1; i--)
        {
            Debug.Log(i);
        }*/


        // 1부터 100 까지 수들의 합을 구하세요
        /*
        for (int i = 1; i <= 100; i++)
        {
            sum += i;
        }
        Debug.Log(sum);*/

        // 1 부터 100까지 수들 중 3의 배수들의 합
        /*for (int i = 1; i <= 100; i++)
        {
            if(i % 3 == 0)
            {
                sum += i;
            }
        }
        Debug.Log(sum);
        
        sum = 0;
        for (int i = 0; i <= 100; i += 3)
        {
            sum += i;
        }
        Debug.Log(sum);*/

        // 1 부터 100 까지 수들 중 3과 5의 배수들의 합
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }
        Debug.Log(sum);
    }
}
