using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 영역 감시 지연 발포
public class MonsterOverlapDelayShoot : MonsterDelayShoot
{
    // 영역 감시 위치
    [SerializeField] protected Transform overlapTransform;

    // 영역 감지 발포 메소드 재정의
    protected override void DetectAndShoot()
    {
        // * 원형 충돌 감지 
        // - Collider2D[] 감지대상의콜라이더컴포넌트참조들 = Physics2D.OverlapCircleAll(영역감지위피, 영역크기(반지름), 충돌감지레이어)
        // - 종류 : 포인트(점), 원형, 사각형, 캡슐, 영역


        // 원형 형태의 영역 충돌 대상 감지를 수행
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(overlapTransform.position, detectionRange, detectLayer);

        // 충돌체 중에 플레이어가 존재하는지를 파악
        foreach (var hitCollider in hitColliders)
        {
            // 플레이어가 감지 대상에 존재한다면
            if (hitCollider.CompareTag("Player"))
            {
                // 플레이어를 향한 방향 벡터를 계산함
                Vector2 targetPosition = hitCollider.transform.position;
                Vector2 monsterPosition = shootTransform.position;  

                // 발포 방향을 설정함
                ShootDirection = (targetPosition - monsterPosition).normalized;

                // 총알 발사
                Fire();
                return;

            }
        }
    }

    // 대상 감지 영역 기즈모 선택 표시 이벤트 메소드
    private void OnDrawGizmosSelected()
    {
        // 영역 표시할 기즈모 색상을 설정함
        Gizmos.color = Color.red;
        // 오버랩 감지 영역과 같은 원형형태의 디버깅용 기즈모 선을 그려줌
        Gizmos.DrawWireSphere(overlapTransform.position, detectionRange);
    }
}
