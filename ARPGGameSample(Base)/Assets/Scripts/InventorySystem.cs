using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Linq ���

public class InventorySystem : MonoBehaviour
{
    // ������ ����Ʈ(��ũ���ͺ� ������Ʈ) <------ ���� ������ ����(���� ������ ������)
    [SerializeField] private ItemList[] itemLists;
    // �κ��丮 ũ��(���� ����)
    [SerializeField] private int inventorySize;

    // ŉ���� ������ ����Ʈ <----- ������ ������ ������ ���
    [SerializeField] private List<Item> hasItemList = new List<Item>();
    public List<Item> HasItemList { get => hasItemList; set => hasItemList = value; }

    // �κ��丮 UI
    [SerializeField] private InventoryUI inventoryUI;

    void Start()
    {
        /*//Debug.Log($"���� ������ ��� ���� : {itemLists[(int)EnumTypes.ITEM_TYPE.WP].List.Count}");
        
        //foreach (Item item in itemLists[(int)EnumTypes.ITEM_TYPE.WP].List)
        //{
        //    Debug.Log($"{item.ItemName}");
        //}

        //Debug.Log($"�Ҹ� ������ ��� ���� : {itemLists[(int)EnumTypes.ITEM_TYPE.CB].List.Count}");
        
        //foreach (Item item in itemLists[(int)EnumTypes.ITEM_TYPE.CB].List) 
        //{
        //    Debug.Log($"{item.ItemName}");
        //}
        
        //Debug.Log($"������ �κ��丮 ������ ��� ���� : {hasItemList.Count}");*/

        // �κ��丮 UI �ʱ�ȭ
        inventoryUI.InitInventoryUI();
    }

    public bool AddItem(ItemInfo itemInfo)
    {
        // ŉ���� �������� ���� �������̶��
        if (itemInfo.ItemType == EnumTypes.ITEM_TYPE.WP)
        {
            // ���� �κ��丮�� ���� á�ٸ�
            if (HasItemList.Count >= inventorySize)
            {
                Debug.Log("�κ��丮�� ���� á��");

                // �κ��丮 ������ �߰� ����
                return false;
            }
            // ŉ���� �������� ������ ã��
            Item item = itemLists[(int)EnumTypes.ITEM_TYPE.WP].List.FirstOrDefault(item => item.ItemId == itemInfo.ItemId).Clone();
            if (item != null)
            {
                Debug.Log($"{item.ItemName} ���� �������� ŉ����");

                // ŉ�� �����ۿ� ������ �߰�
                HasItemList.Add(item);
            }
        }
        // ŉ���� �������� �Ҹ� �������̶��
        else if (itemInfo.ItemType == EnumTypes.ITEM_TYPE.CB)
        {
            // Ȯ���� �������� �����ϴ����� Ž����
            ConsumableItem hasItem = (ConsumableItem)HasItemList.FirstOrDefault(item => item.ItemId == itemInfo.ItemId);

            // �̹� �ش� �������� ŉ���� ���¸�
            if (hasItem != null)
            {
                Debug.Log($"[{hasItem.ItemName} �Ҹ� �������� �߰� ŉ����]");

                // �ش� �������� ŉ�� ī��Ʈ�� ������
                hasItem.ItemCount++;
            }
            else
            {
                // ���� �κ��丮�� ���� á�ٸ�
                if (HasItemList.Count >= inventorySize) 
                {
                    Debug.Log("�κ��丮�� ���� á��");

                    // �κ��丮 ������ �߰� ����
                    return false;
                }

                // ŉ���� �������� ������ ã��
                Item item = itemLists[(int)EnumTypes.ITEM_TYPE.CB].List.FirstOrDefault(item => item.ItemId == itemInfo.ItemId).Clone();
                if (item != null)
                {
                    Debug.Log($"{item.ItemName} �Ҹ� �������� ŉ����");

                    // ŉ�� �������� �߰���
                    HasItemList.Add(item);
                }
            }
        }
        // �߰��� �����ۿ� ���� �κ��丮 UI ����
        inventoryUI.UpdateInventoryUI();

        return true;
    }

    // �κ��丮 ������ ����
    public void RemoveItem(Item item)
    {
        // ������ �������� �����ϰ� ������
        if(HasItemList.Contains(item))
        {
            // ���� �������� ������
            HasItemList.Remove(item);
        }
        // ���ŵ� �����ۿ� ���� �κ��丮 UI ����
        inventoryUI.UpdateInventoryUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.OpenUI();
        }
    }
}
