using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // 캐릭터 애니메이터 컴포넌트
    [SerializeField] private Animator animator;
    // 캐릭터 컨트롤러 컴포넌트
    [SerializeField] private CharacterController cc;
    // 이속
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        // 키 입력 처리
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 이동 방향 벡터 설정
        Vector3 movement = new Vector3(h,0f ,v).normalized;

        // 이동 애니메이션 재생
        animator.SetFloat("Move", movement.magnitude);

        // 캐릭터 회전 처리
        transform.LookAt(transform.position + movement.normalized);

        // 캐릭터 이동 처리
        cc.Move(movement* (moveSpeed *Time.deltaTime));
    }


}
