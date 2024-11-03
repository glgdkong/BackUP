using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 증가감연산자컴포넌트 : MonoBehaviour
{
    public int 카운트;
    // Start is called before the first frame update
    void Start()
    {
        // 3번의 카운트를 누적 연산하는 수식 (갯수를 증가하는 수식)
        카운트 = 카운트 + 1; // 1을 증가
        카운트 += 1; // 1을 증가
        카운트++; // 1을 증가 (증가감 연산자의 ++ 연산자를 사용)

        Debug.Log($"카운트 3번을 증가한 카운트 변수의 결과값 : {카운트}");

        // 3번의 카운트를 누적 연산하는 수식 (갯수를 감소하는 수식)
        카운트 -= 1; // 1을 감소
        카운트--; // 1을 감소 (증가감 연산자의 -- 연산자를 사용)
        // *주의 : 증가감 연산자는 오로지 ++, -- 연산자만 존재함 (** 같은 연산자는 존재하지 않음)

        Debug.Log($"카운트 2번을 감소한 카운트 변수의 결과값 : {카운트}");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
