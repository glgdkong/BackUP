using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� ����
public abstract class MonsterDelayShoot : Shoot
{
    // ���� ���� �浹 ���̾�
    [SerializeField] protected LayerMask detectLayer;
    // ���� ���� ũ��
    [SerializeField] protected float detectionRange;


    protected virtual void Start()
    {
        // ���� ������ ���� ¡�� �ڷ�ƾ ����
        StartCoroutine(ShootFireballCoroutine());
    }
    // ���� ������ ���� ���� �ڷ�ƾ
    IEnumerator ShootFireballCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootRate);

            // �÷��̾�� �� ����
            DetectAndShoot();
        }
    }

    // ��� ���� ���� �߻� �޼ҵ�
    protected abstract void DetectAndShoot();

    // ���� �޼ҵ�
    protected override void Fire()
    {
        GameObject bulletGameObject = Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation);

        Movement bulletMovement = bulletGameObject.GetComponent<Movement>();
        if (bulletMovement != null )
        {
            // ���̾ �̵� ���� ����
            bulletMovement.MoveDirection = ShootDirection;
        }
    }
}
