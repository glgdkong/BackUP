using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // 아이템 흭득 이펙트
    //[SerializeField] private GameObject pickUpEffectPrefab;
    // 인벤토리 시스템
    private InventorySystem inventorySystem;


    // Start is called before the first frame update
    void Start()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void OnTriggerEnter(Collider colliter)
    {
        // 아이템 흭득 충돌 처리
        if (colliter.CompareTag("Item"))
        {
            Debug.Log($"{colliter.GetComponent<ItemChest>().ItemInfo.ItemId} 아이디를 흭득함");

            //Debug.Log("아이템을 흭득함");

            // 인벤토리 시스템에 아이템을 추가함
            bool invenAdded = inventorySystem.AddItem(colliter.GetComponent<ItemChest>().ItemInfo);

            // 아이템 추가가 성공했다면
            if (invenAdded)
            {
                // 아이템 흭득 이펙트를 생성
                //Instantiate(pickUpEffectPrefab,colliter.transform.position, Quaternion.identity);

                // 아이템 상자 파괴
                Destroy(colliter.gameObject);
            }
        }
    }
}
