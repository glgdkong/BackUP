using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfGrammar : MonoBehaviour
{
    // ���ǹ� if : ��ȣ���� ������ ���϶� �߰�ȣ ���� �ڵ带 ����.
    // if (����) { �츮�� ������ �ڵ�;}
    // ������ Ŀ�ٶ� �� ���.(����ġ ���̽������� ����ϱ� ��ٷο� ��� ��쿡 if���� ����غ��� �Ѵ�.)
    [SerializeField]
    private int inputNumber;
    [SerializeField]
    private int age;

    void Start()
    {
        // if��
        if (4 % 2 == 0)
        {
            Debug.Log("4�� 2�� ������ �������� 0�Դϴ�.");
        }

        // if ~ else : ��ȣ ���� ������ ���̸� if���� �߰�ȣ�� ����, ��ȣ ���� ������ �����̸� else���� �߰�ȣ�� ����
        // else���� if���� ���� ������ �������� ����� �����ϴ�.
        if (inputNumber % 2 == 0)
        {
            Debug.Log("¦��");
        }
        else // �߰�ȣ ���� ������ �ƴ� �� ���� ��Ȳ
        {
            Debug.Log("Ȧ��");
        }

        // inputNumber = 15;
        if (inputNumber % 3 == 0)
        {
            Debug.Log("3�� ���"); // 3�� ����� �����ϹǷ� �ڵ� ����
        }
        if (inputNumber % 4 == 0)
        {
            Debug.Log("4�� ���");
        }
        if (inputNumber % 5 == 0)
        {
            Debug.Log("5�� ���"); // 5�� ����� �����ϹǷ� �ڵ� ����
        }
        else
        {
            Debug.Log("3, 4, 5�� ����� �ƴ�");
        }

        // if ~ else if �� : �������� ���ǿ� �����Ѵٸ� �ڵ带 ������.
        // inputNumber = 15;
        if (inputNumber % 3 == 0)
        {
            Debug.Log("3�� ���"); // 3�� ����� �����ϹǷ� �ڵ� �����ϰ� if else if ���� ������.
        }
        else if (inputNumber % 4 == 0)
        {
            Debug.Log("4�� ���");
        }
        else if (inputNumber % 5 == 0)
        {
            Debug.Log("5�� ���"); // �������� ���ǿ� �����Ͽ����Ƿ� �ڵ带 �������� ����.
        }
        else
        {
            Debug.Log("3, 4, 5�� ����� �ƴ�");
        }


        // �������� �ڵ带 ����� ������.
        // 10��� �л�, 20 ~ 50��� ����, �� �� �ƴϸ� ���� �Ǵ� ����
        if (age >= 10 && age < 20)
        {
            Debug.Log("�л��Դϴ�.");
        }
        else if (age >= 20 && age < 60)
        {
            Debug.Log("�����Դϴ�.");
        }
        else
        {
            Debug.Log("���� �Ǵ� �����Դϴ�.");
        }
    }
}
