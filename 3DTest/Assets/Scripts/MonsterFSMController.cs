using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFSMController : MonoBehaviour
{
    // ���� ���µ�
    public enum STATE {IDLE, WANDER, DETECT, ATTACK, GIVEUP, HIT, DEATH }

    // ������ ���� ���� ����
    [SerializeField] private MonsterState currentState;

    // ������ ��� ���µ�
    [SerializeField] private MonsterState[] MonsterStates;

    // �÷��̾� ����
    private GameObject player;
    public GameObject Player { get => player; set => player = value; }

    // ���� ��ȯ �޼ҵ�
    public void TransactionToState(STATE state, object data = null)
    {
        // ���� ���Ͱ� �̹� ��� ���¸� ���� ��ȯ�� ���� ����
        if (currentState == MonsterStates[(int)STATE.DEATH]) return;

        currentState?.ExitState(); // ���� ���� ó��
        currentState = MonsterStates[(int)state]; // ���� ��ȯ ó��
        currentState.EnterState(state, data); // ���ο� ���� ����
    }

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");

        // ��� ���·� ����
        TransactionToState(STATE.IDLE);
    }

    private void Update()
    {
        // ���� ������ ������ ����� ����!
        currentState?.UpdateState();
    }

    // �÷��̾�� ���Ͱ��� �Ÿ� ����
    public float GetPlayerDistance()
    {
        return Vector3.Distance(transform.position, Player.transform.position);
    }

}
