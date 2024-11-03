using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ESC 취소 처리 델리 게이트 선언
    public delegate void OnCanckeDelegate();
    public static OnCanckeDelegate onCancelDelegate;


    // Update is called once per frame
    void Update()
    {
        // ESC를 누른경우
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // 델리게이트 메소드 호출
            onCancelDelegate();
        }
    }
}
