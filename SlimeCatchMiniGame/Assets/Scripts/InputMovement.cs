using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 8방향 캐릭터 키보드 이동

public class InputMovement : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // 수평 방향키값
        float h = Input.GetAxis("Horizontal");
        // 수직 방향키값
        float v = Input.GetAxis("Vertical");

        // 방향벡터를 구하고 정규화(크기가 1짜리 벡터로 변경)를 수행함
        // Vector3 direction = new Vector3(h, 0f, v);
        // Vector3 normalDirection = direction.normalized;
        Vector3 normalDirection = new Vector3(h, 0f , v).normalized;

        // 벡터의 더하기 연산을 수행해 이동 크기와 방향이 반영된 이동 위치로 변경함
        // 이동 위치 = 이전이동위치 + (방향 * 이동크기 * Time.deltaTime);
        transform.position += normalDirection * moveSpeed * Time.deltaTime;

        // 애니메이션 파라미터 설정
        animator.SetFloat("Speed", normalDirection.magnitude);

        // 캐릭터 방향회전 
        // * transform.LookAt(회전해서 바라볼위치(Vector3))
        transform.LookAt(transform.position + normalDirection);

        
    }
}
