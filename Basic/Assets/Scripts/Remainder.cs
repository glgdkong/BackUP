using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remainder : MonoBehaviour
{
    private int a;
    private int b;

    public int inputNumber;

    // Start is called before the first frame update
    void Start()
    {
        a = 10;
        b = 2;

        // % ������ ������ : a�� B�� ������ �� [������ ��]
        // �� ū ���� �������� �ϸ� ���� �� ���� ������ ������ ���� �������� ���´�.
        int c = a % b;

        // � ��x�� 5�� ������ ������ �� ���� �� �ִ� ����� ��
        // 0 ~ 4 (0���� �������� �ϴ� �� -1 ������ ����)

        // � ���� 10���� ������ ������ �� ���� �� �ִ� ����� ��
        // 0 ~ 9

        // � ���� 1������ ������ ������ �� ���� �� �ִ� ����� ��
        // 0 ~ 99,999,999

        // if () ��ȣ ���� ���� ���̸� �ڵ带 �����ϰ�, �����̸� �������� �ʽ��ϴ�.
        if (inputNumber % 2 == 0)
        {
            Debug.Log("2�� ���, ¦��");
        }
    }

}
