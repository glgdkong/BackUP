using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 관계연산자컴포넌트 : MonoBehaviour
{

    public int value1;
    public int value2;

    public int hp; //체력변수

    public void RandomMonsterHit(int num)
    {
        int minDamage = 10;
        int maxDamage = 51;
        int damage = Random.Range(minDamage, maxDamage);
        hp -= damage;
        Debug.Log($"플레이어가 {num}째 공격을 몬스터에게 {damage}의 데미지를 입혀 {hp}의 체력이 남았습니다.");
    }



    // Start is called before the first frame update
    void Start()
    {
        


        Debug.Log($"{value1}은 {value2}이랑 같은게 {value1 == value2} 입니다.");
        Debug.Log($"{value1}은 {value2}이랑 같은 않은게 {value1 != value2} 입니다.");

        bool result = value1 >= value2;

        Debug.Log($"{value1}은 {value2}이랑 큰게 {result} 입니다.");

        // int damage = Random.Range(가장 작은값, 가장 큰값 + 1);

        // * 랜덤하게 3회 타격을 받음 (타격 크기 10 ~ 100)

        // * HP를 판정하여 생존여부를 결정

        //Debug.Log($"몬스터는 생존한게 {true/false}입니다.");

        int count = 0;
        int minDamage = 10;
        int maxDamage = 51;


        // 플레이어한테 몬스터가 1회 타격을 받음
        RandomMonsterHit(++count);
        //int damage = Random.Range(minDamage, maxDamage);
       // hp -= damage;
        //Debug.Log($"플레이어가 {++count}째 공격을 몬스터에게 {damage}의 데미지를 입혀 {hp}의 체력이 남았습니다.");

        // 출력문 표시 -> 플레이어가 ??째 공격을 몬스터에게 [??]의 데미지를 입혀 [??]의 체력이 남았습니다.


        // 플레이어한테 몬스터가 2회 타격을 받음
        RandomMonsterHit(++count);
        //damage = Random.Range(minDamage, maxDamage);
        //hp -= damage;
        //Debug.Log($"플레이어가 {++count}째 공격을 몬스터에게 {damage}의 데미지를 입혀 {hp}의 체력이 남았습니다."); ;


        // 플레이어한테 몬스터가 3회 타격을 받음
        RandomMonsterHit(++count);
        //damage = Random.Range(minDamage, maxDamage);
        //hp -= damage;
        //Debug.Log($"플레이어가 {++count}째 공격을 몬스터에게 {damage}의 데미지를 입혀 {hp}의 체력이 남았습니다.");


        bool isAlive = hp > 0;
        Debug.Log($"몬스터는 생존한게 {isAlive}입니다.");





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
