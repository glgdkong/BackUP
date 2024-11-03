using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Լ�(�޼ҵ�) : ��� ��� ó���� ���� ����� ���� �ڵ�
// ����ũ�μ���Ʈ, ����Ƽ�� �̸� ����� ���� �Լ���� 
// ����� �ʿ信 ���� ���� ���� ����� ���� �Լ��� �ִ�.
// �ڵ��� �������� ������ �����ϵ��� �Ѵ�.
// �Լ��� ȣ���ؾ� ����� �ȴ�.

// �Լ��� ����
// 1.���������� 2.����Ÿ�� 3.�Լ���(4.�Ű�����) {}
// �Լ� �� ����Ģ : ù ���ڰ� �빮�� ���� ī��ǥ���
public class Function : MonoBehaviour
{
    public float a;
    public float b;
    public float c;
    public int d;

    public string h;
    public string w;

    private int gold;

    private int arrowCount = 100;


    // ����Ƽ �̺�Ʈ �Լ�, �Ķ���, Unity�޽���
    // ����Ƽ �̺�Ʈ �Լ��� ����ڰ� ȣ������ �ʾƵ� ����Ƽ�� ���� �ڵ� ȣ��ȴ�.
    void Start()
    {
        /*// �Լ��� ���
        // �Լ���();
        // �ٸ� �Լ� ������ ȣ���Ͽ� ����� �� �ִ�.
        PrintInfo();
        // �Ű������� �����ϴ� �Լ��� �Ű������� �־���� ȣ��ȴ�.
        Sum(a, b, c);

        //Debug.Log(gold);
        //gold = GetNumber(); // 100�̶�� ���� ����ֽ��ϴ�.
        //Debug.Log(gold);

        // �ڵ��� ���� ����
        // ���ʿ��� ����������, ������ ���ؽ�Ʈ �������� ������ �Ʒ��� ����

        // = ���Ǽ��迡�� '����'��� �ǹ�
        // ������ ���α׷��ֿ����� �ǹ̰� ���� �ٸ���.
        // = ���� ������ : �������� ���� ���ʿ� ����(�Ҵ�)
        Debug.Log(IsDie());

        // ù ��° ��� ����� �α׿� �״�� �Լ� ȣ��
        Debug.Log(HelloWorld(h, w));
        // �� ��° ��� �ӽ� ���� �����ؼ� ����� �α� ȣ��
        //string temp = HelloWorld(h, w);
        //Debug.Log(temp);
        d = 10;
        a = Random.Range(9f, 11f);
        Debug.Log(Equal(d, a));

        // ����Ƽ ������ Ÿ���� �������� �̹� ����Ƽ�� ���� ���Ҵ�.
        // GameObject : ������ Ÿ��
        // gameObject : ���� ������Ʈ ������
        // gameObject�� ��ũ��Ʈ(������Ʈ)�� �Ҵ�� ���ӿ�����Ʈ�� �ǹ��Ѵ�.
        Debug.Log(GetName(gameObject));

        // Transform�� �������� -> transform
*/
        SetRandomPosition(gameObject);

    }



    void Update()
    {
        /*// ���� ȸ�� ������ 0 ���϶�� �Լ� ����
        if (arrowCount <= 0) 
        { 
            return; 
        }

        ArrowShoot();*/
    }

    // �ܺο� �������� �ʰ� ����Ÿ���� ���� �Լ����� �˾Ƽ� ��������. �Ű������� ���� �Լ� �����ϱ�.
    private void PrintInfo()
    {
        //PrintInfo();   // ���ȣ��(���� �Լ������� ������ �Լ� ȣ��)
        Debug.Log($"�÷��̾��� ����");
    }

    // �Ű������� �����ϴ� �Լ�
    // �Ű����� ���� ��� �Լ���(������Ÿ�� ������)
    // �Լ� ������ �غ񹰷� ������ ������Ÿ�� �ϳ��� �ʿ�� �ϴ� ����.
    // �Ʒ��� �Լ��� �����غ�����.
    // �ܺο� �����ϰ� ���� Ÿ���� ���� �Ǽ��� �Ű����� 3���� �ʿ���ϴ� �Լ��̰�
    // ����� ����� �α׷� �Ű����� 3���� ��� ���� ���� ����ϴ� ���.
    public void Sum(float a, float b, float c)
    {
        Debug.Log($"{a} + {b} + {c} = {a + b + c}");
    }

    // ���� Ÿ���� �����ϴ� �Լ�
    // �Լ� ������ �� ���� Ÿ���� �ڸ��� �������� ������ Ÿ���� ����� �Ѵ�.
    // return Ű���带 ����Ͽ� ���� ��ȯ�ؾ� �Լ��� ����ȴ�.
    // return ��; �� ���·� ���
    public int GetNumber()
    {
        return 100;
    }

    // �ܺο� �������� �ʰ� ���� �����͸� ��ȯ�ϰ� �Ű������� ���� �Լ��� ����(�Լ��� �˾Ƽ�)
    private bool IsDie()
    {
        return false;
    }

    // ���� Ÿ�Ե� �����ϰ�, �Ű������� �����ϴ� �Լ�
    // �ܺο� �����ϰ� ���ڿ� �����͸� ��ȯ�ϰ� �Ű������� ���ڿ� �� ������ �ʿ�� �ϴ� �Լ�(�Լ��� �˾Ƽ�)
    // ����� �� �Ű������� ���� ���ڿ����� ���� ���� ��ȯ�Ѵ�.
    public string HelloWorld(string hello, string world)
    {
        return hello + world;
    }

    // �Լ��� ����
    // �Լ��� �����Ϸ��� return�� ����� �մϴ�.
    // ����Ÿ���� ���� void�Լ��� ���
    // return�� ������ �Ǿ��ִ�.
    // returnŰ���带 ����Ͽ� ���ϴ� ������ �Լ��� �����ų �� �ִ�.

    private void ArrowShoot()
    {
        // ȭ�� ��� ���
        //Ȱ �� ������ ȭ�� ���� �ϳ��� �پ� ��
        arrowCount--;
        Debug.Log($"ȭ�� �߻� ���� ȭ��({arrowCount})");
    }    

    // �ܺο� �������� �ʰ� ���� �����͸� ��ȯ�ϰ� �Ű������� ������ �ϳ��� �Ǽ��� �ϳ��� �ʿ�� �ϴ� �Լ� �ۼ�
    
    private bool Equal(int a, float b)
    {
        return a == (int)b; 
    }

    // �⺻ ������ Ÿ���� �ƴ�, ����Ƽ ������ Ÿ���� ����� �Լ�
    // �ܺο� �����ϰ� ���� Ÿ���� ���ڿ��̰� �Ű������� GameObjectŸ�� �ϳ��� �ʿ�� �ϴ� �Լ�
    // ����� �Ű������� ���� ���ӿ�����Ʈ�� �̸��� ��ȯ
    public string GetName(GameObject gameObject)
    { 
        return gameObject.name;
    }

    // �ܺο� �����ϰ� ���� Ÿ���� ���� �Ű������� GameObjectŸ�� �ϳ��� �ʿ���ϴ� �Լ�
    // ����� ���ӿ�����Ʈ ���� �ȿ� Ʈ������ ���� �ȿ� position�� �������� �ٲٴ� ���.
    public void SetRandomPosition(GameObject setPosition)
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        setPosition.transform.position = new Vector3 (x, y, z);
    }

}
