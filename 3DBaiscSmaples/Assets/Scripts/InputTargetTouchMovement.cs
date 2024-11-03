using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 타겟 터치 위치 이동 컴포넌트
public class InputTargetTouchMovement : MonoBehaviour
{
    // 마우스 터치 포인트 위치
    [SerializeField] private Vector3 movePosition;

    // 이동속도
    [SerializeField] private float moveSpeed;

    // 회전속도
    [SerializeField] private float rotateSpeed;

    // 애니메이터 
    [SerializeField] private Animator animator;

    // 클릭/터치 인식용 충돌 레이어 마스크
    [SerializeField] private LayerMask touchMoveLayerMask;

    // 이동 위치 표시용 타겟 피커
    [SerializeField] private TargetPicker targetPicker;

    void Update()
    {
        // 왼쪽 마우스 클릭업을 했다면 (0 : 왼쪽 마우스 버튼, 터치여부)
        if (Input.GetMouseButtonUp(0))
        {
            // Camera.main.ScreenPointToRay(마우스 클릭/ 터치포인트화면위치-> 스크린터치위치);
            // - 화면 터치 위치에서 카메라 방향으로 발생하는 레이를 생성함
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Physics.Raycast(충돌체크레이, out 충돌정보, 길이)
            // - 충돌체크레이를 통해 충돌을 체크함
            // - hit : 충돌 정보
            RaycastHit hit;

            // 화면 클릭/터치 레이와 충돌된 정보가 있다면
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, touchMoveLayerMask))
            {
                //Debug.Log($"터치 위치 {hit.point}");

                // 이동할 위치값을 설정함
                movePosition = hit.point;

                // 타겟피커를 표시할 위치와 노말(법선) 벡터 정보를 넘겨줌
                targetPicker.Show(movePosition, hit.normal);


            }
        }

        // float 거리 = Vector3.Distance(위치벡터1, 위치벡터2) : 위치 1과 위치 2와의 거리를 구함
        float distance = Vector3.Distance(transform.position, movePosition);

        // 캐릭터가 도찾할 위치와의 거리가 0.01보다 크다면 (아직 위치에 도달하기 전이라면)
        if (distance >= 0.01f)
        {
            // 플레이어를 이동 시킴 

            // Vector 새로운 이동위치 = Vector.MoveTowards(현재위치, 최조이동위치, 이동속도 * Time.deltaTime);
            // - 부드러운 이동 수행이 필요할 때 사용
            transform.position = Vector3.MoveTowards(transform.position, movePosition, moveSpeed * Time.deltaTime);

            // 이동 방향 벡터 구하기
            Vector3 direction = (movePosition - transform.position).normalized;

            // 이동 애니메이션 재생
            animator.SetFloat("Move", 1f);

            if (direction != Vector3.zero)
            {
                // Quaternion 회저 = Quaternion.LookRotation(회전하고싶은 방향);
                // - 지정한 방향으로의 쿼터니언 회전값을 구함
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Quaternion 새로운 회전값 = Quaternion.RotateTowards(현재회전값, 최종회전, 회전속도 * Time.deltaTime);
                // -  부드러운 이동 수행이 필요할 때 사용
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            }
        }
        else // 목표위치에 도달했다면
        {
            // 최종 도착위치로 캐릭터의 위치를 설정
            transform.position = movePosition;

            // 대기 애니메이션 재생
            animator.SetFloat("Move", 0f);

            // 타겟피커 숨김
            targetPicker.Hide();
        }

    }
}