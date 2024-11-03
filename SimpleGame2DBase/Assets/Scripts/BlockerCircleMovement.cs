using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerCircleMovement : MonoBehaviour
{
    [SerializeField] private Transform centerTransform; // 가운데 위치 정보를 가진 Transform 컴포넌트
    [SerializeField] private Transform targetTransform; // 이동할 위치 정보를 가진 Transform 컴포넌트

    [SerializeField] private float moveSpeed; // 블로커 이동 속도

    [SerializeField] private Vector2 targetPosition; // 이동할 타겟 위치 정보 벡터

    [SerializeField] private bool moveTo = false; // 이동 여부 (오리지널 위치에서)

    [SerializeField] private Transform colorBlockerCircleTransform; // 색상 블로커 Transform 컴포넌트

    void Start()
    {
        // 현재 블로커의 시작위치를 가운데 위치로 설정
        colorBlockerCircleTransform.position = centerTransform.position;
        // 이동할 위치 벡터 설정(시작할 때는 이동하지 않기 때문에 현재 블로커의 위치를 타겟으로 설정)
        targetPosition = centerTransform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // 지정된 타겟 위치로 게임오브젝트를 이동 시킴
        colorBlockerCircleTransform.position = Vector2.MoveTowards(colorBlockerCircleTransform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    // 블로커 반전 이동 처리(마우스 클릭시 실행)
    public void ReverseMove()
    {
        // 이동 여부 반전(이동시작)
        moveTo = !moveTo;
        targetPosition = moveTo ? targetTransform.position : centerTransform.position;
    }
}
