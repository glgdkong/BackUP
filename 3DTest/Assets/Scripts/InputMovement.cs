using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : PlayerController
{
    // 이동 속도
    [SerializeField] private float moveSpeed;
    // 회전 속도
    [SerializeField] private float rotateSpeed;
    public float RotateSpeed { get => rotateSpeed;}
    [SerializeField] private Transform cameraTransform;

    // 캐릭터 컨트롤러 컴포넌트
    private CharacterController cc;

    // 이동 벡터
    private Vector3 movement;

    // 중력 관련 속성
    [SerializeField] private float gravity; // 중력수치
    private float vSpeed = 0.0f;

    // 근접 공격 컴포넌트
    private InputMeleeAttack meleeAttack;

    // 플레이어 구르기 컴포넌트
    private InputDodgeMovement dodge;

    // 플레이어 가드 컴포넌트
    private InputGuard guard;

    protected override void Awake()
    {
        base.Awake();
        cc = GetComponent<CharacterController>();
        meleeAttack = GetComponent<InputMeleeAttack>();
        dodge = GetComponent<InputDodgeMovement>();
        guard = GetComponent<InputGuard>();
    }

    void Update()
    {
        if (meleeAttack.IsPlayAttackAniamtion() || playerHp.IsDeath || playerHp.IsHit || dodge.IsDodgeing || guard.IsGuarding) 
        {
            return; 
        }

        Move();

        Gravity();
    }

    private void Move()
    {
        // 키입력값
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 이동 방향 벡터 
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        // 이동 애니메이션 재생
        animator.SetFloat("Move", direction.magnitude);

        // 카메라의 회전을 기준으로 캐릭터의 새로운 방향 벡터를 구함
        direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;
        direction.Normalize();

        // 최종 이동벡터를 계산함
        movement = direction;

        // 캐릭터가 이동을 수행함
        cc.Move(movement * (moveSpeed * Time.deltaTime));

        // 캐릭터가 이동을 수행한다면
        if (movement != Vector3.zero)
        {
            // 캐릭터 방향에 대한 쿼터리언 회전값을 구함
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // 부드러운 캐릭터의 회전 처리를 수행항
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }

    private void Gravity()
    {
        vSpeed = vSpeed - gravity * Time.deltaTime;
        if (vSpeed < -gravity) vSpeed = -gravity;

        var verticalMove = new Vector3(0, vSpeed * Time.deltaTime, 0f);

        var flag = cc.Move(verticalMove);
        if ((flag & CollisionFlags.Below) != 0)
        {
            vSpeed = 0f;
        }
    }
}
