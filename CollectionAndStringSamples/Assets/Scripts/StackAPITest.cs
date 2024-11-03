using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * ����(�ڷᱸ��)
// - ���Լ���(LIFO) ����� �ݷ������� �������� ��Ҹ� �߰��ϰ� ���� �ֱٿ� �߰��� ��Һ��� �����ϴ� ����� �ڷᱸ���̴�.

public class StackAPITest : MonoBehaviour
{
    // ���ڿ� ���� ����
    private Stack<string> strStack = new Stack<string>();

    void Start()
    {
        // ���ÿ� ���ڿ� ������ �߰� (����)
        strStack.Push("��ǳ��");
        strStack.Push("�ٳ���");
        strStack.Push("�̻���");
        strStack.Push("������");
        strStack.Push("���ּ�");

        // ���ÿ��� ������ Ž��  (�ð����⵵ O(n) => ��Ұ� ���������� ������ ������)
        Debug.Log($"���þȿ��� �̻����� �ִ°�? {strStack.Contains("�̻���")}");
        Debug.Log($"���þȿ��� ��Ʈ������ �ִ°�? {strStack.Contains("��Ʈ����")}");

        // ���ÿ� �߰��� ������ ���� Ȯ��
        Debug.Log($"���ÿ� �߰��� ������ ���� : {strStack.Count}");

        // ���ÿ��� ���ڿ� ������ ���� (����)
        string itemName = strStack.Pop();
        Debug.Log($"���ÿ��� ������ ������ �̸� : {itemName}");

        // - Peek�� ����� ���ÿ��� �����͸� �������� ���� (Ȯ�ο�)
        if (strStack.Count > 0 )
        Debug.Log($"���ÿ��� ������ ������ Ȯ�� : {strStack.Peek()}");

        itemName = strStack.Pop();
        Debug.Log($"���ÿ��� ������ ������ �̸� : {itemName}");


        // ���ÿ� ����� ��ü ��� ��ȸ
        foreach (string name in strStack)
        {
            Debug.Log($"���ÿ� ����� ������ ��� �̸� : {name}");
        }

        // ��ü ��� ��ȸ�� ���� ������ �迭�� ��ȯ
        string[] strArray = strStack.ToArray();
        for (int i = 0; i < strArray.Length; i++) 
        {
            Debug.Log($"����(�迭)�� ����� ������ ��� �̸� : {strArray[i]}");
        }

        Debug.Log("���� ���� ����");
        // ���þȿ� ��� �����͸� ������
        strStack.Clear();
        Debug.Log($"���ÿ� �߰��� ������ ���� : {strStack.Count}");
    }
}
