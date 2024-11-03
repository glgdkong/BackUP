using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * ť(�ڷᱸ��)
// - ���Լ���(FIFO) ����� �ݷ������� �������� ��Ҹ� �߰��ϰ� ���� ���� �߰��� ��Һ��� �����ϴ� ����� �ڷᱸ���̴�.

public class QueueAPITest : MonoBehaviour
{
    // ���ڿ� ť ����
    private Queue<string> strQueue = new Queue<string>();

    void Start()
    {
        // ť�� ���ڿ� ������ �߰� (����)
        strQueue.Enqueue("��ǳ��");
        strQueue.Enqueue("�ٳ���");
        strQueue.Enqueue("�̻���");
        strQueue.Enqueue("������");
        strQueue.Enqueue("���ּ�");

        // ť���� ������ Ž��  (�ð����⵵ O(n) => ��Ұ� ���������� ������ ������)
        Debug.Log($"ť�ȿ��� �̻����� �ִ°�? {strQueue.Contains("�̻���")}");
        Debug.Log($"ť�ȿ��� ��Ʈ������ �ִ°�? {strQueue.Contains("��Ʈ����")}");

        // ť�� �߰��� ������ ���� Ȯ��
        Debug.Log($"ť�� �߰��� ������ ���� : {strQueue.Count}");

        // ť���� ���ڿ� ������ ���� (����)
        string itemName = strQueue.Dequeue();
        Debug.Log($"ť���� ������ ������ �̸� : {itemName}");

        // * Dequeue()�� Peek�� ����
        // - Dequeue�� ����� ť���� �����͸� ������
        // - Peek�� ����� ť���� �����͸� �������� ���� (Ȯ�ο�)
        if (strQueue.Count > 0 )
        Debug.Log($"ť�� ������ ������ Ȯ�� : {strQueue.Peek()}");

        itemName = strQueue.Dequeue();
        Debug.Log($"ť���� ������ ������ �̸� : {itemName}");


        // ť�� ����� ��ü ��� ��ȸ
        // * foreach (���Ͽ��Ÿ�� ���� in ����÷��ǶǴ� �迭) {... �ݺ��ڵ����� ...}
        // - �ݺ��� �����ϸ鼭 ����÷��ǶǴ¹迭�� ��Ҹ� �ϳ��� �����鼭 ���������� ������ �� �ִ� ������ �ݺ���
        foreach (string name in strQueue)
        {
            Debug.Log($"ť���� ����� ������ ��� �̸� : {name}");
        }

        // ��ü ��� ��ȸ�� ���� ť�� �迭�� ��ȯ
        string[] strArray = strQueue.ToArray();
        for (int i = 0; i < strArray.Length; i++) 
        {
            Debug.Log($"ť(�迭)���� ����� ������ ��� �̸� : {strArray[i]}");
        }

        Debug.Log("ť ���� ����");
        // ť �ȿ� ��� �����͸� ������
        strQueue.Clear();
        Debug.Log($"ť�� �߰��� ������ ���� : {strQueue.Count}");
    }
}
