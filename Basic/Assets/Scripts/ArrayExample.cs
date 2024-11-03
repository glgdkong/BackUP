using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

// Collection : ������ ������Ÿ���� ���� �� �ٷ� �� �ϳ��� ������ ���� �ϴ� ��.
// �÷��� : �����̳ʶ�� �մϴ�.
public class ArrayExample : MonoBehaviour
{
    int a = 0;
    int b = 1;
    int c = 2;

    // �迭 Array
    // �迭�� ���� : ���������� ������Ÿ��[] ������ = new ������Ÿ��[�迭�� ũ��];
    // �迭�� ���α׷��� ���ۺ��� ������� ��ġ�ʴ� ũ�⸦ �ٷ� �� ����մϴ�.
    // �� �迭�� ũ�⸦ ���α׷��� ���� �߿� ������ �� �����ϴ�.

    // ���� 100���� ��� �迭�� ����
    public int[] numbers = new int[100];
    // �迭�� ����� ���ÿ� ���� �Ҵ�
    public string[] names = { "��ö��", "���¾�", "����ȯ", "���ÿ�", "������" };
    void Start()
    {
        // �迭�� ���ҿ� ���� ���
        // ������[index]
        // �迭�� ���ҿ� ���� �Ҵ� 
        // index�� Ư¡ : ���α׷��ֿ��� ù ��°�� 0�̴�. => ����� ȿ����, ������ �帧 �� ���� 0���� ������
        numbers[0] = 1;  // ù ����
        numbers[99] = 1; // 100 ����

        // ��� ������ �ݺ��ؼ� �ϰ� �ִٸ�, �ݺ����� ����غ��� ���� ����ؾ� �Ѵ�.
        // �迭.Length : �迭�� ũ��
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
            Debug.Log("numbers ["+ i +"] : " + numbers[i]);
        }
    }
}
