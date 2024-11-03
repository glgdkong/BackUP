using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 대입연산컴포넌트 : MonoBehaviour
{
    public int 변수1; //정수형 변수1 생성
    public int 변수2; //정수형 변수2 생성 
    public int 변수3; //정수형 변수3 생성 
    public int 누적변수; // 정수형 누적변수 생성

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"누적전 누적변수값 : {누적변수}");
        // 누적변수에 있는 값에 변수1의 값을 추가로 더해 줌

        //누적변수 = 누적변수 + 변수1;
        누적변수 += 변수1; // += 대입연산자

        Debug.Log($"변수1의 값을 누적 합계한 누적변수값 : {누적변수}");

        //누적변수 = 누적변수 + 변수2;
        누적변수 += 변수2;

        Debug.Log($"변수2의 값을 누적 합계한 누적변수값 : {누적변수}");

        //누적변수 = 누적변수 - 변수3;
        누적변수 -= 변수3;    // -= 대입연산자

        Debug.Log($"변수3의 값을 누적 감산한 누적변수값 : {누적변수}");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
