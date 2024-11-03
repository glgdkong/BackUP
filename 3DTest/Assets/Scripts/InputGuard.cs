using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGuard : PlayerController
{
    // ���� ���� 
    private bool isGuarding;
    public bool IsGuarding { get => isGuarding; set => isGuarding = value; }
    private void Update()
    {
        InputGuarding();
    }
    private void InputGuarding()
    {
        bool g = Input.GetButton("Guard");
        IsGuarding = g;
        animator.SetBool("Guard", g);

    }
}
