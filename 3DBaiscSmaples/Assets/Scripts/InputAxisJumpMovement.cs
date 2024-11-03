using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAxisJumpMovement : MonoBehaviour
{
    // 캐릭터 컨트롤러
    [SerializeField] private CharacterController controller;
    
    // 애니메이터
    [SerializeField] private Animator animator;
    
    // 이동 속도
    [SerializeField] private float moveSpeed;
    
    // 이동 방향
    [SerializeField] private Vector3 moveDirection;
    
    // 점프속도
    [SerializeField] private float jumpSpeed;
    
    // 바닥 착지 여부
    [SerializeField] private bool isGrounded;
    
    // 착지 유효 타이머
    private float groundTimer;
    
    // 수직 하강속도
    [SerializeField] private float verticalSpeed;
    
    // 중력
    [SerializeField] private float gravity;

    private void Update()
    {
        // CharacterController 점프 및 이동 보정 메소드 호출 순서
        Jump(); // 1

        Move(); // 2

        GravityDown(); // 3
    }

    public void Move()
    {
        // 왼쪽 쉬프트키를 누르고 있다면
        bool isHooray = Input.GetKey(KeyCode.LeftShift);
        // 만세 애니메이션을 재생함
        animator.SetBool("Hooray", isHooray);

        // 애니메이션에 착지 상태값 설정
        animator.SetBool("IsGround", isGrounded);
        // 방향키 입력 처리
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 이동 방향 벡터 생성
        moveDirection = new Vector3 (h, 0f, v).normalized;

        // 이동 애니메이션 재생
        animator.SetFloat("Move", moveDirection.magnitude);

        // 현재 바닥 착지 상태면
        //if(isGrounded)
            transform.LookAt(transform.position + moveDirection); // 시선 변경

        // 캐릭터 컨트롤러로 이동 처리
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    // 중력처리
    public void GravityDown()
    {
        // 수직 하강 속도 설정 (단위값)
        verticalSpeed = verticalSpeed - gravity * Time.deltaTime;   

        // 수직 하강 속도가 중력 크기보다 작아지면
        if(verticalSpeed < -gravity)
            verticalSpeed = -gravity; // 중력 크기 최대 수직 하강 속도를 설정
        // 수직 하강 이동 벡터 생성
        Vector3 verticalMove = new Vector3(0f, verticalSpeed * Time.deltaTime, 0f);

        // 캐릭터 컨트롤러가 닿은 콜리전 영역의 플래그 값을 반환 && 수직 하강 이동 처리 (중력처리)
        CollisionFlags flag = controller.Move(verticalMove);

        // 이동시 충돌한 바닥 면이 있다면
        if ((flag & CollisionFlags.Below) != 0)
        {
            verticalSpeed = 0; // 수직 하강속도를 0으로 초기화
        }
        // 최종 수직 속도를 애니메이션에 적용함
        animator.SetFloat("Vertical", verticalSpeed);
    }

    public void Jump()
    {
        // 캐릭터 컨트롤러가 바닥은 인식하지 않은 상태에서
        if (!controller.isGrounded)
        {
            // 착지 상태가 설정된 경우
            if (isGrounded)
            {
                // 착지 유효상태 시간계산
                groundTimer += Time.deltaTime;

                // 0.5초 후에 착지 상태 해제
                if (groundTimer >= 0.5f)
                { 
                    isGrounded = false;
                }

            }
        }
        else // 착지 관련 모든 상태가 착지 상태라면
        {
            groundTimer = 0.0f; // 착지 유효 체크 타이머 초기화
            isGrounded =true; // 착지상태 설정
        }

        // 착지 상태에서 점프키를 눌렀다면
        if (isGrounded && Input.GetButtonDown("Jump")) 
        {
            // 점프 애니메이션 재생
            animator.SetTrigger("Jump");
            verticalSpeed = jumpSpeed; // 수직 하강 속도에 점프 속도를 설정
            isGrounded = false; // 착지상태 해제
        }
    }

    // 애니메이션 이벤트 사운드 재생 (사운드 클립 참조)
    public void AnimationSoundPlay(Object audioClip)
    { 
        // Object(부모타입) -> AudioClip(자식타입) : 다운캐스팅
        // * 부모타입의 객체의 참조를 자식 타입의 참조변수에 저장하려면 반드시 다운 캐스팅을 해야함
         AudioSource.PlayClipAtPoint((AudioClip)audioClip, Camera.main.transform.position);
        // == AudioSource.PlayClipAtPoint(audioClip as AudioClip, Camera.main.transform.position);
    }

}
