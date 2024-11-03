using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon")] // ��ũ���ͺ� ������Ʈ ���� �޴� ����
public class WeaponItem : Item
{
    // ��� ����
    [SerializeField] protected EnumTypes.WP_TYPE wpType;
    // ���� �ӵ�
    [SerializeField] protected float attackSpeed;
    // ���� ������
    [SerializeField] protected int damage;
    // ��� ���� �θ� �±�
    [SerializeField] protected string equipParentTag; // �߰� �Ӽ� (���� ������� ����)
    // ��� ������
    [SerializeField] protected GameObject wpPrefab;

    public EnumTypes.WP_TYPE WpType { get => wpType; set => wpType = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public int Damage { get => damage; set => damage = value; }
    public string EquipParentTag { get => equipParentTag; set => equipParentTag = value; }
    public GameObject WpPrefab { get => wpPrefab; set => wpPrefab = value; }
}
