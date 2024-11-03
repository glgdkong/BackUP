using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForGrammar : MonoBehaviour
{
    // for�� (�ݺ���)
    // for(�ʱ� �ε����� ; ���ǹ� ; ������) {}
    // ������ ���̶�� {} �߰�ȣ �ڵ念���� �����ϰ� �ε����� 1������Ų��.
    // �ݺ� Ƚ���� ���������� �� ���.
    void Start()
    {
        int sum = 0;
        // 1 ~ 100 ���� ���
        /*for (int i = 1; i <= 100; i++)
        {
            Debug.Log(i);
        }*/

        // 100���� 1���� ����� 
        /*for (int i = 100; i >= 1; i--)
        {
            Debug.Log(i);
        }*/


        // 1���� 100 ���� ������ ���� ���ϼ���
        /*
        for (int i = 1; i <= 100; i++)
        {
            sum += i;
        }
        Debug.Log(sum);*/

        // 1 ���� 100���� ���� �� 3�� ������� ��
        /*for (int i = 1; i <= 100; i++)
        {
            if(i % 3 == 0)
            {
                sum += i;
            }
        }
        Debug.Log(sum);
        
        sum = 0;
        for (int i = 0; i <= 100; i += 3)
        {
            sum += i;
        }
        Debug.Log(sum);*/

        // 1 ���� 100 ���� ���� �� 3�� 5�� ������� ��
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }
        Debug.Log(sum);
    }
}
