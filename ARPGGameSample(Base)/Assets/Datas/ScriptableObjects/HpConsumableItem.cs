using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ü�� ���� �Ҹ� ������
[CreateAssetMenu(fileName = "HpConsumableItem", menuName = "Item/HpConsumableItem")] // ��ũ���ͺ� ������Ʈ ���� �޴� ����
public class HpConsumableItem : ConsumableItem
{
    // �������� �����
    public override void Consume()
    {
        base.Consume();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerHeath>().HpUp(upValue);        
    }
}
