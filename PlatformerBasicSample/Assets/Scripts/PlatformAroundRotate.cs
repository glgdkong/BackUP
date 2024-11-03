using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAroundRotate : MonoBehaviour
{
    [SerializeField] private float speed; // 플랫폼 이동 속도
    [SerializeField] private float radius; // 원의 반지름

    private Vector3 startPosition; // 초기 위치
    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        MoveAroundRotate();
    }
    void MoveAroundRotate()
    {
        float x = Mathf.Cos(Time.time * speed) * radius;
        float y = Mathf.Sin(Time.time * speed) *radius;
        transform.position = new Vector3(x, y, 0) + startPosition;
    }
}
