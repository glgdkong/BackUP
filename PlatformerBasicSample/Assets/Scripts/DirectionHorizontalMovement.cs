using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� �̵� ó�� ������Ʈ
public class DirectionHorizontalMovement : DirectionMovement
{
    // ������ �ü� ����
    [SerializeField] protected bool isRight = true;
    public bool IsRight { get => isRight; set => isRight = value; }

    public void SetDirection(Vector2 direction, bool isRight)
    {
        MoveDirection = direction;
        // ���� �̵������ ���� ������ �ݴ��
        if ((this.isRight && !isRight )|| (!this.isRight && isRight))
        {
            // �̵������� ������
            Flip();
        }
    }


    // ĳ���� X�� ���� ó�� �� ������ �ü��� ����
    protected virtual void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        IsRight = !isRight;
    }
}
