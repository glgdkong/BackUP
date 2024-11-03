using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string name;
    private int hp;
    private int lv;
    private int damage;
    private bool isDead;
    

    public Player(string name)
    {
        this.name = name;
        hp = 500;
        lv = 1;
        damage = 20;
        isDead = false;
    }

    public void PrintStat()
    {
        Debug.Log($"플레이어 {name}의 스탯 체력: {hp}, 레벨: {lv}, 공격력: {damage}");
    }
    public int Attack()
    {
        int critical = Random.Range(0, 100);
        if (critical <= 9)
        {
            Debug.Log("A singular strike!");
            Debug.Log($"{name}이가 {2 * damage}만큼의 데미지로 공격합니다.");
            return damage * 2;
        }
        else
        {
            Debug.Log($"{name}이가 {damage}만큼의 데미지로 공격합니다.");
            return damage;
        }
    }
    public void Hit(int damage)
    {
        if (!isDead) 
        {
            hp -= damage;
            if (hp <= 0)
            {
                hp = 0;
                Debug.Log($"{name}이의 체력이 0이되어 사망합니다.");
                isDead = true;
            }
            else
            {
                Debug.Log($"{name}이가 {damage}만큼의 공격을 받아 체력이 {hp}로 감소합니다.");
            }
        }
        else
        {
            Debug.Log($"{name}은 이미 사망하였습니다.");
        }
    }
}



public class Class : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Player player1 = new Player("아무이름");
        Player player2 = new Player("플레이어2");
        player1.PrintStat();
        player1.Hit(100);
        player2.Hit(player1.Attack());
        player2.PrintStat();
        

    }
}
