using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerCircleCollision : MonoBehaviour
{
    // 색상 타입(RED, BLUE)
    [SerializeField] private ColorType colorType; // 색상 타입 객체 참조변수
    public ColorType ColorType { get => colorType; set => colorType = value; }


    // 블로킹 애니메이션 재생 컨트롤러
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
