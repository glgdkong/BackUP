using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFSMController : MonoBehaviour
{
    // 몬스터 상태들
    public enum STATE {IDLE, WANDER, DETECT, ATTACK, GIVEUP, HIT, DEATH }

    // 몬스터의 현재 동작 상태
    [SerializeField] private MonsterState currentState;

    // 몬스터의 모든 상태들
    [SerializeField] private MonsterState[] MonsterStates;

    // 플레이어 참조
    private GameObject player;
    public GameObject Player { get => player; set => player = value; }

    // 상태 전환 메소드
    public void TransactionToState(STATE state, object data = null)
    {
        // 현재 몬스터가 이미 사망 상태면 상태 전환을 하지 않음
        if (currentState == MonsterStates[(int)STATE.DEATH]) return;

        currentState?.ExitState(); // 이전 상태 처리
        currentState = MonsterStates[(int)state]; // 상태 전환 처리
        currentState.EnterState(state, data); // 새로운 상태 전이
    }

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");

        // 대기 상태로 시작
        TransactionToState(STATE.IDLE);
    }

    private void Update()
    {
        // 현재 설정된 상태의 기능을 동작!
        currentState?.UpdateState();
    }

    // 플레이어와 몬스터간의 거리 측정
    public float GetPlayerDistance()
    {
        return Vector3.Distance(transform.position, Player.transform.position);
    }

}
