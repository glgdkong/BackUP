using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 반복문컴포넌트 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 반복문의 종류

        // while
        // [문법]
        // 인덱스변수 초기화
        // while(반복조건식의결과) // 반복조건식의결과 : 참일 경우 반복 블록이 실행되고 거짓일 경우 반복 블록을 빠져나감
        // { // 반복 블록 시작
        //      반복 내용 (반복적으로 실행할 코드블록)
        //      인덱스변수 증가
        // } // 반복 블록 끝
        // * while문 필수문법 -> while(반복조건식의결과) {...반복내용...}

        /*Debug.Log("반복 시작");
        while (false)
        {
            Debug.Log("반복 내용 출력");
        }
        Debug.Log("반복 종료");*/
        //-------------------------------------
        /*Debug.Log("반복 시작");
        
        bool 반복조건변수 = true;
        while (반복조건변수) // ---> 반복조건이 거짓이면 반복블록 밖으로
        {
            Debug.Log("반복 내용 출력");
            반복조건변수 = false;
        } // ----> 반복 조건으로

        Debug.Log("반복 종료");*/
        //-------------------------------------
        /*Debug.Log("반복 시작");

        int 번째 = 0;
        bool 반복조건변수 = true;
        while (반복조건변수) // ---> 반복조건이 거짓이면 반복블록 밖으로
        {
            번째++;

            Debug.Log($"반복 내용 출력 [번째 : {번째}]");
            if (번째 >= 5) // 조건식 : 반복을 종료하고자 하는 조건식 -> 거꾸로 생각하면 반복조건
            {
                반복조건변수 = false;
            }
        }// ----> 반복 조건으로
        Debug.Log("반복 종료");*/
        //-------------------------------------
        /*Debug.Log("반복 시작");
        int 번째 = 0;
        while (번째 < 5) // 번째가 5보다 작은 동안 반복 실행
        {
            Debug.Log($"반복 내용 출력 [번째 : {번째 + 1}]");

            번째++;
        }
        Debug.Log("반복 종료");*/
        //-------------------------------------

        // *for문 (결과적으로 while문과 동일한 반복문)
        // [문법]
        // for(인덱스변수 초기화; 반복조건식의결과; 인덱스변수 증가)
        // { // 반복 블록 시작
        //      반복 내용 (반복적으로 실행할 코드블록)
        // } // 반복 블록 끝
        // * for문 필수문법 -> for(;반복조건식의결과;)  {...반복내용...}

        /*Debug.Log("반복 시작");
        for (;false;)
        {
            Debug.Log("반복 내용 출력");
        }
        Debug.Log("반복 종료");*/
        //-------------------------------------
        /*Debug.Log("반복 시작");
        bool 반복조건변수 = true;
        for (;반복조건변수;)
        {
            Debug.Log("반복 내용 출력");
            반복조건변수 = false;
        }
        Debug.Log("반복 종료");*/
        //-------------------------------------
        /*Debug.Log("반복 시작");
        int 번째 = 0;
        for (bool 반복조건변수 = true; 반복조건변수;) 
        {
            번째++;

            Debug.Log($"반복 내용 출력 [번째 : {번째}]");
            if (번째 >= 5) 
            {
                반복조건변수 = false;
            }
        }// ----> 반복 조건으로
        Debug.Log("반복 종료");*/
        //-------------------------------------
        // [숙제] 아래 while문을 for문으로 변경해 보세요.
        /*Debug.Log("반복 시작");

        for (int 번째 = 1; 번째 <= 5; 번째++) // 번째가 5보다 작은 동안 반복 실행
        {
            Debug.Log($"반복 내용 출력 [번째 : {번째}]");
        }
        Debug.Log("반복 종료");*/
        //-------------------------------------
        // do while
        /*Debug.Log("반복 시작");
        do
        {
            Debug.Log($"반복 내용 출력");
        }
        while (false); // 반복 조건 : 거짓
        Debug.Log("반복 종료");*/

        // 퀴즈
        // 3 * 1 부터
        /*Debug.Log($"구구단 출력");
        for (int i = 1; i <= 9; i++)
        {
            Debug.Log($"3 * {i} = {3 * i}");
        }*/
        /*int j = 0;
        while (j < 9)
        {
            
            Debug.Log($"3 * {j + 1} = {3 * (j + 1)}");
            j++;
        }*/
        /*int[] results = new int[7];*/
        /*for (int i = 3; i <= 9; i++)
        {   
            Debug.Log("=================================");
            for (int j = 1; j <= 9; j++)
            {
                int value = j * i;
                results[i - 3] += value;
                Debug.Log($"{i} * {j} = {value}");
            }
        }*/
        /*for (int k = 0; k < results.Length; k++)
        {
            Debug.Log(results[k]);
        }*/

        /*for (int i = 1; i < 10; i++)
        {
            // continue : continue 키워드를 기준으로 현재 반복은 중단하고 다음 반복을 수행하도록 하는 키워드
            if (i % 2 == 0) // 짝수조건
            {
                continue;
            }

            int value = 3 * i;
            Debug.Log($"3 * {i} = {value}");

        }*/
        /*int i = 1;
        while (1 < 10)
        {
            if (i%2 == 0)
            {
                i++;
                continue; 
            }
            int value = 3 * i;
            Debug.Log($"3 * {i} = {value}");
            i++;
        }*/

        //1~10 까지 랜덤한 숫자를 반복적으로 더한 후의 결과가 300보다 커지면 
        // 더이상 누적 합계를 수행하지 않는 반복문을 만들어 보세요
        // 출력은 합계가 수행될때마다 출력하고 누적연산이 몇번 이루어졌는지 번째를 출력하세요

        // 예
        // [1] 10
        // [2] 15
        // [3] 20
        // ...
        // [15] 293
        /*int i = 0;
        int j = 1;  
        while(i < 300)
        {
            int randomNum = Random.Range(0, 11);
            i += randomNum;
            Debug.Log($"[{j}] {i} [랜덤 번호: {randomNum}]");
            j++;
        }*/
        /*for (int i = 0, j = 0, randomNum = Random.Range(0, 11); j < 300; j += randomNum, i++)
        {
            randomNum = Random.Range(0, 11);
            Debug.Log($"[{i}] {j} [랜덤 번호: {randomNum}]");
        }*/
        /*int resultNum = 0;
        int countNum = 1;
        while (true)
        {
            int randomNum = Random.Range(0, 11);
            resultNum += randomNum;
            if (resultNum > 300)
            { 
                // * break : break 키워드는 현재 반복을 완전히 중단하는 키워드로 해당 break키워드를 실행하는 순간 현재 반복문을 빠져나옴
                break;
            }
            Debug.Log($"[{countNum}] {resultNum} [랜덤 번호: {randomNum}]");
            countNum++;
        }
*/

        //
        /*for (int i = 0; i < 5; i++)
        {
            Debug.Log("=============================================");
            int j = 10;
            while (j <= 100)
            {
                Debug.Log($"i:{i}, j:{j}");
                j += 10;
            }
        }*/
        // [과제 1]
        // 3단 ~ 9단

        // [과제2]
        // 구구단 3 ~ 9단까지 출력하되 
        // 홀수단의 경우에는 홀수 값만 
        // 짝수단의 경우에는 짝수 값만 곱하여 출력하는 구구단을 작성하세요
        // for, while문을 모두 사용하고 분기문(continue, break)도 필요하다면 활용하세요.

        // 예)
        // [3단]-----------------------------
        // 3 * 1 = 3
        // 3 * 3 = 9
        // .......
        // 3 * 9 = 27
        // [4단]-----------------------------
        // 4 * 2 = 8
        // 4 * 4 = 16
        // .......
        // 4 * 8 = 32
        /**/for (int i = 3;i < 10;i++)
        {
            Debug.Log($"[{i}]단---------------------------");
            int j = 1;
            while ( j < 10 )
            {
                
                if(i%2 == 0 && j%2 == 0)
                {
                    int result = i * j;
                    Debug.Log($"{i} * {j} = {result}");
                }
                else if(i%2 != 0 && j%2 != 0) 
                {
                    int result = i * j;
                    Debug.Log($"{i} * {j} = {result}");
                }

                j++;
            }
        }

    }
}
