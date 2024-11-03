using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 발포 기능 컴포넌트
public class PlayerInputShoot : Shoot
{
    // 이동 컴포넌트 참조
    [SerializeField] protected PlayerInputMovement movement;

    protected void Update()
    {
        Fire();
    }

    // 발포 처리
    protected override void Fire()
    {
        // 발포 시간 계산
        time += Time.deltaTime;

        // 왼쪽 컨트롤 키를 눌렀고 발포 시간이 지났고 현재 캐릭터가 바닥에 착지 중이면
        if (Input.GetKey(KeyCode.LeftControl) && shootRate <= time && movement.IsGrounded )
        {
            // 총알을 생성함
            GameObject bullet = Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation );

            // 총알의 방향을 발포 방향 위치로 설정함
            bullet.GetComponent<DirectionHorizontalMovement>().SetDirection((movement.IsRight) ? shootTransform.right : -shootTransform.right, movement.IsRight);

            // 발포 시간 계산 변수 초기화
            time = 0;

        }
    }
}
