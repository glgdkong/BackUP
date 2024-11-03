using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 일시정지 기능 인터페이스
public interface IPause 
{
    public void OnPause(); // 게임 일시 정지 알림 이벤트
    public void OnResume(); // 게임 일시 정지 해제 알림 이벤트
}
