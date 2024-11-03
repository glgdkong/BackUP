using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���õ� ������ ���� ǥ�� �� ��� ó�� ������Ʈ
public class ItemInfoUI : MonoBehaviour
{
    // ������ �̸� ��� �ؽ�Ʈ
    [SerializeField] private Text itemNameText;
    // ������ ���� ��� �ؽ�Ʈ
    [SerializeField] private Text itemDescriptionText;
    // ������ ��ư �ؽ�Ʈ
    [SerializeField] private Text itemButtonText;

    private InventoryUI inventoryUI;
    private Item item;

    // ������ ���� ����ϱ�
    public void ShowItemInfo(InventoryUI inventoryUI, Item item)
    {
        // ���� ������ ����
        this.inventoryUI = inventoryUI;
        this.item = item;   

        if(this.item.ItemType == EnumTypes.ITEM_TYPE.WP)
        {
            if(this.item.IsEquip)
            {
                itemButtonText.text = "�����ϱ�";
            }
            else
            {
                itemButtonText.text = "�����ϱ�";
            }
        }
        else
        {
            itemButtonText.text = "����ϱ�";
        }
        // ������ �����г� Ȱ��ȭ �� ���������� ���
        gameObject.SetActive(true);
        itemNameText.text = $"{item.ItemName} [{(item.ItemCount > 0 ? item.ItemCount : "1")}]";
        itemDescriptionText.text = $"{item.ItemDescription}";
    }

    public void HideItemInfo()
    {
        gameObject.SetActive(false);
    }

    // ������ ������ ��ư Ŭ��
    public void OnRemoveItemButtonClick()
    {
        // Debug.Log($"{item.ItemName} ������ ������ ��ư Ŭ��");
        inventoryUI.RemoveItem(item);
    }

    // ������ ����ϱ� ��ư Ŭ��
    public void OnUseItemButtonClick()
    {
        // Debug.Log($"{item.ItemName} ������ ����ϱ� ��ư Ŭ��");

        // �̹� ������ �������� ���
        if(item.IsEquip)
        {
            Debug.Log("�������� ���� ������");
        }
        else // �Ҹ� �������̰ų� �������� ���� �������� ���
        {
            Debug.Log("�������� ���� �Ǵ� �����");
            inventoryUI.UseItem(item);
        }
    }


}
