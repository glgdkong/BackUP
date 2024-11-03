using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItmeList", menuName = "Item/ItemList")]
public class ItemList : ScriptableObject
{
    [SerializeField] protected List<Item> list; // 아이템 리스트(목록)

    public List<Item> List { get => list; set => list = value; }
}