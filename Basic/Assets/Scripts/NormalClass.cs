using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 차이점
// 클래스 내부에 있는 메소드의 이름 색이 달라진다
// using UityEngine이 비활성화 된다
// class와 메소드 참조 옆에 유니티 메시지, 스크립트 표시가 사라진다

// 기본 클래스의 형태
public class NormalClass 
{
    // 모노비헤이비어를 상속 받지 않았기 때문에 
    // 사용자 정의 함수가 된다.
    void Start()
    {

    }
    void Update()
    {
        
    }
    // 클래스는 변수와 함수로 추상화 한다.

    // 변수 : 프로그래밍에서 값을 저장하는 공간을 의미, 언제 어디서든 값을 바꿀 수 있다.
    // 컴퓨터는 기본적으로 아무것도 모르는 상태 입니다.
    // 무언가 명령을 하기 위해서는 변수를 만들어 표현을 해줘야 합니다.
    string name;
    int age;
    float height;
    string leftHand;




    // 변수의 선언
    // 1. 접근제한자 2. 데이터타입 3. 변수명;

    // 1. 접근제한자 (public, private, etc....)
    // public : 외부에 공개하다. 클래스 외부에서도 사용 가능
    // private : 외부에 공개하지 않는다. 클래스 내부에서만 사용 가능.
    // 접근제한자를 생략하면 기본적으로 private상태이다.

    // 2. 데이터타입(Data Type) 
    // 기본 데이터 타입(마이크로소프트) : 정수(int), 실수(float), 문자열(string), 논리형(bool), esc...
    // 유니티 데이터 타입 : 우리가 컴포넌트로 사용했던 것들, GameObject, Transform, Rigidbody etc...
    // 사용자 정의 데이터 타입 : 우리가 만든 class를 의미 NormalClass, Orc, Monster, etc...

    // 3. 변수명(변수 이름)
    // 변수명 명명규칙(이름을 짓는 규칙)
    // 무조건 따라야 하는 것은 아니지만 오랜시간 프로그래밍을 해온 개발자들끼리의 암묵적인 룰.
    // 변수명의 첫 글자는 소문자로 작성한다.
    // 띄어쓰기를 하지 않는다.
    // 두 단어 이상의 합성어일 경우 단어의 의미가 바뀔 때 첫 글자를 대문자로 적는다.
    // ex) moveSpeed, attackPower, jumpForce, monsterName, ...
    // Camel 표기법 (낙타 등 처럼 생겼다고 해서 붙여진 이름)

    /*// 각 데이터 타입 사용해서 변수 선언 해보세요
    public int hp;
    public int level;
    public float moveSpeed;
    private float positionX;
    private float positionY;

    public string playerName;
    public string partyName;

    public bool isAlive;*/

    // 초기화 : reset의 의미가 아니고, 변수에 최초로 값을 할당하는 것을 의미한다.
    // 변수의 선언과 동시에 초기화
    // 접근제한자 데이터타입 변수명 =(대입연산자) 값;
    public string intrduceMySelf = "안녕하세요 ***입니다.";
    private float todayTemperature = 31.4f;
    public int day = 25;
    public int month = 08;
    private bool isDie = false;
    private bool isGameover = false;

    // 문자열 형 데이터타입의 변수에 값을 할당할 때에는 ""(쌍따옴표)안에 작성한다.
    // 실수형 데이터타입의 변수에 값을 할당할 때는 숫자 뒤에 f를 붙여준다.
    // 논리 형 데이터타입의 변수명은 이다, 아니다를 구분하기 위해 보통 isXXX 라고 짓는다.

    // 전역(멤버) 변수 : 클래스 안의 모든 지역에서 사용이 가능하다.
    // class {} 클래스의 중괄호 범위(컨텍스트)

    // 지역(로컬) 변수 : 선언된 컨텍스트 범위 안에서만 사용이 가능하다. 보통 함수 내에서 선언한 변수를 지역변수라고 한다.

    // 변수의 사용
    // 선언된 변수는 사용할 때 [변수명 =(연산자) 값]의 형태로 사용할 수 있다.

    // 함수(메소드) : 어떠한 기능 처리를 위해 만들어 놓은 코드
    // 마이크로소프트, 유니티가 미리 만들어 놓은 함수들과 
    // 사용자 필요에 의해 직접 만든 사용자 정의 함수가 있다.
    // 코드의 가독성과 재사용을 용이하도록 한다.
    // 함수는 호출해야 사용이 된다.

    // 함수의 정의
    // 1.접근제한자 2.리턴타입 3.함수명(4.매개변수) {}

    // void : 공허하다. (프로그래밍에서는 아무것도 없다. = 리턴하는 것이 없다.)
    // () : 괄호 안에 아무것도 없으면 매개변수가 없는 함수이다.
    // 매개변수 : 함수를 실행하는데 필요한 준비물
    public void Sum()
    {
        isGameover = false; // 전역 변수 사용
        int a = 0;
        int b = 1;
        int c = a + b;
    }

    public void Minus()
    {
        isGameover = true;
        //a = 0; 지역변수의 특징, a변수는 Sum()함수 내에서 작성된 지역변수이므로 다른 곳에서 사용 불가능
        //int b = 2; // 선언된 지역에서만 유효하기 때문에 동일한 이름의 지역 변수가 여러 개 존재할 수 있다.
        //int c;
        //int d = b + c;
        // 지역 변수는 사용 할 때 값을 할당해 줘야 한다.
        
        // 사용자의 의도는 마이너스 함수내의 day변수에 전역변수 day의 값인 25를 할당하고 싶음.
        // int day = day;
        // 변수 명이 동일하기 때문에 에러 발생
        int day = this.day;
        // this. => 나 자신의 class를 의미
        // 전역 변수와 지역 변수의 이름을 되도록이면 구분하고, 정 안되명 this 키워드 사용.
    }
}
