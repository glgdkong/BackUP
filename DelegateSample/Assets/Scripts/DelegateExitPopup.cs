using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExitPopup : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private void OnEnable()
    {
        // 현재 컴포넌트는 게임 일시 정지 알림(이벤트)를 받을 수 있게 델리게이트 메소드를 등록함
        DelegateGameManager.onPauseDelegate += OnOpen;
        // 현재 컴포넌트는 게임 일시 정지 해제 알림(이벤트)를 받을 수 있게 델리게이트 메소드를 등록함
        DelegateGameManager.onResumeDelegate += OnClose;


    }

    // OnDisable : 게임오브젝트가 비활성화(SetActive(false)) 됐을 때 호출 되는 이벤트 메소드
    // * Destroy 될때도 호출됨
    private void OnDisable()
    {
        // 현재 컴포넌트는 게임 일시 정지 알림(이벤트)를 받을 수 있게 델리게이트 메소드를 등록을 해제함
        DelegateGameManager.onPauseDelegate -= OnOpen;
        // 현재 컴포넌트는 게임 일시 정지 해제 알림(이벤트)를 받을 수 있게 델리게이트 메소드를 등록을 해제함
        DelegateGameManager.onResumeDelegate -= OnClose;
    }
    public void OnOpen()
    {
        Debug.Log("종료 팝업 열림");
        panel.gameObject.SetActive(true);
    }

    public void OnClose()
    {
        Debug.Log("종료 팝업 닫힘");
        panel.gameObject.SetActive(false);
    }
}
