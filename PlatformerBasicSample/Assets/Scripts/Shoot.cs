using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 발포 기능 추상 컴포넌트 
public abstract class Shoot : MonoBehaviour
{
    // 발포 위치 게임 오브젝트의 트랜스폼 컴포넌트
    [SerializeField] protected Transform shootTransform;

    // 발포 방향
    [SerializeField] private Vector2 shootDirection;
    public Vector2 ShootDirection { get => shootDirection; set => shootDirection = value; }

    // 발포 주기
    [SerializeField] protected float shootRate;

    // 발포 시간 계산용 변수
    protected float time;

    // 총알 프리펩
    [SerializeField] protected GameObject bulletPrefab;

    // 발포 시행
    protected abstract void Fire();
}
