using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class MonsterFSMController : MonoBehaviour
{
    // ���� ���µ�
    public enum STATE {IDLE, WANDER, DETECT, ATTACK, GIVEUP, HIT, DEATH }

    // * ������ ���� ���� ����
    [SerializeField] private MonsterState currentState;

    // ������ ��� ���µ�
    [SerializeField] private MonsterState[] monsterStates;

    // �÷��̾� ����
    private GameObject player;
    public GameObject Player { get => player; set => player = value; }

    // * ���� ��ȯ �޼ҵ�
    public void TransactionToState(STATE state, object data = null)
    {
        //Debug.Log("");

        // ���� ���Ͱ� �̹� ��� ���¸� ���� ��ȯ�� ���� ����
        if (currentState == monsterStates[(int)STATE.DEATH]) return;

        currentState?.ExitState(); // ���� ���� ó��
        currentState = monsterStates[(int)state]; // ���� ��ȯ ó��
        currentState?.EnterState(state, data); // ���ο� ���� ����

    }

    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        // ��� ���·� ����
        TransactionToState(STATE.IDLE);
    }

    void Update()
    {
        // * ���� ������ ������ ����� ����!
        currentState?.UpdateState();
    }

    // �÷��̾�� ���Ͱ��� �Ÿ� ����
    public float GetPlayerDistance()
    {
        return Vector3.Distance(transform.position, Player.transform.position);
    }

}
