using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NavigationMovement : MonoBehaviour
{
    // 네비메쉬에이전트
    private NavMeshAgent navMeshAgent;
    // 애니메이터
    private Animator animator;
    // 이동 여부
    private bool isMoving;
    // 바닥 레이어
    [SerializeField] private LayerMask layerMask;
    // 이동 타겟 픽커
    [SerializeField] private TargetPicker targetPicker;
    // 점프 높이
    [SerializeField] private float jumpHeight;
    // 점프 지속시간
    [SerializeField] private float jumpDuration;
    // 오프메쉬링크 이동 속도
    [SerializeField] private float offMeshLinkSpeed;
    // 원본 이동속도
    private float originalSpeed;
    // 점프상태 여부
    private bool isJump;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // 에이전트 이동속도 백업
        originalSpeed = navMeshAgent.speed; 
        
    }

    IEnumerator Jump()
    {
        isJump = true; // 점프 수행 상태 설정

        // * OffMeshLinkData : 오프에쉬링크 정보
        // - startPos : OffMeshLink 시작 위치
        // - endPos : OffMeshLink 종료 위치
        // - linkType : 양방향인지, 단방향인지 여부
        // - area : 네비게이션 Area
        // - activated : OffMeshLink 활성상태 여부
        OffMeshLinkData data = navMeshAgent.currentOffMeshLinkData;

        // 점프 시작 위치를 현재 에이전트 위치로 설정
        Vector3 startPos = navMeshAgent.transform.position;

        // 점프 종료 위치를 설정
        Vector3 endPos = data.endPos + Vector3.up * navMeshAgent.baseOffset;

        // 점프 경과 시간 (계산용)
        float elapsedTime = 0f;

        // 점프가 지속되는 동안 점프 표현 처리
        while (elapsedTime < jumpDuration)
        {
            // 경과 시간에 따른 점프의 진행률 계산
            float t = elapsedTime / jumpDuration;

            // 시간에 따른 점프의 높이를 조절 (수직 파동 처리)
            float height = Mathf.Sin(Mathf.PI * t) * jumpHeight;

            animator.SetFloat("Vertical", height);
            
            // 점프 중에 에이전트의 수직 위치를 보간 이동 처리함(부드럽게 점프의 이동을 표현)
            navMeshAgent.transform.position = Vector3.Lerp(startPos, endPos, t) + Vector3.up * height;

            // 경과시간 업데이트 
            elapsedTime += Time.deltaTime;

            // Update 실행 주기화 맞춰줌
            yield return null;

        }
        // 오프메쉬링크 이동을 완료함
        navMeshAgent.CompleteOffMeshLink();

        // 점프 완료 상태로 변경
        isJump = false;

    }

    // Update is called once per frame
    void Update()
    {
        // 왼쪽 마우스 버튼을 클릭함
        if (Input.GetMouseButtonDown(0))
        {
            // 화면 터치 레이를 생성함
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 화면 터치 충동 정보
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                // 마우스로 클리한 위치로 에이전트를 이동시킴
                // * navMeshAgent.SetDestination(이동 위치); : 지정한 이동 위치로 에이전트를 이동시킴
                navMeshAgent.SetDestination(hit.point);
                // * navMeshAgent.isStopped : 에이전트의 이동 멈춤 여부
                // navMeshAgent.isStopped = true;
                isMoving = true;

                // 타겟픽커 표시(충돌위치, 충돌수직벡터)
                targetPicker.Show(hit.point, hit.normal);
            }
        }

        // * navMeshAgent.pathPending : 네비게이션의 경로를 계산 중 상태
        if (!navMeshAgent.pathPending && isMoving)
        {
            // * navMeshAgent.remainingDistance : 목표 도달하기까지의 남은 거리
            // * navMeshAgent.StoppingDistance : 도착하기 전에 멈추는 설정 거리
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                // * navMeshAgent.hasPath : 유효한 이동 경로를가지고 있는지 여부
                // * navMeshAgent.velocity.sqrMagnitude : 현재 에이전트의 이동 속도
                if (navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    isMoving = false;

                    // 타겟 피커 숨김
                    targetPicker.Hide();
                }
            }
        }
        // 이동 애니메이션 재생
        animator.SetBool("IsMoving", isMoving);

        // * navMeshAgent.isOnOffMeshLink : 현재 오프메쉬링크 위에 있는지 여부
        // 현재 캐릭터가 오프메쉬링크에 진입했지만 아직 점프를 안했다면
        if (navMeshAgent.isOnOffMeshLink && !isJump)
        {
            // 오프메쉬링크 이동속도로 에이전트 속도를 변경
            navMeshAgent.speed = offMeshLinkSpeed;
            // 점프 애니메이션 수행
            animator.SetTrigger("Jump");

            // 점프 효과 코루틴 실행
            StartCoroutine(Jump());
        }
        else // 현재 캐릭터가 오프메쉬링크를 벗어가고 점프가 이루어진 상태면
        {
            // 에이전트의 속도를 이동속도로 복원함
            navMeshAgent.speed = originalSpeed;
        }
    }
}
