using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UFO 이동 컴포넌트

public class UFOMoveComponent : MonoBehaviour
{
    // 변수(속성) 선언(생성) -> 값을 가진 메모리 생성

    // X 이동 방향
    public float X;
    // Y 이동 방향
    public float Y;
    // Z 이동 방향
    public float Z;

    // 이동 속도
    public float MoveSpeed;

    // 유니티 이벤트 정의 메소드
    // Start 메소드 : 현재 컴포넌트를 소유한 게임오브젝트가 화면에 렌더링(그려지기) 바로 전에 유니티가 딱 1번 실행시켜주는 이벤트 메소드
    public void Start()
    {
        Debug.Log("UFO 렌더링 바로 전에 처리될 내용");

        // 변수(속성)값 대입
        // 문법 -> 변수명 = 값;

        X = 1f; // X 방향값 대입 (메모리/변수 값 저장)
        Y = 0f; // Y 방향값 대입
        Z = 0f; // Z 방향값 대입

        MoveSpeed = 1.2f; // UFO 이동 속도 대입

        // Debug.Log($"{변수명} 문자열 조합")

        Debug.Log($"방향({X}, {Y}, {Z}), 속도({MoveSpeed})");

    }

    // 유니티 이벤트 메소드
    // Update : 화면에 현재 컴포넌트를 가진 게임오브젝트가 그려질때마다 호출(실행)되는 이벤트 메소드
    // 예) 60fps -> 초당 60프레임 -> 1초 60번 실행됨
    public void Update()
    {
        
        
        // 이동 코드 실행 (변수(속성)의 개념만 이해할 것)
        transform.Translate(new Vector3(X, Y, Z) * MoveSpeed * Time.deltaTime);
    }
}
