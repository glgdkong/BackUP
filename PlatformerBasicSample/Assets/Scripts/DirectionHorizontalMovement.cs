using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 수평 방향 이동 처리 컴포넌트
public class DirectionHorizontalMovement : DirectionMovement
{
    // 오른쪽 시선 여부
    [SerializeField] protected bool isRight = true;
    public bool IsRight { get => isRight; set => isRight = value; }

    public void SetDirection(Vector2 direction, bool isRight)
    {
        MoveDirection = direction;
        // 현재 이동방향과 발포 방향이 반대면
        if ((this.isRight && !isRight )|| (!this.isRight && isRight))
        {
            // 이동방향을 반전함
            Flip();
        }
    }


    // 캐릭터 X축 반전 처리 및 오른쪽 시선값 변경
    protected virtual void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        IsRight = !isRight;
    }
}
