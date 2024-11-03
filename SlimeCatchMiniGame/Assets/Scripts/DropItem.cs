using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ������ ������ ������Ʈ
public class DropItem : MonoBehaviour
{
    // ��� ������ 
    [SerializeField] private GameObject itemPrefab;

    // ������ ��� �޼ҵ�
    public void Drop()
    {
        // Ȯ�� �̱�( 0 ~ 100 �ۼ�Ʈ)
        float randomPercent = Random.Range(0f, 100f);
        // 50���� Ȯ����
        if(randomPercent > 50f )
            // �������� ����
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
    }
}
