using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatePlayer : MonoBehaviour
{
    private bool isRotating = true;
    [SerializeField] private float rotateSpeed;
    void Update()
    {
        if (!isRotating) return;

        // 플레이어의 동작 코드
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
    // OnEnable : 게임오브젝트가 활성화(SetActive(true)) 됐을 때 호출 되는 이벤트 메소드
    // * Instactiate 될때도 호출됨
    private void OnEnable()
    {
        // 현재 컴포넌트는 게임 일시 정지 알림(이벤트)를 받을 수 있게 델리게이트 메소드를 등록함
        DelegateGameManager.onPauseDelegate += OnPause;
        // 현재 컴포넌트는 게임 일시 정지 해제 알림(이벤트)를 받을 수 있게 델리게이트 메소드를 등록함
        DelegateGameManager.onResumeDelegate += OnResume;


    }

    // OnDisable : 게임오브젝트가 비활성화(SetActive(false)) 됐을 때 호출 되는 이벤트 메소드
    // * Destroy 될때도 호출됨
    private void OnDisable()
    {
        // 현재 컴포넌트는 게임 일시 정지 알림(이벤트)를 받을 수 있게 델리게이트 메소드를 등록을 해제함
        DelegateGameManager.onPauseDelegate -= OnPause;
        // 현재 컴포넌트는 게임 일시 정지 해제 알림(이벤트)를 받을 수 있게 델리게이트 메소드를 등록을 해제함
        DelegateGameManager.onResumeDelegate -= OnResume;
    }

    public void OnPause()
    {
        Debug.Log("회전 동작을 멈춤");
        isRotating = false;
    }

    public void OnResume()
    {
        Debug.Log("회전 동작을 다시 수행");
        isRotating = true;
    }
}
