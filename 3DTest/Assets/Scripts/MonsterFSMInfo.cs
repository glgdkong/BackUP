using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFSMInfo : MonoBehaviour
{
    [Header("���� ���� �Ӽ�")]
    [SerializeField] private float attackDistance; // ���� ���� �Ÿ�
    [SerializeField] private float attackSpeed; // ���� �ӵ�
    [SerializeField] private float lookAtMaxSpeed;
    [SerializeField] private bool isAttackable; // ���� ���ɿ���

    [Header("���� ���� �Ӽ�")]
    [SerializeField] private float detectDistance; // ���� ���� �Ÿ�
    [SerializeField] private float detectMoveSpeed; // ���� �� �̵� �ӵ�

    [Header("�ι� ���� �Ӽ�")]
    [SerializeField] private float nextPointSelectDistance; // ���� �̵� ���� ���� �Ÿ�
    [SerializeField] private Transform[] wanderPoints;

    [Header("��ȸ ���� �Ӽ�")]
    [SerializeField] private float wanderMoveSpeed; // ��ȸ �� �̵��ӵ�
    [SerializeField] private float wanderNavCheckRadius; // ��ȸ �̵� �׺���̼� üũ ����

    [Header("�� ���� �Ӽ�")]
    [SerializeField] private float giveUpMoveSpeed; // �� �̵� �ӵ�

    // �Ӽ� ������Ƽ��
    public Transform[] WanderPoints { get => wanderPoints; set => wanderPoints = value; }
    public float AttackDistance { get => attackDistance; set => attackDistance = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float DetectDistance { get => detectDistance; set => detectDistance = value; }
    public float DetectMoveSpeed { get => detectMoveSpeed; set => detectMoveSpeed = value; }
    public float WanderMoveSpeed { get => wanderMoveSpeed; set => wanderMoveSpeed = value; }
    public float WanderNavCheckRadius { get => wanderNavCheckRadius; set => wanderNavCheckRadius = value; }
    public float GiveUpMoveSpeed { get => giveUpMoveSpeed; set => giveUpMoveSpeed = value; }
    public float NextPointSelectDistance { get => nextPointSelectDistance; set => nextPointSelectDistance = value; }
    public float LookAtMaxSpeed { get => lookAtMaxSpeed; set => lookAtMaxSpeed = value; }
    public bool IsAttackable { get => isAttackable; set => isAttackable = value; }
}
