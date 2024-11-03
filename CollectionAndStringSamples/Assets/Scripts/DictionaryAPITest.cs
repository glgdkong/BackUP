using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * ��ųʸ�(�ؽ����̺�) �ڷᱸ��
// - Ű-�� ������ �����͸� �����ϴ� �ڷᱸ���� Ű���� ���� ���� �˻� �� �߰� ���� � �����ϴ�.
// - ���� Ű�����δ� �������� ������ �� ����.
// - Ű���� �̿��� Ž���� �ð����⵵�� O(1)�� �ſ� ���� �˻��� Ž�� ����� �����Ѵ�.

// ��ųʸ��� ����
// - Dictionary<T> : �Ϲ����� ��ųʸ� ��ü���� ����, ����, ��ȸ�� ���Ǵ� ��ųʸ�
//   -> �˻� : ��� �ð����⵵ O(1)
//   -> ���� : ��� �ð����⵵ O(1)
//   -> ���� : ��� �ð����⵵ O(1)

// - SortedDictionary<T> : ����Ž��Ʈ�� ����� Ű������ ����� ��ųʸ�
//   -> �˻� : ��� �ð����⵵ O(log n)
//   -> ���� : ��� �ð����⵵ O(log n)
//   -> ���� : ��� �ð����⵵ O(log n)
// * ���� : ���ĵ� Ű �������� ����� �����ϰ� ���� ��

// �ð� ���⵵ ���� ���� : O(1) > O(log n) > O(n)

// * ����Ʈ�� : �� ��尡 �ִ� �ΰ��� �ڽ� ��鸣 ������ �ڷ� ������ �� ���� ���� �ڽİ� ������ �ڽ����� �б�ȴ�.
// - ���� Ʈ�� ��Ģ
//      -> ���� �ڽ� ��忡�� �θ��� ���� ���� ���� ����
//      -> ������ �ڽ� ��忡�� �θ��� ���� ū ���� ����
// - ���� Ž�� Ʈ�� : BST(Binary Serach Tree)
// * ���� SortedDictionary�� Ž�� �˰����� ����Ž��Ʈ���� �˰����� ������ ����-�� Ʈ�� �˰����� �����


public class DictionaryAPITest : MonoBehaviour
{
    //Dictionary<string, int> strItemMap = new Dictionary<string, int>();
    SortedDictionary<string, int> strItemMap = new SortedDictionary<string, int>();


    void Start()
    {
        // ������ ������ ��ųʸ��� �߰���("������ �̸�", ��������)
        strItemMap.Add("�ٳ���", 10);
        strItemMap.Add("��ǳ��", 5);
        strItemMap.Add("�̻���", 3);
        strItemMap.Add("������", 30);
        strItemMap.Add("���ּ�", 3);

        // �������� ���� ���
        Debug.Log($"��ųʸ� ������ ���� : {strItemMap.Count}");

        // ������ ������ ���������� ����� (�ε��� ���� �ƴ� - �����)
        foreach (KeyValuePair<string, int> item in strItemMap)
        {
            //Debug.Log($"strItemMap[\"{item.Key}\"] = {item.Value}");
            Debug.Log($"strItemMap[\"{item.Key}\"] = {strItemMap[item.Key]}");
        }
        
        int itemCount;
        // ���� ��ųʸ��� �̻���Ű�� ���� ��Ұ� �ִٸ� �ش� ��Ұ��� itemCount ������ �����ؼ� �޾ƿ�(out)
        if (strItemMap.TryGetValue("�̻���", out itemCount))
        {
            Debug.Log($"�̻��� ������ ���� : {itemCount}");
        }

        // try {... ���ܱ��� ...} catch (���ܺ���) {... ����ó�� ...}
        try
        {
            Debug.Log(strItemMap["�ƹ�Ű"]); //Ű�� ���� ��Ҹ� �����ϸ� ���� �߻�
        }
        catch (KeyNotFoundException ex)
        {
            Debug.Log($"������ ���� ���� �߻� : {ex.Message}");
        }

        // ���� ��ųʸ��� ������Ű�� ���� ��Ұ� �ִٸ� 
        if (strItemMap.ContainsKey("������"))
        {
            Debug.Log($"������ ������ ���� : {strItemMap["������"]}");
        }

        // �ٳ��� Ű�� ���� �������� ������
        if (strItemMap.Remove("�ٳ���"))
        {
            Debug.Log("�ٳ��� �������� ������");
        }

        Debug.Log($"��ųʸ� ������ ���� : {strItemMap.Count}");

        foreach (KeyValuePair<string, int> item in strItemMap)
        {
            //Debug.Log($"strItemMap[\"{item.Key}\"] = {item.Value}");
            Debug.Log($"strItemMap[\"{item.Key}\"] = {strItemMap[item.Key]}");
        }

        Debug.Log("��ųʸ��� ��� ������ ����===============");
        // ��ųʸ��� ��� ������ ����
        strItemMap.Clear();

        Debug.Log($"��ųʸ� ������ ���� : {strItemMap.Count}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
