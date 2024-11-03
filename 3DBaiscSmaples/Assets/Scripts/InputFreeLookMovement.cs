using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 자율 회전 시점 카메라 기만 이동 컴포넌트
public class InputFreeLookMovement : MonoBehaviour
{
    // 이동속도
    [SerializeField] private float moveSpeed;
    // 회전 속도
    [SerializeField] private float rotateSpeed;
    // 카메라 트랜스폼 컴포넌트
    [SerializeField] private Transform camTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController cc;

    // Update is called once per frame
    void Update()
    {
        // 이동 방향키값
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 이동 방향 벡터
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        // 이동 애니메이션 새쟁
        animator.SetFloat("Move", direction.magnitude);

        // * 카메라의 회전 기준으로 캐릭터의 새로운 방향 벡터를 구함
        direction = Quaternion.AngleAxis(camTransform.rotation.eulerAngles.y, Vector3.up) * direction;

        direction.Normalize();

        // 최종 이동벡터를 계산함
        Vector3 move = direction * moveSpeed;

        // 캐릭터가 이동을 수행함
        cc.SimpleMove(move);

        // 캐릭터가 이동을 수행한다면
        if(direction != Vector3.zero)
        {
            // 캐릭터 방향에 대한 쿼터리언 회전값을 구함
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // 부드러운 캐릭터의 회전 처리를 수행항
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
