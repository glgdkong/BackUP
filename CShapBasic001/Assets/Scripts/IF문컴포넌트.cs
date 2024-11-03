using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF문컴포넌트 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 조건문 예시1
        /*int hp = 100;
        int damage = Random.Range(10, 131);

        // 데미지를 입은 캐릭터가 체력을 소진하는 연산식 (산술/대입 연산자를 활용)
        hp -= damage;
        Debug.Log($"플레이어 피격 당함 -> 현재 체력은{hp} 받은 데미지는{damage}");*/

        /*//체력이 0보다 작거나 같으면 사망메시지 표현을 아니명 생존 메시지 표현을 수행 (조건식(관계/논리/관계+논리), 조건문(if))
        bool isAlive = hp > 0; // 생존상태여부가 조건의 기준
        bool isDead = hp <= 0; // 사망상태여부가 조건의 기준

        if(isAlive)
        {
            Debug.Log("플레이어가 생존했습니다.");
            Debug.Log($"플레이어 피격 애니메이션 수행합니다");
            Debug.Log($"플레이어 반격 애니메이션 수행합니다");
        }
        if (isDead)
        {
            Debug.Log("플레이어가 사망했습니다.");
            Debug.Log($"플레이어 사망 애니메이션 수행합니다");
            Debug.Log($"플레이어 사망 알림 메시지 출력합니다");
            Debug.Log("게임 종료 처리합니다");
        }*/


        /*
        //체력이 0보다 작거나 같으면 사망메시지 표현을 아니명 생존 메시지 표현을 수행 (조건식(관계/논리/관계+논리), 조건문(if))
        if (hp > 0)
        {
            Debug.Log("플레이어가 생존했습니다.");
            Debug.Log($"플레이어 피격 애니메이션 수행합니다");
            Debug.Log($"플레이어 반격 애니메이션 수행합니다");
        }
        if (hp <= 0)
        {
            Debug.Log("플레이어가 사망했습니다.");
            Debug.Log($"플레이어 사망 애니메이션 수행합니다");
            Debug.Log($"플레이어 사망 알림 메시지 출력합니다");
            Debug.Log("게임 종료 처리합니다");
        }
        */

        /*if (hp > 0)
        {
            Debug.Log("플레이어가 생존했습니다.");
            Debug.Log($"플레이어 피격 애니메이션 수행합니다");
            Debug.Log($"플레이어 반격 애니메이션 수행합니다");
        }
        else // 두개의 조건이 상반된 조건식일 경우 두번째 조건은 생략 -> if (hp <= 0) 생략
        {
            Debug.Log("플레이어가 사망했습니다.");
            Debug.Log($"플레이어 사망 애니메이션 수행합니다");
            Debug.Log($"플레이어 사망 알림 메시지 출력합니다");
            Debug.Log("게임 종료 처리합니다");
        }*/

        // [구현 해야할 내용]
        // 1. 플레이어가 랜덤하게 가해지는 몬스터의 공격을 받아 체력이 감소함
        // 2. 이때 감소된 체력을 기준으로 [알림 메시지]를 출력함
        // [기준(조건)]
        //      조건1) [체력이 0 이하]일 때
        //           -> 메시지: [플레이어가 사망했습니다.]
        //      조건1) [체력이 30 ~ 1 사이]일 때
        //           -> 메시지: [플레이어가 위험합니다.]
        //      조건1) [체력이 60 ~ 31 사이]일 때
        //           -> 메시지: [플레이어가 체력이 부족합니다.]
        //      조건1) [체력이 60 이상]일 때
        //           -> 메시지: [플레이어가 체력이 일정량 감소했습니다.]
        // 3. 마지막에 플레이어가 [사망한 상태가 아니라면] 플레이어의 [남은 체력을 표시]해 줄것

        // * if 문만 사용해서 구현해 보세요.
        // * 플레이어의 [체력은 100] [랜덤 데미지의 범위는 10 ~ 120] 입니다.

        int hp = 100;
        int minDamage = 10;
        int maxDamage = 121;
        int damage = Random.Range(minDamage, maxDamage);    // Random.Range(10, 121); == 10 ~ 120 사이의 랜덤한 값
        

        hp -= damage;
        /*if(hp <= 0)
        {
            Debug.Log($"플레이어가 {damage}피해를 받아 사망했습니다.");
        }
        if (hp <= 30 && hp >= 1)
        {
            Debug.Log($"플레이어가 {damage}피해를 받아 위험합니다.");
        }
        if (hp < 60 && hp >= 31)
        {
            Debug.Log($"플레이어가 {damage}피해를 받아 체력이 부족합니다.");
        }
        if (hp >= 60)
        {
            Debug.Log($"플레이어가 {damage}피해를 받아 체력이 일정량 감소했습니다.");
        }
        if (hp > 0)
        {
            Debug.Log($"플레이어가 생존하였습니다. 플레이어의 남은 체력은 {hp} 입니다.");
        }*/

        /*if (hp <= 0)
        {
            Debug.Log($"플레이어가 {damage}피해를 받아 사망했습니다.");
        }
        else
        {
            if (hp <= 30 && hp >= 1)
            {
                Debug.Log($"플레이어가 {damage}피해를 받아 위험합니다.");
            }
            if (hp < 60 && hp >= 31)
            {
                Debug.Log($"플레이어가 {damage}피해를 받아 체력이 부족합니다.");
            }
            if (hp >= 60)
            {
                Debug.Log($"플레이어가 {damage}피해를 받아 체력이 일정량 감소했습니다.");
            }
                Debug.Log($"플레이어가 생존하였습니다. 플레이어의 남은 체력은 {hp} 입니다.");
        }*/

        /*if (hp <= 0)
        {
            Debug.Log($"플레이어가 {damage}피해를 받아 사망했습니다.");
        }
        else
        {
            if (hp >= 60)
            {
                Debug.Log($"플레이어가 {damage}피해를 받아 체력이 일정량 감소했습니다.");
            }
            else if (hp >= 31)
            {
                Debug.Log($"플레이어가 {damage}피해를 받아 체력이 부족합니다.");
            }
            else
            {
                Debug.Log($"플레이어가 {damage}피해를 받아 위험합니다.");
            }
                Debug.Log($"플레이어가 생존하였습니다. 플레이어의 남은 체력은 {hp} 입니다.");
        }*/





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
