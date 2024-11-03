using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ������
// Ŭ���� ���ο� �ִ� �޼ҵ��� �̸� ���� �޶�����
// using UityEngine�� ��Ȱ��ȭ �ȴ�
// class�� �޼ҵ� ���� ���� ����Ƽ �޽���, ��ũ��Ʈ ǥ�ð� �������

// �⺻ Ŭ������ ����
public class NormalClass 
{
    // �������̺� ��� ���� �ʾұ� ������ 
    // ����� ���� �Լ��� �ȴ�.
    void Start()
    {

    }
    void Update()
    {
        
    }
    // Ŭ������ ������ �Լ��� �߻�ȭ �Ѵ�.

    // ���� : ���α׷��ֿ��� ���� �����ϴ� ������ �ǹ�, ���� ��𼭵� ���� �ٲ� �� �ִ�.
    // ��ǻ�ʹ� �⺻������ �ƹ��͵� �𸣴� ���� �Դϴ�.
    // ���� ������ �ϱ� ���ؼ��� ������ ����� ǥ���� ����� �մϴ�.
    string name;
    int age;
    float height;
    string leftHand;




    // ������ ����
    // 1. ���������� 2. ������Ÿ�� 3. ������;

    // 1. ���������� (public, private, etc....)
    // public : �ܺο� �����ϴ�. Ŭ���� �ܺο����� ��� ����
    // private : �ܺο� �������� �ʴ´�. Ŭ���� ���ο����� ��� ����.
    // ���������ڸ� �����ϸ� �⺻������ private�����̴�.

    // 2. ������Ÿ��(Data Type) 
    // �⺻ ������ Ÿ��(����ũ�μ���Ʈ) : ����(int), �Ǽ�(float), ���ڿ�(string), ������(bool), esc...
    // ����Ƽ ������ Ÿ�� : �츮�� ������Ʈ�� ����ߴ� �͵�, GameObject, Transform, Rigidbody etc...
    // ����� ���� ������ Ÿ�� : �츮�� ���� class�� �ǹ� NormalClass, Orc, Monster, etc...

    // 3. ������(���� �̸�)
    // ������ ������Ģ(�̸��� ���� ��Ģ)
    // ������ ����� �ϴ� ���� �ƴ����� �����ð� ���α׷����� �ؿ� �����ڵ鳢���� �Ϲ����� ��.
    // �������� ù ���ڴ� �ҹ��ڷ� �ۼ��Ѵ�.
    // ���⸦ ���� �ʴ´�.
    // �� �ܾ� �̻��� �ռ����� ��� �ܾ��� �ǹ̰� �ٲ� �� ù ���ڸ� �빮�ڷ� ���´�.
    // ex) moveSpeed, attackPower, jumpForce, monsterName, ...
    // Camel ǥ��� (��Ÿ �� ó�� ����ٰ� �ؼ� �ٿ��� �̸�)

    /*// �� ������ Ÿ�� ����ؼ� ���� ���� �غ�����
    public int hp;
    public int level;
    public float moveSpeed;
    private float positionX;
    private float positionY;

    public string playerName;
    public string partyName;

    public bool isAlive;*/

    // �ʱ�ȭ : reset�� �ǹ̰� �ƴϰ�, ������ ���ʷ� ���� �Ҵ��ϴ� ���� �ǹ��Ѵ�.
    // ������ ����� ���ÿ� �ʱ�ȭ
    // ���������� ������Ÿ�� ������ =(���Կ�����) ��;
    public string intrduceMySelf = "�ȳ��ϼ��� ***�Դϴ�.";
    private float todayTemperature = 31.4f;
    public int day = 25;
    public int month = 08;
    private bool isDie = false;
    private bool isGameover = false;

    // ���ڿ� �� ������Ÿ���� ������ ���� �Ҵ��� ������ ""(�ֵ���ǥ)�ȿ� �ۼ��Ѵ�.
    // �Ǽ��� ������Ÿ���� ������ ���� �Ҵ��� ���� ���� �ڿ� f�� �ٿ��ش�.
    // ���� �� ������Ÿ���� �������� �̴�, �ƴϴٸ� �����ϱ� ���� ���� isXXX ��� ���´�.

    // ����(���) ���� : Ŭ���� ���� ��� �������� ����� �����ϴ�.
    // class {} Ŭ������ �߰�ȣ ����(���ؽ�Ʈ)

    // ����(����) ���� : ����� ���ؽ�Ʈ ���� �ȿ����� ����� �����ϴ�. ���� �Լ� ������ ������ ������ ����������� �Ѵ�.

    // ������ ���
    // ����� ������ ����� �� [������ =(������) ��]�� ���·� ����� �� �ִ�.

    // �Լ�(�޼ҵ�) : ��� ��� ó���� ���� ����� ���� �ڵ�
    // ����ũ�μ���Ʈ, ����Ƽ�� �̸� ����� ���� �Լ���� 
    // ����� �ʿ信 ���� ���� ���� ����� ���� �Լ��� �ִ�.
    // �ڵ��� �������� ������ �����ϵ��� �Ѵ�.
    // �Լ��� ȣ���ؾ� ����� �ȴ�.

    // �Լ��� ����
    // 1.���������� 2.����Ÿ�� 3.�Լ���(4.�Ű�����) {}

    // void : �����ϴ�. (���α׷��ֿ����� �ƹ��͵� ����. = �����ϴ� ���� ����.)
    // () : ��ȣ �ȿ� �ƹ��͵� ������ �Ű������� ���� �Լ��̴�.
    // �Ű����� : �Լ��� �����ϴµ� �ʿ��� �غ�
    public void Sum()
    {
        isGameover = false; // ���� ���� ���
        int a = 0;
        int b = 1;
        int c = a + b;
    }

    public void Minus()
    {
        isGameover = true;
        //a = 0; ���������� Ư¡, a������ Sum()�Լ� ������ �ۼ��� ���������̹Ƿ� �ٸ� ������ ��� �Ұ���
        //int b = 2; // ����� ���������� ��ȿ�ϱ� ������ ������ �̸��� ���� ������ ���� �� ������ �� �ִ�.
        //int c;
        //int d = b + c;
        // ���� ������ ��� �� �� ���� �Ҵ��� ��� �Ѵ�.
        
        // ������� �ǵ��� ���̳ʽ� �Լ����� day������ �������� day�� ���� 25�� �Ҵ��ϰ� ����.
        // int day = day;
        // ���� ���� �����ϱ� ������ ���� �߻�
        int day = this.day;
        // this. => �� �ڽ��� class�� �ǹ�
        // ���� ������ ���� ������ �̸��� �ǵ����̸� �����ϰ�, �� �ȵǸ� this Ű���� ���.
    }
}