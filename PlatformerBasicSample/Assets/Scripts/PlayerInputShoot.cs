using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� ���� ��� ������Ʈ
public class PlayerInputShoot : Shoot
{
    // �̵� ������Ʈ ����
    [SerializeField] protected PlayerInputMovement movement;

    protected void Update()
    {
        Fire();
    }

    // ���� ó��
    protected override void Fire()
    {
        // ���� �ð� ���
        time += Time.deltaTime;

        // ���� ��Ʈ�� Ű�� ������ ���� �ð��� ������ ���� ĳ���Ͱ� �ٴڿ� ���� ���̸�
        if (Input.GetKey(KeyCode.LeftControl) && shootRate <= time && movement.IsGrounded )
        {
            // �Ѿ��� ������
            GameObject bullet = Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation );

            // �Ѿ��� ������ ���� ���� ��ġ�� ������
            bullet.GetComponent<DirectionHorizontalMovement>().SetDirection((movement.IsRight) ? shootTransform.right : -shootTransform.right, movement.IsRight);

            // ���� �ð� ��� ���� �ʱ�ȭ
            time = 0;

        }
    }
}
