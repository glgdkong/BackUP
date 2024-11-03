using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO타격컴포넌트 : MonoBehaviour
{
    public Color 타격색상;

    public SpriteRenderer 스프라이트렌더러컴포넌트참조변수;

    public void 타격하기()
    {
        Debug.Log($"UFO가 타격을 입어 색상이 {타격색상} 색으로 변하였습니다.");

        Debug.Log($"타격 전 UFO 색상 {스프라이트렌더러컴포넌트참조변수.color} ");

        // 스프라이트렌더러에서 렌더링하고 있는 스프라이트의 색상을 변경함
        스프라이트렌더러컴포넌트참조변수.color = 타격색상;

        Debug.Log($"타격 후 UFO 색상 {스프라이트렌더러컴포넌트참조변수.color} ");
    }
}
