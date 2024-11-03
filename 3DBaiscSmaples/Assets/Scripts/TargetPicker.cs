using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPicker : MonoBehaviour
{
    // 타겟 피커 표시위치 오프셋 Y
    [SerializeField] private float surfaceOffset;
    // 타겟 위치 표시용 게임오브젝트(실린더)
    [SerializeField] private GameObject targetPoint;

    // 타겟 위치 표기(표시 위치, 표시 수직 방향)
    public void Show(Vector3 position, Vector3 normal)
    {
        //Debug.Log($"이동위치 표시 : {position}");

        // 타겟 위치를 설정
        transform.position = position + normal * surfaceOffset;

        // 타겟 표시 방향 설정
        transform.up = normal;
        // 타겟포인트 게임오브젝트 활성화
        targetPoint.SetActive( true );
    }

    // 타겟 위치 표시 숨김
    public void Hide()
    {
        // 타겟포인트 게임오브젝트 비활성화
        targetPoint.SetActive( false );
        transform.position = Vector3.zero;
    }

}
