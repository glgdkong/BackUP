using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 산술연산컴포넌트 : MonoBehaviour
{
    public int 변수1; //정수형 변수1 생성
    public int 변수2; //정수형 변수2 생성
    // Start is called before the first frame update
    void Start()
    {
        //산술 연산자

        //단항 연산자
        Debug.Log($"-변수1 : {-변수1}");

        // 이항 연산자
        Debug.Log($"변수1 + 변수2 = {변수1 + 변수2}");
        Debug.Log($"변수1 - 변수2 = {변수1 - 변수2}");

        int 곱셈변수 = 변수1 * 변수2;
        Debug.Log($"변수1 * 변수2 = {곱셈변수}");
        Debug.Log($"변수1 / 변수2 = {변수1 / 변수2}");
        Debug.Log($"변수1 % 변수2 = {변수1 % 변수2}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
