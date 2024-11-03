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
        Debug.Log($"�÷��̾� {name}�� ���� ü��: {hp}, ����: {lv}, ���ݷ�: {damage}");
    }
    public int Attack()
    {
        int critical = Random.Range(0, 100);
        if (critical <= 9)
        {
            Debug.Log("A singular strike!");
            Debug.Log($"{name}�̰� {2 * damage}��ŭ�� �������� �����մϴ�.");
            return damage * 2;
        }
        else
        {
            Debug.Log($"{name}�̰� {damage}��ŭ�� �������� �����մϴ�.");
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
                Debug.Log($"{name}���� ü���� 0�̵Ǿ� ����մϴ�.");
                isDead = true;
            }
            else
            {
                Debug.Log($"{name}�̰� {damage}��ŭ�� ������ �޾� ü���� {hp}�� �����մϴ�.");
            }
        }
        else
        {
            Debug.Log($"{name}�� �̹� ����Ͽ����ϴ�.");
        }
    }
}



public class Class : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Player player1 = new Player("�ƹ��̸�");
        Player player2 = new Player("�÷��̾�2");
        player1.PrintStat();
        player1.Hit(100);
        player2.Hit(player1.Attack());
        player2.PrintStat();
        

    }
}
