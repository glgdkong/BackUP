using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // 상속관계에서만 접근가능한 접근 제한자 : protected
    // 몬스터를 구성하는 속성
    protected string Name;
    protected int hp;
    protected int level;
    protected float damage;
    protected int gold;

    //몬스터의 정보를 출력하는 기능
    protected void MonsterInfo()
    {
        Debug.Log(name + " 체력 : " + hp);
        Debug.Log(name + " 레벨 : " + level);
        Debug.Log(name + " 데미지 : " + damage);
        Debug.Log(name + " 골드 : " + gold);
    }

}
