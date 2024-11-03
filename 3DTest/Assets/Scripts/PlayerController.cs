using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    // �ִϸ����� ������Ʈ
    protected Animator animator;
    // �÷��̾� ü�°��� ������Ʈ
    protected PlayerHealthController playerHp;

    /*// ���� ���� 
    private bool isGuarding;
    public bool IsGuarding { get => isGuarding; set => isGuarding = value; }

    // ȸ�� ����
    private bool isDodgeing;
    public bool IsDodgeing { get => isDodgeing; set => isDodgeing = value; }*/

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        playerHp = GetComponent<PlayerHealthController>();
    }
}
