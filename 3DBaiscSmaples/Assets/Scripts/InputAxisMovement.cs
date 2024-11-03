using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 컨트롤 Axis 방향으로 이동 밑 회전을 수행하는 컴포넌트
public class InputAxisMovement : MonoBehaviour
{
    // 애니메이터 컴포넌트
    [SerializeField] private Animator animator;
    // 캐릭터 컨트롤러 컴포넌트
    [SerializeField] private CharacterController cc;
    // 이동 속도
    [SerializeField] private float moveSpeed;
    // 회전 속도
    [SerializeField] private float rotateSpeed;


    // Update is called once per frame
    void Update()
    {
        // 방향키 입력값 추출
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 방향 벡터 생성
        Vector3 direcrion = new Vector3(h, 0f, v).normalized;

        // direcrion.magnitude : 벡터의 길이 (상수)
        animator.SetFloat("Move", direcrion.magnitude);

        // 이동벡터 생성
        Vector3 movement = direcrion * moveSpeed;

        // 캐릭터 컨트롤러를 이용한 이동 처리
        //CharacterController.SimpleMove(이동벡터) : 이동 벡터 방향과 크기로 캐릭터 컨트롤러를 이용해 이동 처리
        cc.SimpleMove(movement);

        // Transform.LookAt(위치) : 지정한 위치를 바라보도록 회전처리함
        // 현재 위치에서 방향벡터를 더한 방향을 바라보도록 즉시 회전함
        //transform.LookAt(transform.position + direcrion);

        if(direcrion != Vector3.zero)
        {
            // 방향에 대한 회전을 구함
            Quaternion targetRotation = Quaternion.LookRotation(direcrion, Vector3.up);
            // 지정된 속도로 부드럽게 회전함
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
        
    }
}
