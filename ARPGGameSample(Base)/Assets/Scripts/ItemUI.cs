using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ������ ����� ǥ�� ������Ʈ
public class ItemUI : MonoBehaviour
{
    // ������ ��� �̹���
    [SerializeField] private Image itemBackgroundImage;
    // ������ �̹���
    [SerializeField] private Image itemImage;
    // ������ ŉ�� ����
    [SerializeField] private Text itemCountText;
    // ������ ī��Ʈ ǥ�� ��׶���
    [SerializeField] private GameObject itemCountBackground;
    // ������ ���� ǥ�� ��׶���
    [SerializeField] private GameObject itemEquipBackground;
    // �κ��丮 UI
    private InventoryUI inventoryUI;

    // ������ ����
    private Item item = null;
    // ������ ���� ����
    [SerializeField] private bool isSelected = false;
    [SerializeField] private Color32 selectColor;
    [SerializeField] private Color32 deSelectColor;

    // �κ��丮 ���� �ʱ�ȭ
    public void Init(InventoryUI inventoryUI)
    {
        this.inventoryUI = inventoryUI;
    }

    // ������ ǥ�� UI����
    public void Show(Item item)
    {
        // ������ ����
        this.item = item;

        // ������ ������ ����
        itemImage.sprite = this.item.ItemIconImage;

        // �Ҹ� �������� ��� ������ ���� ǥ��
        if (this.item.ItemCount > 0)
        {
            itemCountBackground.SetActive(true);
            itemCountText.text = this.item.ItemCount.ToString();
        }
        // ��� ����/ �������� ó��
    }

    // ������ ���� �ʱ�ȭ
    public void ClearItemUI()
    {

        // ������ ����� ������ �ʱ�ȭ ��
        item = null;    // ������ ������ �ʱ�ȭ
        itemBackgroundImage.color = deSelectColor; // ������ ��׶��� ���� �ʱ�ȭ
        itemImage.sprite = null; // ������ ��������Ʈ �̹��� �ʱ�ȭ
        itemCountBackground.SetActive(false); // ������ ���� ��׶��� ��Ȱ��ȭ
        itemCountText.text = "0"; // ������ ī��Ʈ �ؽ�Ʈ �ʱ�ȭ
    }

    // ������ ���� ó�� 
    public void ItemSelect()
    {
        // �������� �������� �ʾҴٸ� �о�
        if (item == null)
        {
            // ���� ���� �������� ���� ���¸� ������
            inventoryUI?.ItemAllDeSelect();
            return;
        }

        // ������ ������ ������ �κ��丮 �Ʒ��ʿ� �����
        inventoryUI.ItemSelect(item);

        // ������ �ȵ� ���¸�
        if (!isSelected)
        {
            // ������ ���õ� ���·� ������ ǥ����
            itemBackgroundImage.color = selectColor;
            Debug.Log("������ ������ ó����");
            isSelected = true;
        }
    }

    // ������ ���� ����
    public void ItemDeSelect()
    {
        // �̹� ���õ� ��Ȳ�̸�
        if (isSelected)
        {
            // �������� ���� ������ ���·� ������ ǥ����
            itemBackgroundImage.color = deSelectColor;
            Debug.Log("������ ������ ������");
            isSelected = false;
        }
    }
}
