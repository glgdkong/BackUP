using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ��� �߻� ������Ʈ 
public abstract class Shoot : MonoBehaviour
{
    // ���� ��ġ ���� ������Ʈ�� Ʈ������ ������Ʈ
    [SerializeField] protected Transform shootTransform;

    // ���� ����
    [SerializeField] private Vector2 shootDirection;
    public Vector2 ShootDirection { get => shootDirection; set => shootDirection = value; }

    // ���� �ֱ�
    [SerializeField] protected float shootRate;

    // ���� �ð� ���� ����
    protected float time;

    // �Ѿ� ������
    [SerializeField] protected GameObject bulletPrefab;

    // ���� ����
    protected abstract void Fire();
}
