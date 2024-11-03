using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지정 방향 이동 처리 컴포넌트
public class DirectionMovement : Movement
{
    protected float angle; // 이동 방향에 대한 회전 각도

    // 이동 방향에 대한 회전 각도 프로퍼티
    public float Angle
    {
        set => angle = value;
        get
        {
            // 아크 탄젠트2 메소드를 이용해 2D 방향 벡터의 회전 각도(디그리)를 구함
            float raian = Mathf.Atan2(MoveDirection.y, MoveDirection.x);
            angle = raian * Mathf.Rad2Deg;
            return angle;
        }
    }
    // 방향 설정 메소드 (프로퍼티를 이용해도 됨
    public void SetDirection(Vector2 direction)
    {
        MoveDirection = direction;
    }

    protected virtual void Update()
    {
        Move();
    }

    // 이동 처리 메소드
    protected override void Move()
    {
        // 이동속도 및 방향 설정
        rigidbody2D.velocity = MoveDirection.normalized * MoveSpeed;
    }
}
