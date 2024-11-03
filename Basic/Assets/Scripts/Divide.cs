using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divide : MonoBehaviour
{
    private int a;
    private int b;


    // Start is called before the first frame update
    void Start()
    {
        a = 100;
        b = 35;

        // 정수형 변수이기 때문에 나눈 몫 : 2
        int c = a / b;

        Debug.Log(c);
    }
}
