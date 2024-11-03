using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : CharacterHeath
{
    // FSM ��Ʈ�ѷ�
    private MonsterFSMController controller;

    // ĳ���� �������� UI ������
    private CharacterOverayUIManager characterUIManager;

    // �ǰ� ����
    private bool isHit = false;

    public bool IsHit { get => isHit; set => isHit = value; }
    private void Awake()
    {
        controller = GetComponent<MonsterFSMController>();
    }

    protected override void Start()
    {
        base.Start();
        characterUIManager = GetComponentInChildren<CharacterOverayUIManager>();
    }

    // �ǰ� ó��
    public void Hit(int damage, float knockbackForce)
    {
        // ü�� ���� ó��
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);

        // ĳ������ ü���� 0���� �۰ų� ������ (����ϸ�)
        if (currentHp <= 0)
        {
            // ü�¹� ����
            characterUIManager.HideHpUI();

            // ��� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.DEATH, knockbackForce);
        }
        else 
        {
            // �ǰ� ���·� ��ȯ
            controller.TransactionToState(MonsterFSMController.STATE.HIT, knockbackForce);
        }
    }

    private void Update()
    {
        UpdateHpBar();
    }

    private void UpdateHpBar()
    {
        float fillAmount = (float)currentHp / maxHp;
        // ü�¹� UI ǥ�� ������Ʈ
        characterUIManager.UpdateHpUIProgress(fillAmount);

    }
}
