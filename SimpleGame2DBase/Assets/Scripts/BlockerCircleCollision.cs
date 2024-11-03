using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerCircleCollision : MonoBehaviour
{
    // ���� Ÿ��(RED, BLUE)
    [SerializeField] private ColorType colorType; // ���� Ÿ�� ��ü ��������
    public ColorType ColorType { get => colorType; set => colorType = value; }


    // ���ŷ �ִϸ��̼� ��� ��Ʈ�ѷ�
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("BounceCircle"))
        {
            animator.SetTrigger("Blocking");
        }
    }

}
