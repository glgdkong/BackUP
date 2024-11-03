using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
플레이어는 무기공격력, 방패방어력, 갑옷방어력의 수치를 가집니다.
플레이어의 모든 공격력과 방어력이 60이상이면 "현재 플레이어는 파티 리더가 되는게 (true/false)입니다" 문장을 출력하세요.

플레이어의 공격력이 60 이상이거나 방패와 갑옷 방어력이 60이상이면
"현재 플레이어는 파티원이 되는게 (true/false) 입니다."라는 문장을 출력하세요.

*/

public class 논리연산자연습컴포넌트 : MonoBehaviour
{
    //플레이어의 수치 변수를 선언
    public int WeaponDamage;
    public int ShieldDefensePoint;
    public int ArmorDefensePoint;

    // Start is called before the first frame update
    void Start()
    {
        //플레이어의 파티리더 및 파티원 가능 조건에 대한 결과 문장 출력
        Debug.Log($"현재 플레이어의 무기공격력은 {WeaponDamage}, 방패방어력은 {ShieldDefensePoint}, 갑옷방어력은 {ArmorDefensePoint}입니다.");

        bool PartyLeader = (WeaponDamage >= 60) && (ShieldDefensePoint >= 60) && (ArmorDefensePoint >= 60);
        Debug.Log($"현재 플레이어는 파티 리더가 되는게 {PartyLeader}입니다");

        bool PartyMember = (WeaponDamage >= 60) || ((ShieldDefensePoint >= 60) && (ArmorDefensePoint >= 60));

        Debug.Log($"현재 플레이어는 파티원이 되는게 {PartyMember}입니다");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
