using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// UFO 이동하기 클래스(컴포넌트)
public class UFO이동컴포넌트 : MonoBehaviour
{
    public Transform 유니티트랜스폼컴포넌트참조변수;

    public float 이동속도; // 이동 속도 변수

    public void 입력이동처리하기()
    {
        // 방향 입력키값 구함
        float 좌우키값 = Input.GetAxisRaw("Horizontal");
        float 위아래키값 = Input.GetAxisRaw("Vertical");

        // 이동 방향 벡터 생성
        Vector2 이동벡터 = new Vector2(좌우키값, 위아래키값);

        //Debug.Log($"이동방향벡터 : {이동벡터}");

        // Transform.Translate 메소드
        // Transform참조변수.Translate(이동벡터 * 속도 *  Time.deltaTime)

        // 유니티의 Trnasform 컴포넌트이 참조변수를 통해 Translate 메소드를 실행함
        유니티트랜스폼컴포넌트참조변수.Translate(이동벡터 * 이동속도 * Time.deltaTime);
    }
}
