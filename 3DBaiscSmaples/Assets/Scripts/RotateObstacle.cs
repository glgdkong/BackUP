using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 회전하는 동적 장애물 회전 처리
public class RotateObstacle : MonoBehaviour
{
    // 회전 속도
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        // 장애물 회전 처리
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }


}
