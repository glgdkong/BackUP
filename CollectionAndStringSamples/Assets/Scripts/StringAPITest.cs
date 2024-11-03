using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringAPITest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string exampleString = "Hello Unity!";

        // 문자열 길이 출력
        Debug.Log("Length : " + exampleString.Length);

        // 대문자로 변환
        string upperString = exampleString.ToUpper();
        Debug.Log("Upper Case : " + upperString);

        // 소문자로 변환
        string lowerString = exampleString.ToLower();
        Debug.Log("Lower Case : " + lowerString);

        // 부분 문자열 추출                    (index, count)
        string subString = exampleString.Substring(6, 5);
        Debug.Log("Sub String : " + subString);

        // 문자열 교체
        string replacedString = exampleString.Replace("Unity", "World");
        Debug.Log("Replaced String : " + replacedString);

        // 문자열 분할
        string[] splitString = exampleString.Split(' ');
        foreach (string str in splitString)
        {
            Debug.Log("Split Part " + str);
        }
        

    }

}
