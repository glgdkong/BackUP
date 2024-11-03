using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : CharacterHeath
{
    // FSM 컨트롤러
    private MonsterFSMController controller;

    // 캐릭터 오버레이 UI 관리자
    private CharacterOverayUIManager characterUIManager;

    // 피격 여부
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

    // 피격 처리
    public void Hit(int damage, float knockbackForce)
    {
        // 체력 감소 처리
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);

        // 캐릭터의 체력이 0보다 작거나 같으면 (사망하면)
        if (currentHp <= 0)
        {
            // 체력바 숨김
            characterUIManager.HideHpUI();

            // 사망 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.DEATH, knockbackForce);
        }
        else 
        {
            // 피격 상태로 전환
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
        // 체력바 UI 표시 업데이트
        characterUIManager.UpdateHpUIProgress(fillAmount);

    }
}
