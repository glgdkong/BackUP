using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Test : MonoBehaviour
{
    // 1. Class�� �������� �ƴ´�� ���ϰ� ����

    // Class�� ����� ���� ������ Ÿ���̴�. ����ڰ� class ���� ������ ������ �޼ҵ带 �����Ͽ� ����ϱ� ���� �����ϴ� ��

    // 2. MonoBehaviour�� ��� ���� Class�� ��ӹ��� ���� Class�� ������

    // MonoBehaviour�� ��� ���� ���� Class�� ����Ƽ�� �̺�Ʈ �޼ҵ带 ����� �� ������ ���� ������Ʈ�� ������Ʈ�� �߰� �� �� ���� ����Ƽ API�� ������ �� ����.
    // ���� class�� �޼ҵ忡 Unity ��ũ��Ʈ �޽����� �������

    // 3. ������ �������� ����

    // ������ ���� �����ϴ� ������ �ǹ��ϸ� ����, ��𼭵� ���� ������ �� �ִ�.

    // 4. �ܺο� �����ϰ� ���ڿ� �� �����͸� �ٷ�� ���� myName�� ����

    public string myName;

    // 5. 4������ ������ ������ Start() �Լ����� ������ ������ �ʱ�ȭ.

    private void Start()
    {
        myName = "������";
        PrintNum711();
        AddListNum();
    }

    // 6. F1Ű�� ������ �� 1000���� 1���� ����ϴ� �ڵ� �ۼ�
    
    private void PrintNum()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            for (int i = 1000; i >= 1; i--)
            {
                Debug.Log((i));
            }
        }
    }

    // 7. 1���� 10000������ �� �� 7�Ǵ� 11�� ������� ��.
    private void PrintNum711()
    {
        int numResult = 0;
        for (int i = 1; i <= 10000; i++)
        {
            if (i % 7 == 0 || i % 11 == 0)
            {
                numResult += i; // ����� 11046042
            }
        }
        Debug.Log(numResult);
    }
    // 8. �ܺο� �������� �ʰ� ���� Ÿ���� Vector3�̸� �Ǽ� �� �Ű����� 3���� �ʿ�� �ϴ� �Լ� �ۼ�,
    //    �Ű������� ���� 3���� �Ǽ� ���� Vector3�� ���Ŀ� �°� �����Ͽ� ����

    private Vector3 ToVector(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }

    // 9. �Ǽ��� �����͸� �ٷ�� �迭�� ����� ���ÿ� 1.24f, 321.51f, 1238.5f�� �ʱ�ȭ

    private float[] floatNum = { 1.24f, 321.51f, 1238.5f };

    // 10. ������ �ٷ�� ����Ʈ A�� B�� ����

    List<int> listNumA = new List<int>();

    List<int> listNumB = new List<int>();

    // 11. ����Ʈ A�� 1���� 100���� �߰�

    public void AddListNum()
    {
        for (int i = 0; i < 100; i++)
        {
            listNumA.Add(i+1);
            Debug.Log($"����ƮA �� �� �߰� : {listNumA[i]}");
            
        }
    }

    // 12. ������ ������ ������ 0���� 99���� �������� �ۼ� ��, ���� ���� ���� �ε����� Ȱ���Ͽ�
    //     ����ƮA���� �ش� �ε����� ���Ҹ� �����ϰ� ����Ʈ B�� �߰��ϱ�.
    public void RandomRemoveAndAddB()
    {
        int randomNum = Random.Range(0, listNumA.Count);
        Debug.Log($"���� �ε��� ��ȣ {randomNum}");
        listNumB.Add(listNumA[randomNum]);
        Debug.Log($"����ƮB�� ����߰� �� : {listNumA[randomNum]}");
        Debug.Log($"����ƮA {randomNum} �ε������� {listNumA[randomNum]}�� ����");
        listNumA.RemoveAt(randomNum);
    }

    // 13. 12�� ������ F2Ű�� ���� �� ���� ���� �ǵ��� �����ϱ�

    private void RandomRemoveAndAddBRepeat()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
            RandomRemoveAndAddB();
        }
    }

    // 14. ����Ʈ A ���ҵ��� ������ ������Ű��

    public void ReverseListA()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            listNumA.Reverse();
            Debug.Log("����Ʈ A ����");
        }
    }

    // 15. ����ƮA�� ���Ҹ� �������� �����ϱ�

    public void SortListA()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {    
            listNumA.Sort();
            Debug.Log("����Ʈ A �������� ����");
        }
    }

    private void Update()
    {
        PrintNum();
        RandomRemoveAndAddBRepeat();
        PrintListNumA();
        PrintListNumB();
        ReverseListA();
        SortListA();
    }

    private void PrintListNumA()
    {
        int i = 0;
        if (Input.GetKeyDown(KeyCode.F3))
        {
            foreach (var item in listNumA)
            {
                Debug.Log($"[{i++}]��° ����ƮA �� : {item}");
            }
        }
    }

    private void PrintListNumB()
    {
        int i = 0;
        if (Input.GetKeyDown(KeyCode.F4))
        {
            foreach (var item in listNumB)
            {
                Debug.Log($"[{i++}]��° ����ƮB �� : {item}");
            }
        }
    }
}
