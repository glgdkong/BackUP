using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")] // ��ũ���ͺ� ������Ʈ ���� �޴� ����
public class ConsumableItem : Item
{
    // �Ҹ� ������ Ÿ��
    [SerializeField] protected EnumTypes.CB_TYPE cbType;

    // ������ ��ġ
    [SerializeField] protected int upValue;

    public EnumTypes.CB_TYPE CbType { get => cbType; set => cbType = value; }
    public int UpValue { get => upValue; set => upValue = value; }

    public virtual void Consume() // ������ �Ҹ� ó�� �޼ҵ�
    {
        Debug.Log("�Ҹ� ������ ����� ������");
    }
}
