using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 랜덤 이동 처리 컴포넌트
public class RandomMovement : MonoBehaviour
{
    // 바닥 게임오브젝트 Transform 컴포넌트
    [SerializeField] protected float moveSpeed; // 이동 속도
    [SerializeField] private float rotateSpeed; // 회전 속도
    private float waitTime; // 대기시간
    [SerializeField] private float minWaitTime; // 최소 대기시간
    [SerializeField] private float maxWaitTime; // 최대 대기시간
    [SerializeField] protected float randomRange; // 랜덤 위치 범위(x,y)

    protected Vector3 targetPosition; // 이동할 위치
    protected bool isMove = false; // 이동 여부
    protected float time; // 시간 계산용 변수
    protected float originSpeed; // 이동속도 저장할 변수 생성

    protected Animator animator; // 애니메이터 컴포넌트

    // 이동할 랜덤 위치 뽑기
    private void SetRandomTargetPosition()
    {
        // 랜덤 타겟 위치 벡터 생성
        Vector3 randomPosition = new Vector3(Random.Range(-randomRange, randomRange), 0 , Random.Range(-randomRange, randomRange));
        
        // 랜덤 위치를 이동할 위치로 설정
        targetPosition = randomPosition;

        // 대기시간을 랜덤하게 추첨함
        waitTime = Random.Range(minWaitTime, maxWaitTime);

        isMove = true; // 이동 시작
        animator.SetBool("IsMove", isMove); // 이동에 대한 애니메이션 처리
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SetRandomTargetPosition();
        originSpeed = moveSpeed; // 이동 속도 저장
    }

    // Update is called once per frame
    void Update()
    {

        if (!isMove) // 이동 중지 상태면
        {
            // 시간 계산(타이머)
            time += Time.deltaTime;
            if (time >= waitTime)
            {
                // 랜덤 위치 설정
                SetRandomTargetPosition();
                time = 0; // 대기 시간 계산용 변수 초기화
            }
        }
        else // 이동 상태면
        {
            // 이동 및 회전처리
            MoveTargetPosition();
        }
    }

    // 타겟 위치로 이동 처리
    private void MoveTargetPosition()
    {
        // 이동 처리
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Quaternion 방향벡터를 향하는 회전 = Quaternion.LookRotation(방향 벡터)
        Quaternion targetRotation = Quaternion.LookRotation((targetPosition - transform.position).normalized);

        // Quaternion.RotateTowards(현재 회전, 회전하여는 회전, 회전속도)
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        
        // 이동하려는 위치에 거의 도착했다면
        // float 거리 = Vector.Distance(위치1, 위치2);
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMove = false; // 이동 중지 상태값 설정
            animator.SetBool("IsMove", isMove); // 이동 중지에 대한 애니메이션 처리
        }
    }

    public void Stop() // 이동 정지
    {
        moveSpeed = 0; // 이동속도를 0으로
    }
    public void Resume() // 이동 재개
    {
        moveSpeed = originSpeed; // 이동속도 복원
    }
}
