using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private Movement movement;

    // 적 경로 탈출 보정 값
    [SerializeField] private float offSet = 0.03f;

    public void Setting(Transform[] way)
    {
        movement = GetComponent<Movement>();

        // 적 이동 경로(웨이 포인트) 설정
        wayPointCount = way.Length;
        // 배열의 초기화
        wayPoints = new Transform[wayPointCount];
        // 배열 할당
        wayPoints = way;

        // 적의 최초 위치를 첫 번째 웨이포인트의 위치로 설정
        transform.position = wayPoints[currentIndex].position;

        StartCoroutine(MoveCoroutine());
    }

    // 적의 움직임 코루틴
    private IEnumerator MoveCoroutine()
    {
        SetDestination();
        // 움직이기 전에 방향 설정이 필요하다.
        while (true)
        {
            // 목표 지점에 도달하였다면
            // float 은 정확한 값이 아니고 근사값입니다.
            // 거리 벡터 구하기 Vector3.Distance(a,b);
            // 목표 지점까지의 거리가 오프셋 보다 가까워 지면 도착했다라고 쳐준다.
            if (Vector3.Distance(wayPoints[currentIndex].position, transform.position) <= offSet)
            {
                // 현재 위치를 목표 지점으로 초기화
                transform.position = wayPoints[currentIndex].position;

                // 다음 목적지 설정
                SetDestination();
            }
            yield return null;
        }
    }

    private void SetDestination()
    {
        // 아직 이동할 웨이포인트가 남아있다면
        if (currentIndex < wayPointCount - 1)
        {
            currentIndex++;

            // 방향 구하기 
            // 목표 지점으로 향하는 벡터 구하기 (목표지점 - 나의 현재위치).normalized;
            // 벡터 (방향, 크기, 상대적인 위치, 원점으로부터의 위치)
            // 방향을 구할 때는 벡터가 크기 또한 가지고 있으므로 방향만을 가지도록 크기를 1로 만드는것을 정규화라고 한다. (.normalized)

            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement.SetDirection(direction);
        }
        // 마지막 웨이포인트라면 (Finish 타일에 도달)
        else
        {
            Destroy(gameObject); 
        }
    }
}
