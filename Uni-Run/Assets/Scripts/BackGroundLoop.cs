using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;

    private Vector3 offset;

    void Start()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        // 콜라이더의 사이즈 x가 폭을 의미한다.
        width = box.size.x;

        // 스타트 함수에서 한 번만 메모리 소모
        offset = new Vector3(width * 2f, 0, 0);
    }

    void Update()
    {
        // 배경의 위치의 x값이 폭만큼 왼쪽으로 이동했을 때
        if(transform.position.x <= -width)
        {
            // -20 + 40 = 20
            // new 연산자를 사용하면 메모리가 소모된다.
            // 스타트에서 할당해 놓은 오프셋 변수를 사용한다. (메모리 최적화 측면)
            transform.position += offset;
        }
    }
}
