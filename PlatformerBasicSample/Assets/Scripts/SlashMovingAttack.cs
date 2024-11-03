using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 슬래시 이동 공격 컴포넌트
public class SlashMovingAttack : MonoBehaviour
{
    // 공격 중 여부
    private bool isAttack = false;
    public bool IsAttack { get => isAttack; set => isAttack = value; }

    // 공격 체크 Transform
    [SerializeField] private Transform checkTransform;

    // 슬래시 공격 감지 거리(레이캐스트 길이)
    [SerializeField] private float detectionDistance;

    // 이동 컴포넌트 
    [SerializeField] private Movement movement;

    // 오리지널 이동 속도
    private float originSpeed;

    // 슬래시 공격 속도
    [SerializeField] private float attackSpeed;

    // 공격 대상 충돌 레이어
    [SerializeField] private LayerMask detectLayer;

    // 슬래시 공격 시간
    [SerializeField] private float movingAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        originSpeed = movement.MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    // 이동 처리
    public void Attack()
    {
        // 공격 수행을 위해 레이캐스트 체크를 수행함
        RaycastHit2D hit = Physics2D.Raycast(checkTransform.position, movement.MoveDirection, detectionDistance, detectLayer);

        // 공격 대상 오브젝트가 있다면
        if (hit.collider != null && !isAttack)
        {
            // 슬래시 이동 공격을 수행함
            StartCoroutine(MovingAttackCoroutine());
        }
    }

    // 이동 공격 처리 코루틴
    IEnumerator MovingAttackCoroutine()
    {
        // 공격 시작
        isAttack = true;
        // 이동 속도 증가
        movement.MoveSpeed = attackSpeed; 
        // 슬래시 공격 시간 동안 대기
        yield return new WaitForSeconds(movingAttackTime);
        // 이동속도 복원
        movement.MoveSpeed = originSpeed;
        // 공격 종료
        isAttack = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(checkTransform.position, checkTransform.position + new Vector3(movement.MoveDirection.x, 0, 0) * detectionDistance);

    }
}
