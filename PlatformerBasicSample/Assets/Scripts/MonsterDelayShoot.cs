using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 지연 발포
public abstract class MonsterDelayShoot : Shoot
{
    // 발포 검출 충돌 레이어
    [SerializeField] protected LayerMask detectLayer;
    // 감지 영역 크기
    [SerializeField] protected float detectionRange;


    protected virtual void Start()
    {
        // 원형 오버랩 감지 징연 코루틴 생성
        StartCoroutine(ShootFireballCoroutine());
    }
    // 원형 오버랩 감지 지연 코루틴
    IEnumerator ShootFireballCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootRate);

            // 플레이어감지 및 발포
            DetectAndShoot();
        }
    }

    // 대상 감지 발포 추상 메소드
    protected abstract void DetectAndShoot();

    // 발포 메소드
    protected override void Fire()
    {
        GameObject bulletGameObject = Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation);

        Movement bulletMovement = bulletGameObject.GetComponent<Movement>();
        if (bulletMovement != null )
        {
            // 파이어볼 이동 방향 설정
            bulletMovement.MoveDirection = ShootDirection;
        }
    }
}
