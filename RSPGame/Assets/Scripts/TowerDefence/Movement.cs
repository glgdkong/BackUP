using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // 외부에 변수를 공개하기 위해서 public 선언을 했었는데
    // 사실 이방법은 선호하지 않는 방식이다.
    // 프로그래밍의 은닉성에 의해 변수는 철저히 감춰야 한다.

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Vector3 moveDirection;

    // 프로퍼티 : 외부에 공개하고 싶은 변수를 공개하는 방식
    // 외브에서 값을 할당하는 기능인 setter와
    // 외부에서 값을 가져가는 기능인 getter로 나누어져 있다.

    // 게터와 세터 모두 가능한 프로퍼티의 형태
    // public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    // 게터만 가능한 프로퍼티 형태
    public float MoveSpeed => moveSpeed;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
    }

}
