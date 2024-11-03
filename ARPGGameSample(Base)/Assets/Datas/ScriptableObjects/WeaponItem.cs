using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon")] // 스크립터블 오브젝트 생성 메뉴 정의
public class WeaponItem : Item
{
    // 장비 종류
    [SerializeField] protected EnumTypes.WP_TYPE wpType;
    // 공격 속도
    [SerializeField] protected float attackSpeed;
    // 공격 데미지
    [SerializeField] protected int damage;
    // 장비 장착 부모 태그
    [SerializeField] protected string equipParentTag; // 추가 속성 (현재 사용하지 않음)
    // 장비 프리팹
    [SerializeField] protected GameObject wpPrefab;

    public EnumTypes.WP_TYPE WpType { get => wpType; set => wpType = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public int Damage { get => damage; set => damage = value; }
    public string EquipParentTag { get => equipParentTag; set => equipParentTag = value; }
    public GameObject WpPrefab { get => wpPrefab; set => wpPrefab = value; }
}
