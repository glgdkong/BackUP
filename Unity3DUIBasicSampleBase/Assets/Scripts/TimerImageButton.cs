using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimerImageButton : MonoBehaviour
{
    // Fille 타입으로 설정된 Image 컴포넌트 참조
    [SerializeField] private Image filledImage;
    // 타이머 지속 시간(초)
    [SerializeField] private float timerDuration;

    // 타이머 동작 중 여부
    private bool isTimerRunning = false;

    // 시간
    private float timer;

    private void Update()
    {
        // 타이머가 동작 중이라면
        if(isTimerRunning)
        {
            // 시작이 흐른다면
            if (timer > 0)
            {
                // 타임 감소
                timer -= Time.deltaTime;
                // 다음 감소 Filled 타입 이미지에 적용
                filledImage.fillAmount = timer / timerDuration;
            }
            else
            { 
                // 타이머 종료
                isTimerRunning = false;
                // Filled 타입 이미지 초기화
                filledImage.fillAmount = 0f;
                // 터치 가능 상태로 복원
                filledImage.raycastTarget = true;
            }
        }
    }

    // 이미지 클릭 이벤트(Point Down)
    public void OnPointerDown(BaseEventData evt)
    {
        if (!isTimerRunning)
        {
            // 타이머 시작
            StartTimer();
        } 
    }
    // 타이머 시작
    private void StartTimer()
    {
        // 시작 타임 적용
        timer = timerDuration;
        // 타이머 동작 시작
        isTimerRunning = true;
        // 터치 불가능 상태 적용
        filledImage.raycastTarget = false; // 터치 불가능 상태로 설정
    }
}
