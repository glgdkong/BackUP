using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 변수유효범위컴포넌트 : MonoBehaviour
{
    public static int 스태틱변수 = 0;
    
    // 클래스 멤버변수/속성의 메모리 유효범위 : 클래스
    public int 클래식멤버변수 = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 지역변수/ 스택변수/ 로컬변수의 메모리 유효범위 : 메소드
        int 지역변수 = 0;

        Debug.Log($"카운트 전 스태틱변수 : {스태틱변수}");
        Debug.Log($"카운트 전 클래식멤버변수 : {클래식멤버변수}");
        Debug.Log($"카운트 전 지역변수 : {지역변수}");

        스태틱변수++;
        클래식멤버변수++;
        지역변수++;

        Debug.Log($"카운트 후 스태틱변수 (START) : {스태틱변수}");
        Debug.Log($"카운트 후 클래식멤버변수 (START) : {클래식멤버변수}");
        Debug.Log($"카운트 후 지역변수 (START) : {지역변수}");
    }

    // Update is called once per frame
    void Update()
    {
        스태틱변수++;
        클래식멤버변수++;
        //지역변수++;  // start 메소드에서 생성된 지역변수는 다른 메소드에서는 접근할 수 없음

        Debug.Log($"카운트 후 스태틱변수 (Update) : {스태틱변수}");
        Debug.Log($"카운트 후 클래식멤버변수 (Update) : {클래식멤버변수}");
        //Debug.Log($"카운트 후 지역변수 (Update) : {지역변수}");
    }
}
