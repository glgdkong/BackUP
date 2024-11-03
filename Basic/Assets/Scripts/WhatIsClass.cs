using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 네임스페이스의 공간
// 네임스페이스는 자주 사용하는 기능들을 미리 해당 네임(이름)으로 나누어서 관리하는 것
// UnityEngine : 유니티 엔진에 대한 기능들을 모아 놓음.

// 프로그래밍에는 수많은 데이터 타입이 존재한다
// class : 우리가 표현하고자 하는 것을 클래스 내부에 변수와 함수로 추상화 하는 것을 의미한다.
// 추상적이다. ? : 구체적이지 않다. 일반적인 것
// 일반적(추상적)으로 만드는(추상화) 이유 : 재사용하기 위해서.
// class를 사용하려면 인스턴스화 해야 합니다.

// 유니티에서 제공하는 클래스 형식.
// MonoBehaviour를 상속받은 class는 게임오브젝트에 할당해야만 사용된다.
// MonoBehaviour를 상속받은 class를 인스턴스화 하려면 게임오브젝트에 할당해야 한다.
// ClassOne : ClassTwo => ClassTwo를 상속받은 ClassOne

// . (콤마) 안을 들여다 보는 기능, 사용 할 때마다 점점 내부로 들어가는 겁니다.
public class WhatIsClass : MonoBehaviour
{
    
    // 변수 : 프로그래밍에서 어떤 값을 저장하기 위한 장소.
    // 변하는 수 : 값을 대입하거나 바꿀 수 있다.

    // 변수명 선언 규칙
    // 접근제한자 데이터타입 변수명;
    // 프로그래밍에서 문장의 끝은 ;(세미콜론)

    // 변수 선언과 동시에 초기화 규칙
    // 접근제한자 데이터타입 변수명 = 값;

    // 변수명 명명 규칙
    // 앞글자를 소문자로, 단어의 의미가 바뀔 때 첫글자를 대문자로 작성한다.

    // 접근제한자 (public, private), protected
    // public : class 외부에 공개 -> 다른 class에서 접근이 가능하고, 유니티 에디터의 인스펙터 창에서도 접근이 가능하다
    // private : class 외부에 공개하지 않음. 자신의 class에서만 사용이 가능하다. 외부에서 접근 불가능.

    // 변수는 class{}영역 내에 작성이 가능합니다.
    // 가장 넓은 영역인 class(struct)의 {} 영역에 작성한 변수를 [전역(멤버) 변수]라고 한다. => class{}내의 영역에서 사용할 수 있다.
    // 함수 영역안에 작성된 변수를 [지역 변수]라고 한다 => 지역변수는 선언된 지역에서만 사용이 가능하다.


    void Start()
    {
        string carName;
        carName = "소나타";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
