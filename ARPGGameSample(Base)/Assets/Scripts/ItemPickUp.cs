using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // ������ ŉ�� ����Ʈ
    //[SerializeField] private GameObject pickUpEffectPrefab;
    // �κ��丮 �ý���
    private InventorySystem inventorySystem;


    // Start is called before the first frame update
    void Start()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void OnTriggerEnter(Collider colliter)
    {
        // ������ ŉ�� �浹 ó��
        if (colliter.CompareTag("Item"))
        {
            Debug.Log($"{colliter.GetComponent<ItemChest>().ItemInfo.ItemId} ���̵� ŉ����");

            //Debug.Log("�������� ŉ����");

            // �κ��丮 �ý��ۿ� �������� �߰���
            bool invenAdded = inventorySystem.AddItem(colliter.GetComponent<ItemChest>().ItemInfo);

            // ������ �߰��� �����ߴٸ�
            if (invenAdded)
            {
                // ������ ŉ�� ����Ʈ�� ����
                //Instantiate(pickUpEffectPrefab,colliter.transform.position, Quaternion.identity);

                // ������ ���� �ı�
                Destroy(colliter.gameObject);
            }
        }
    }
}
