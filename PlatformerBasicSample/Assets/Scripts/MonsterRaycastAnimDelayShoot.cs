using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRaycastAnimDelayShoot : MonsterDelayShoot
{
    [SerializeField] protected Animator animator;

    // 대상 감지 발포 메소드 재정의
    protected override void DetectAndShoot()
    {
        // 방향 전환을 위해 시선 방향으로 레이캐스트 체크를 수행함
        RaycastHit2D hit = Physics2D.Raycast(shootTransform.position, ShootDirection, detectionRange, detectLayer);
        
        // 충돌 오브젝트가 감지 되었다면
        if (hit.collider != null)
        {
            // 발포 애니메이션 재생
            animator.SetBool("IsShoot", true);
        }
        else
        {
            // 발포 애니메이션 중지
            animator.SetBool("IsShoot", false);
        }
    }
    // 대상 감지 레이캐스트 기즈모 표시 이벤트 메소드
    protected void OnDrawGizmosSelected()
    {
        // 라인 표시할 기즈모 색상을  설정함
        Gizmos.color = Color.red; // 기즈모 색상 설정
        // 레이캐스트와 같은 라인형태의 디버깅용 기즈모 선을 그려줌 
        Gizmos.DrawLine(shootTransform.position, shootTransform.position + (Vector3)ShootDirection * detectionRange);
        
    }
    // 발포 애니메이션 타임라인 이벤트 메소드
    public void ShootBulletAnimationEvent()
    {
        //Debug.Log($"{name}몬스터 총알 발포");
        Fire();
    }
}
