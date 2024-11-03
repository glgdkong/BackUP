using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using UnityEngine;

public class 배열컴포넌트 : MonoBehaviour
{
    // 정수형 배열
    int[] 정수형배열 = new int[10];
    // 정수형 배열[&(참조값)] --------> ({[0번쨰][0]}{[1번쨰][0]}{[2번쨰][0]}{[3번쨰][0]}{[4번쨰][0]})
    // {} <- 크기 : 정수형 크기, () 크기 : 정수형크기 * 갯수(5)

    // Start is called before the first frame update
    void Start()
    {
        //배열을사용하지않고10개의데이터입출력();
        //배열을사용해10개의데이터입출력();

        // 정수형배열 변수에 값을 저장하려면
        // 정수형배열[번째] = 값; ------> 번째는 변수값을 대체할 수 있음
        정수형배열[2] = 30;
        Debug.Log($"정수형배열[2] : {정수형배열[2]}");
        
        int 번째 = 2;
        정수형배열[번째] = 13;
        //string 문자열번째 = "2";
        //정수형배열[문자열번째] = 2; // 인덱스값은 무조건 반드시 기필코 양수값을 가진 정수형값이여야 함
        Debug.Log($"번째 변수값 : {번째}");
        Debug.Log($"정수형배열[번째] : {정수형배열[번째]}");
        // * 번째자리에 변수를 넣을 수 있다면 번째를 순차적으로 변경하면서 처리할 수 있는 반복문과 자주 사용함
        for (번째 = 0; 번째 < 정수형배열.Length; 번째++)
        {
            정수형배열[번째] = Random.Range(1, 51);
        }

        // [문제1] 위에서 저장한 10개의 랜덤값을 가진 배열의 데이터를 순차적으로 while문을 이용해 출력하세요
        // [출력 문자열 형식]
        // ----> 정수형배열[번째] : 랜덤값
        // 예시 ---> 정수형배열[1] : 100
        // [문제2] 위에서 저장한 10개의 랜덤값을 모두 합한 결과값을 위의 모든 랜덤값을 출력한뒤에 출력하세요
        int i = 0;
        int resultNum = 0;
        while (i < 정수형배열.Length)
        {
            Debug.Log($"정수형배열[{i}] : {정수형배열[i]}");
            resultNum += 정수형배열[i];
            i++;
        }
        Debug.Log($"랜덤값 합: {resultNum}");

    }

    /*void 배열을사용하지않고10개의데이터입출력()
    {
        // 랜덤하게 10개의 데이터를 추첨함
        int value1 = 0;
        int value2 = 0;
        int value3 = 0;
        int value4 = 0;
        int value5 = 0;
        int value6 = 0;
        int value7 = 0;
        int value8 = 0;
        int value9 = 0;
        int value10 = 0;

        value1 = Random.Range(1, 51);
        value2 = Random.Range(1, 51);
        value3 = Random.Range(1, 51);
        value4 = Random.Range(1, 51);
        value5 = Random.Range(1, 51);
        value6 = Random.Range(1, 51);
        value7 = Random.Range(1, 51);
        value8 = Random.Range(1, 51);
        value9 = Random.Range(1, 51);
        value10 = Random.Range(1, 51);

        int i = 1;
        Debug.Log($"[{i++}] 추출한 랜덤값 : {value1}");
        Debug.Log($"[{i++}] 추출한 랜덤값 : {value2}");
        Debug.Log($"[{i++}] 추출한 랜덤값 : {value3}");
        Debug.Log($"[{i++}] 추출한 랜덤값 : {value4}");
        Debug.Log($"[{i++}] 추출한 랜덤값 : {value5}");
        Debug.Log($"[{i++}] 추출한 랜덤값 : {value6}");
        Debug.Log($"[{i++}] 추출한 랜덤값 : {value7}");
        Debug.Log($"[{i++}] 추출한 랜덤값 : {value8}");
        Debug.Log($"[{i++}] 추출한 랜덤값 : {value9}");
        Debug.Log($"[{i++}] 추출한 랜덤값 : {value10}");
    }*/

    void 배열을사용해10개의데이터입출력()
    {
        int[] values = new int[10];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = Random.Range(1, 51);
            Debug.Log($"[{i + 1}] 추출한 랜덤값 : {values[i]}");
        }
    }
}
