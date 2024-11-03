using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public class PlatformDirectMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed; // 플랫폼 이동 속도
    [SerializeField] protected float moveDistance; // 좌우로 이동할 최대 거리

    protected Vector3 startPosition; // 플랫폼 초기 위치

    [SerializeField] protected bool isVertical; // 수직 이동 여부

    protected void Start()
    {
        startPosition = transform.position;
    }
    // 수평이동 처리
    protected virtual void Move()
    {
        // 수직 이동 처리
        // Mathf.Sin 함수를 사용하여 시간에 따라 -1과 1사이의 값을 생성하고, 이를 이동거리에 곱함
        float move = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        if (isVertical)
        {
            // 오브젝트의 y 위치를 시작 위치에 move값을 더해 갱신
            transform.position = startPosition + new Vector3(0f, move, 0f);
        }
        else
        {
            // 오브젝트의 x 위치를 시작 위치에 move값을 더해 갱신
            transform.position = startPosition + new Vector3(move, 0f, 0f);
        }
    }
    protected virtual void Update()
    {
        Move();
    }
}
