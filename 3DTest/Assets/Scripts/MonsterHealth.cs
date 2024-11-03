using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour, IHitAble
{
    // 최대 체력
    [SerializeField] protected int maxHp;

    // 현재 체력
    [SerializeField] protected int currentHp;

    // FSM 컨트롤러
    private MonsterFSMController controller;

    // 피격 여부
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

    // 피격 처리
    public void Hit(int damage, float knockbackForce)
    {
        // 체력 감소 처리
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);

        // 캐릭터의 체력이 0보다 작거나 같으면
        if (currentHp <= 0)
        {
            IsDeath = true;
            // 사망 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.DEATH, knockbackForce);
        }
        else
        {
            // 피격 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.HIT, knockbackForce);
        }
    }
}
