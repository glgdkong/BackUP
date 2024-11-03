using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 변수유효범위테스트컴포넌트 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Debug.Log($"카운트 후 스태틱변수 (다른컴포넌트(다른객체)의 Update) : {변수유효범위컴포넌트.스태틱변수}");
        //Debug.Log($"카운트 후 클래식멤버변수 (다른컴포넌트(다른객체)의 Update) : {클래식멤버변수}");
    }
}
