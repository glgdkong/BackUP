using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� �̵� ó�� ������Ʈ
public class DirectionMovement : Movement
{
    protected float angle; // �̵� ���⿡ ���� ȸ�� ����

    // �̵� ���⿡ ���� ȸ�� ���� ������Ƽ
    public float Angle
    {
        set => angle = value;
        get
        {
            // ��ũ ź��Ʈ2 �޼ҵ带 �̿��� 2D ���� ������ ȸ�� ����(��׸�)�� ����
            float raian = Mathf.Atan2(MoveDirection.y, MoveDirection.x);
            angle = raian * Mathf.Rad2Deg;
            return angle;
        }
    }
    // ���� ���� �޼ҵ� (������Ƽ�� �̿��ص� ��
    public void SetDirection(Vector2 direction)
    {
        MoveDirection = direction;
    }

    protected virtual void Update()
    {
        Move();
    }

    // �̵� ó�� �޼ҵ�
    protected override void Move()
    {
        // �̵��ӵ� �� ���� ����
        rigidbody2D.velocity = MoveDirection.normalized * MoveSpeed;
    }
}
