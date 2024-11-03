using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 거점 순환 이동 처리 컴포넌트
public class FatrolMovement : DirectionHorizontalMovement
{
    // 순환 위치 포인트들
    [SerializeField] private Transform[] wayPoints;

    // 현재 이동하는 순환위치 인덱스
    private int currentWatPointIndex = 0;

    // 이동 처리
    protected override void Move()
    {
        // 이동 포인트 길이가 0이면 처리 불가
        if(wayPoints.Length == 0) return;

        // 현재 이동 위치를 참조함
        Transform targetWaypoint = wayPoints[currentWatPointIndex];

        // 부드럽게 보간 이동 처리를 수행함 
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, MoveSpeed * Time.deltaTime);

        // 캐릭터의 이동 방향에 맞게 스프라이트 방향 전환을 수행함
        if(transform.position.x < targetWaypoint.position.x) spriteRenderer.flipX = false;
        if (transform.position.x > targetWaypoint.position.x) spriteRenderer.flipX = true;

        // 목표 위치에 도달했다면 
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // 다음 위치 인덱스 업데이트
            if(IsRight) // 순방향 이동 중이면
            {
                // 마지막 이동 위치에 도달하지 않았다면
                if (currentWatPointIndex < wayPoints.Length - 1)
                    currentWatPointIndex++; // 다음 이동 위치 인덱스 계산
                else // 마지막 이동 위치까지 도달했다면
                {
                    currentWatPointIndex--; // 이전 이동 위치 인덱스 계산
                    IsRight = false; // 역방향으로 이동 방향 전환
                }
            }
            else // 역방향 이동 중이면
            {
                // 첫번째 이동 위치에 도달하지 않았다면
                if (currentWatPointIndex > 0) currentWatPointIndex--;
                else // 첫번째 이동 위치에 도달했다면
                {
                    currentWatPointIndex++; // 다음 이동 위치 인덱스 계산
                    IsRight = true; // 순방향으로 이동 방향 전환
                }
            }
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
