using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    // 애니메이터 컴포넌트
    protected Animator animator;
    // 플레이어 체력관리 컴포넌트
    protected PlayerHealthController playerHp;

    /*// 가드 상태 
    private bool isGuarding;
    public bool IsGuarding { get => isGuarding; set => isGuarding = value; }

    // 회피 상태
    private bool isDodgeing;
    public bool IsDodgeing { get => isDodgeing; set => isDodgeing = value; }*/

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        playerHp = GetComponent<PlayerHealthController>();
    }
}
