using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public int a;
    public int b;
    private void Start()
    {
        // a, b�� ���� ���� �ٲ㺸����
        Debug.Log($"a : {a}");
        Debug.Log($"b : {b}");
        int c = a;
        a = b;
        b = c;
        // swap ������ ���α׷����ϸ鼭 �����ε� ��� ���´�..
        // �����ִ� ���Ǹ����� �����ذ��� �� �� ���� �� ���ο� ������ ����غ���.

        Debug.Log($"a : {a}");
        Debug.Log($"b : {b}");
    }
    // 1. ���� ��� ������� �̿��ؼ� 
    // ���� ���� class�� ����� ������.
    // ���� ����� ���� class�� �ǹ̰� �־�� �մϴ�.
    // �������� ������ �¾ƾ� �մϴ�.
    // ������ �˾Ƽ� �����Ӱ�
    
    // 2. Swap Ǯ�������
    // ��ɲ� �˻� ����.
}
