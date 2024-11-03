using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileGrammar : MonoBehaviour
{
    public float attackRange = 2f;
    private float distance;

    // while 문 괄호 안의 조건이 참일 때까지 반복 실행
    // 반복 횟수가 정확하지는 않지만 조건을 정확히 알고 있을 때 사용
    void Start()
    {
        /*int i = 0;
        while (i <= 100)
        {
            Debug.Log(i);
            i++;
        }*/

        // attackRange : 공격 범위(사거리)
        // distance : 적과 나 사이의 거리
        while (distance <= attackRange)
        {
            Debug.Log("공격!");
        }
    }
}
