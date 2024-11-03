using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringAPITest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string exampleString = "Hello Unity!";

        // ���ڿ� ���� ���
        Debug.Log("Length : " + exampleString.Length);

        // �빮�ڷ� ��ȯ
        string upperString = exampleString.ToUpper();
        Debug.Log("Upper Case : " + upperString);

        // �ҹ��ڷ� ��ȯ
        string lowerString = exampleString.ToLower();
        Debug.Log("Lower Case : " + lowerString);

        // �κ� ���ڿ� ����                    (index, count)
        string subString = exampleString.Substring(6, 5);
        Debug.Log("Sub String : " + subString);

        // ���ڿ� ��ü
        string replacedString = exampleString.Replace("Unity", "World");
        Debug.Log("Replaced String : " + replacedString);

        // ���ڿ� ����
        string[] splitString = exampleString.Split(' ');
        foreach (string str in splitString)
        {
            Debug.Log("Split Part " + str);
        }
        

    }

}
