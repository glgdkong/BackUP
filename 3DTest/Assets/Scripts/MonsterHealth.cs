using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour, IHitAble
{
    // �ִ� ü��
    [SerializeField] protected int maxHp;

    // ���� ü��
    [SerializeField] protected int currentHp;

    // FSM ��Ʈ�ѷ�
    private MonsterFSMController controller;

    // �ǰ� ����
    private bool isHit = false;

    public bool IsHit { get => isHit; set => isHit = value; }

    private bool isDeath = false;
    public bool IsDeath { get => isDeath; set => isDeath = value; }

    private void Awake()
    {
        controller = GetComponent<MonsterFSMController>();
    }

    void Start()
    {
        currentHp = maxHp;
    }

    // �ǰ� ó��
    public void Hit(int damage, float knockbackForce)
    {
        // ü�� ���� ó��
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);

        // ĳ������ ü���� 0���� �۰ų� ������
        if (currentHp <= 0)
        {
            IsDeath = true;
            // ��� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.DEATH, knockbackForce);
        }
        else
        {
            // �ǰ� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.HIT, knockbackForce);
        }
    }
}
