using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItmeList", menuName = "Item/ItemList")]
public class ItemList : ScriptableObject
{
    [SerializeField] protected List<Item> list; // ������ ����Ʈ(���)

    public List<Item> List { get => list; set => list = value; }
}