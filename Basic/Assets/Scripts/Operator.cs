using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������

public class Operator : MonoBehaviour
{
    int a;
    int b = 1;


    // Start is called before the first frame update
    void Start()
    {
        // ���� ������ = : ������ ���� ���ʿ� �Ҵ���.
        a = 1;

        // a�� a + b�� ���� �Ҵ���.
        a = a + b;

        // a = a + b; �� ������ ������, ���� �Ʒ�ó�� ���ڷ� ǥ����
        a += b;

        // ���� ������ 1�� ���� �Ǵ�, 1�� ����
        a++;

        a--;

        // ������ �������� Ư¡�� true or false�� ���� �츮���� �ش�.
        // ���ǹ����� ����� �ȴ�.
        // (a == b) a�� b�� ������? true
        // (a != b) a�� b�� �ٸ���? false

        // �� ������
        // && And ������ : ����A && ���� B ==> ���� A�� B ��ΰ� ���̿��� true�� ��ȯ, ���� �ϳ��� �����̸� false�� ��ȯ
        // || Or ������ : ���� A || ���� B ==> ���� A�� B �� �� �ϳ��� ���̸� true, ��� �����̸� false
        // ! Not ������ : �� ���� ������ ==> ���� �����´�, true => false, false => true, ~�� �ƴ�


    }
}
