using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 왕복 이동 처리 컴포넌트
public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float speed; // 이동 속도
    [SerializeField] private float distance; // 이동 거리(왕복 운동 거리)
    private Vector3 startPosition; // 이동 시작 위치

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // 왕복 운동 크기
        float moveAmount = Mathf.Cos(Time.time * speed) *distance;

        // Vector3.forward : 오브젝트 이동 방향
        Vector3 newPosition = startPosition + Vector3.forward * moveAmount;

        // 장애물 위치 설정
        transform.position = newPosition;
    }

}
