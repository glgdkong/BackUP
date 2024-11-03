using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 이동 클래스
public abstract class Movement : MonoBehaviour
{
    // 스프라이트 렌더러 컴포넌트
    protected SpriteRenderer spriteRenderer;

    // 리지드 바디 컴포넌트
    protected new Rigidbody2D rigidbody2D;

    // 애니메이터 컴포넌트
    protected Animator animator;

   
    // 이동 방향
    [SerializeField] private Vector2 moveDirection;
    public Vector2 MoveDirection { get => moveDirection; set => moveDirection = value; }
    
    // 이동 속도
    [SerializeField] protected float moveSpeed;

    // Read / Write
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    // Read
    // public float MoveSpeed => moveSpeed;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // 이동 처리 추상 메소드
    protected abstract void Move();


}
