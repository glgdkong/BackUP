using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileGrammar : MonoBehaviour
{
    public float attackRange = 2f;
    private float distance;

    // while �� ��ȣ ���� ������ ���� ������ �ݺ� ����
    // �ݺ� Ƚ���� ��Ȯ������ ������ ������ ��Ȯ�� �˰� ���� �� ���
    void Start()
    {
        /*int i = 0;
        while (i <= 100)
        {
            Debug.Log(i);
            i++;
        }*/

        // attackRange : ���� ����(��Ÿ�)
        // distance : ���� �� ������ �Ÿ�
        while (distance <= attackRange)
        {
            Debug.Log("����!");
        }
    }
}
