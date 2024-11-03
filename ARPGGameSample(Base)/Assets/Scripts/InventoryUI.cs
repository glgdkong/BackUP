using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// �κ��丮 UI ����
public class InventoryUI : MonoBehaviour
{
    // ������ ���� �迭
    [SerializeField] private RectTransform[] itemUISlots;
    // ������ ǥ�� UI �迭
    [SerializeField] private ItemUI[] itemUIs;
    // ������ ǥ�� UI ������
    [SerializeField] private GameObject itemUIPrefab;
    // �κ��丮 �ý��� 
    [SerializeField] private InventorySystem inventorySystem;

    // ������ ���� ǥ�� UI 
    [SerializeField] private ItemInfoUI itemInfoUI;

    // ���� ������ ����
    [SerializeField] private Text hasItemCountText;

    // �κ��丮 UI �ʱ�ȭ
    public void InitInventoryUI()
    {
        // ������ ǥ�� UI���� ������
        itemUIs = new ItemUI[itemUISlots.Length];

        for (int i = 0; i < itemUISlots.Length; i++)
        {
            itemUIs[i] = Instantiate(itemUIPrefab, itemUISlots[i]).GetComponent<ItemUI>();
            itemUIs[i].Init(this); // ������ ���� �̺�Ʈ ���� ���� ����
        }

    }

    void Update()
    {
        // ������ ���� ���
        hasItemCountText.text = $"[{inventorySystem.HasItemList.Count.ToString()}]";
    }

    // ������ ������
    public void RemoveItem(Item item) 
    {
        // ������ ǥ�� UI�� ����
        inventorySystem.RemoveItem(item);
    }

    // ��� ������ ���� ���¸� ������
    public void ItemAllDeSelect()
    {
        // ������ ǥ�� UI�� ���� ǥ�� ���¸� ������
        for (int i = 0;i < itemUISlots.Length;i++)
        {
            itemUIs[i].ItemDeSelect();
        }
        // ������ ���� �г��� ����
        itemInfoUI.HideItemInfo();
    }

    // �κ��丮 ������ ����
    public void ItemSelect(Item item) 
    { 
        // ��� ������ ���� ���¸� ������
        ItemAllDeSelect();

        // ������ ������ ������ ǥ����
        itemInfoUI.ShowItemInfo(this, item);
    }

    // �κ��丮 UI ������Ʈ
    public void UpdateInventoryUI()
    {
        // �κ��丮 ������ UI ��Ҹ� �ʱ�ȭ��
        for (int i = 0; i < itemUISlots.Length; i++)
        {
            itemUIs[i].ClearItemUI();
        }

        // ŉ���� ������ ������ ������ UI�� ǥ����
        for (int i = 0; i < inventorySystem.HasItemList.Count; i++) 
        {
            Item item = inventorySystem.HasItemList[i];
            itemUIs[i].Show(item);
        }

        // ���� ������ ���� ǥ�� �г��� ��Ȱ��ȭ��
        itemInfoUI.HideItemInfo();
        // ������ ���� ���¸� ��Ȱ��ȭ�c
        ItemAllDeSelect();
    }

    private void OnEnable()
    {
        // ��� �̺�Ʈ ��������Ʈ �޼ҵ� ���
        GameManager.onCancelDelegate += OnCancel;
    }

    private void OnDisable()
    {
        // ��� �̺�Ʈ ��������Ʈ �޼ҵ� ��� ����
        GameManager.onCancelDelegate -= OnCancel;
    }

    // ��� �̺�Ʈ �޼ҵ�
    public void OnCancel()
    {
        // ������ �ݱ� ó��
        CloseUI();
    }

    // �κ��丮 UI ����
    public void OpenUI()
    {
        // transform.parent : ���� ���ӿ�����Ʈ�� �θ� ���ӿ�����Ʈ�� Transform ����
        // transform.root   : ���� ���ӿ�����Ʈ�� �ֻ��� ���ӿ�����Ʈ�� Transform ����
        transform.parent.gameObject.SetActive(true);
    }
    // �κ��丮 UI �ݱ� ó��
    public void CloseUI()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void UseItem(Item item)
    {

        // ����� �������� ���� �������̸�
        if(item.ItemType == EnumTypes.ITEM_TYPE.WP)
        {
            // ������ ���� ��� ����
            return;
        }
        else // ����� �������� �Ҹ� �������̸�
        {
            // �Ҹ� �������� ������ 2�� �̻��̸�
            if(item.ItemCount > 1)
            {
                Debug.Log($"{item.ItemName} �Ҹ� ������ �ϳ��� �����");
                // �ش� �������� ���� ������ ������
                item.ItemCount--;

                // �Ҹ� ������ ����� ������
                ((ConsumableItem)item).Consume(); 

                UpdateInventoryUI();
                return;
            }
        }

        Debug.Log($"{item.ItemName} ������ �Ҹ� ������ �ϳ��� �����");
        ((ConsumableItem)item).Consume();
        // ���� �Ǵ� ������ �������� ������
        inventorySystem.RemoveItem(item);
    }


}
