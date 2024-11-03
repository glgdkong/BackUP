using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    private Animator animator; // 애니메이터 컴포넌트
    private CharacterController controller; // 캐릭터 컨트롤러 컴포넌트

    [SerializeField] private float speed; // 이동속도
    [SerializeField] private float rotateSpeed; // 회전 속도

    private Vector3 movement; // 이동 벡터

    // 중력 관련 속성
    [SerializeField] private float gravity; // 중력 수치
    private float vSpeed = 0.0f;

    private InputMeleeAttack meleeAttack; // 근접 일반공격 컴포넌트

    private InputSkillAttack skillAttack; // 스킬 공격 컴포넌트


    private void Awake()
    {
        // 컴포넌트 참조
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        meleeAttack = GetComponent<InputMeleeAttack>();
        skillAttack = GetComponent<InputSkillAttack>();
    }

    private void Update()
    {
        // 공격 및 스킬 애니메이션이 진행 중일 경우 이동을 하지 않음
        if (meleeAttack.IsPlayAttackAnimation() || skillAttack.IsSkillAnimation()) return;
        Move();  // 이동 처리
        GravityDown(); // 중력 처리

    }

    // 캐릭터 이동 처리
    private void Move()
    {
        // 입력 이동 방향
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        // isAnimatorTransitioning = animator.IsInTransition(0);

        movement = direction; // 이동 방향

        // 이동 애니메이션 재생
        animator.SetFloat("Move", movement.magnitude);

        // 캐릭터 회전 처리
        //transform.LookAt(transform.position + movement.normalized);

        Vector3 targetDirection = movement.normalized;
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        }
        // 이동 처리
        controller.Move(movement * (speed *Time.deltaTime));
    }

    private void GravityDown()
    {
        vSpeed = vSpeed - gravity * Time.deltaTime;

        if (vSpeed < -gravity) 
            vSpeed = -gravity;

        var verticalMove = new Vector3(0, vSpeed * Time.deltaTime, 0);

        var flag = controller.Move(verticalMove);
        if((flag & CollisionFlags.Below) != 0)
        {
            vSpeed = 0;
        }
    }

}
