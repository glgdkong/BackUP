using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ������Ʈ
public class Item : MonoBehaviour
{
    [SerializeField] private GameObject showItme; // ŉ���� ������ ���ӿ�����Ʈ

    [SerializeField] private float showTime; // �������� ǥ�õ� �����ð�

    void Start()
    {
        // ������ ���� ǥ�ÿ� ó�� �ڷ�ƾ ����
        StartCoroutine(ShowDelayCoroutine());
    }

    // ������ ���� ǥ�ÿ� ó�� �ڷ�ƾ
    IEnumerator ShowDelayCoroutine()
    {
        // ���� ��ü ����
        yield return new WaitForSeconds(showTime);
        // ������ Ȱ��ȭ
        showItme.SetActive(true);
    }
}
