using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ������ ���� ǥ�� �� ������Ʈ
public class ContentCell : MonoBehaviour
{
    // Ÿ�� ǥ�� �ؽ�Ʈ
    [SerializeField] private Text typeText;
    // ������ ���� ǥ�� �ؽ�Ʈ
    [SerializeField] private Text itemNameText;
    // ������ ���� ǥ�� �ؽ�Ʈ
    [SerializeField] private Text itmePriceText;

    // ������ �� ǥ�� ���� �ʱ�ȭ
    public void Init(ItemData itemData)
    {
        typeText.text = itemData.Type;
        itemNameText.text = itemData.ItemName;

        // ���ڸ� ���� ���� ó��
        long number = long.Parse(itemData.ItemPrice);
        // N0 ���ڸ����� , �� �־��ش�
        itmePriceText.text = number.ToString("N0") + "��";
    }

    // ������ �� ����
    public void OnDeleteButtonClick()
    {
        Destroy(gameObject);
    }
}
