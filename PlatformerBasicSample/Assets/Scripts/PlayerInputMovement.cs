using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : DirectionHorizontalMovement
{
    [SerializeField] private bool isGrounded; // 바닥 착지 여부
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    [SerializeField] private Transform groundCheck; // 바닥 착지 위치
    [SerializeField] private float groundCheckRadius;   // 바닥 체크 범위
    [SerializeField] private LayerMask groundLayer; // 바닥 레이어

    [SerializeField] private int jumpsRemaining;    // 남은 점프 횟수
    private bool jumpRequested; // 점프 요청을 저장할 플래그
    [SerializeField] private int maxJumps; // 최대 점프 횟수

    [SerializeField] private float jumpForce;   // 점프 힘


    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때 최대 점프 횟수 설정
        jumpsRemaining = maxJumps;
    }

    protected override void Move()
    {
        // * Collider 충돌콜라이더참조 = Physics2D.OverlapCircle(충돌체크위치, 충돌체크크기, 충돌레이어);
        // 캐릭터 바닥 착지 여부를 체크함
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        // 수쳥 키입력값 받음
        float moveInput = Input.GetAxisRaw("Horizontal");

        // * float 절대값 = Mathf.Abs(음수/양수);
        // * AnimatorSetFloat("애니메이터파라미터명", 설정값);
        animator.SetFloat("Move", Mathf.Abs(moveInput));

        // 캐릭터 방향 전환
        // - 캐릭터가 오른쪽을 보고 있는데 키는 왼쪽을 눌렀다면 -> 반전
        if((IsRight && moveInput < 0f) || (!IsRight && moveInput > 0f))
        {
            Flip();
        }

        // 플레이어 이동 처리
        rigidbody2D.velocity = new Vector2(moveInput * MoveSpeed, rigidbody2D.velocity.y);


        // 바닥 착지 시 점프 횟수 초기화
        if(IsGrounded)
        {
            jumpsRemaining = maxJumps;
        }


        // 바닥 착지 관련 애니메이션 파라미터 설정
        animator.SetBool("IsGround", IsGrounded);
        // 수직 상승/하강 관련 애니메이션 파라미터 설정
        animator.SetFloat("Vertical", rigidbody2D.velocity.y);

        // 점프 키 입력 처리
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            // 점프 실행 요청 플래그 변수 설정
            jumpRequested = true;   
        }
        
    }

    private void FixedUpdate()
    {
       // 점프 요청 상태면
       if(jumpRequested)
        {
            // 수직 상승 처리함
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            // 점프 수행 횟수 감소
            jumpsRemaining--;
            // 점프 애니메이션 재생
            animator.SetTrigger("Jump");
            // 점프 요청 리셋
            jumpRequested = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        { transform.parent = null; }
    }
}
