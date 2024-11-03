using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateGameManager : MonoBehaviour
{
    private bool isPaused = false; // 일시 정지 여부

    // 이벤트 델리게이트 메소드 원형 선언 (델리게이트 타입 선언)
    public delegate void OnPauseDelegate(); // 일시 정지 이벤트 델리게이트 선언
    public delegate void OnResumeDelegate(); // 일시 정지 해제 이벤트 델리게이트 선언

    // 델리게이트 이벤트 변수 선언
    // * 델리게이트는 꼭 static으로 변수 선언을 할 필요는 없음
    public static OnPauseDelegate onPauseDelegate;
    public static OnResumeDelegate onResumeDelegate;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();  // 일시 정지 처리 반전 
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // 일시정지 이벤트 통지 델리게이트 메소드 실행
            onPauseDelegate();
        }
        else
        {
            // 일시정지 해제 이벤트 통지 델리게이트 메소드 실행
            onResumeDelegate();
        }
    }
}
