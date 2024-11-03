using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * [클래스 구조]
 * public class 클래스명/컴포넌트명 {
 * 
 *      public 속성1(멤버변수);
 *      public 속성2(멤버변수);
 *      public 속성들 ....
 *      
 *      public void 이벤드메소드들(....) {
 *          메소드 내용들....
 *      }
 *  
 *      public void 사용자메소드들(....) {
 *          메소드 내용들....
 *      }
 */

// 일반변수 유형 : 정수형(int), 실수형, 문자열형, 부울형
// 변수 생성 문법 -> public 자료형 변수명;

public class 변수와자료형컴포넌트 : MonoBehaviour
{
    // 일반 자료형의 변수들을 클래스 멤버 변수로 선언(생성)함

    // 정수형 변수 선언 (소수 X 숫자)
    public int 정수형변수;
    // 실수형 변수 선언 (소수 O 숫자)
    public float 실수형변수;
    // 문자열형 변수 선언 (한글, 영어 등의 글자들)
    public string 문자열형변수;
    // 부울형 변수 선언 (참/거짓)
    public bool 부울형변수;

    // 메소드는 컴포넌트(객체)의 동작 표현을 수행하는 코드를 선언하는 문법적 요소로 메소드 선언으로 구성하고 호출로 동작 시킨다.
    // - 사용자 정의 메소드 : 사용자(개발자)가 직접 선언하고 호출(실행)까지 수행해야하는 메소드
    // - 유니티 이벤트 정의 메소드 : 사용자(개발자)가 직접 선언하지만 유니티가 호출(실행) 해주는 메소드

    // 사용자 정의 메소드
    // 사용자정의메소드 : 사용자가 직접 만든 커스텀 메소드
    public void 사용자정의메소드()
    {
        Debug.Log("사용자 정의 메소드 내용");
    }

    // 유니티 이벤트 정의 메소드
    // Start 메소드 : 현재 컴포넌트를 소유한 게임오브젝트가 화면에 렌더링(그려지기) 바로 전에 유니티가 딱 1번 실행시켜주는 이벤트 메소드
    public void Start()
    {
        // Debug.Log(출력하고자하는값) : 유니티 Console 창에 출력하는 스태틱메소드 (일단은 명령어로 이해)

        Debug.Log("Start 유니티 이벤트 메소드 내용");

        사용자정의메소드(); // 사용자정의메소드 호출(실행)

        Debug.Log(정수형변수);
        Debug.Log(실수형변수);
        Debug.Log(문자열형변수);
        Debug.Log(부울형변수);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
