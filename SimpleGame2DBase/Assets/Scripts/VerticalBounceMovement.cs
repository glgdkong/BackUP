using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 수직 바운스 이동
public class VerticalBounceMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // 이동 속도
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField]
    private Rigidbody2D rigidbody2d; // 물리엔진 컴포넌트

    [SerializeField]
    private float incMoveSpeed; // 이동 증가 속도

    [SerializeField]
    private float maxMoveSpeed; // 최대 이동속도

    [SerializeField]
    private float startDelayTime; // 시작 시 이동 지연시간


    // Start 코루틴 이벤트 메소드
    IEnumerator Start()
    {
        float oriSpeed = MoveSpeed;
        MoveSpeed = 0;
        yield return new WaitForSeconds(startDelayTime);

        MoveSpeed = oriSpeed;
    }

    
    void Update()
    {
        // 이동 속도 설정
        rigidbody2d.velocity = Vector2.up * MoveSpeed;
    }

    public void ReverseDirection()
    {
        // 이동 속도 반전
        MoveSpeed = -MoveSpeed;

        // 현재 이동속도의 절대적 가치값이 최대속도보다 작다면
        if(Mathf.Abs(MoveSpeed) < maxMoveSpeed)
        {
            // 속도 증가 연산
            float speed = (MoveSpeed > 0) ? incMoveSpeed : -incMoveSpeed;
            MoveSpeed += speed; // 이동 속도 증가
        }
    }
}
