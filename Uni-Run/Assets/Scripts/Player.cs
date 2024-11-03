using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ���� �ۼ����� �𸦶�?
    // � ����� ���� ������ �����غ���.

    // ����
    private Rigidbody2D playerRigidbody;
    // ����
    private AudioSource audioSource;
    // �ִϸ��̼�
    private Animator animator;

    // ���� ����
    public float jumpForce = 700f;
    private int jumpCount = 2;
    private bool isGround = false;
    private int maxJumpCount;

    // ���� ����
    public AudioClip dieClip; // ���� ���� Ŭ��
    private bool isDie = false;
    // �̵� �ӵ�
    public float movementSpeed;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  
        animator = GetComponent<Animator>();
        maxJumpCount = jumpCount;

    }

    // ��� �Լ��� ��ȯ(����)�� �Ǿ�� ������.
    void Update()
    {
        // ������ ���ָ� �ش� �Լ��� ����ǹǷ� ���̻� �Ʒ� �ۼ��� �ڵ尡 ������� �ʴ´�.
        if (isDie) return; // ���� Ÿ���� ���� void �Լ� ���� ��� ��return �����Ǿ� �ִ� ���̴�.
        Jump();
    }
    private void Jump()
    {
        // SetBool ("�Ķ����", bool��)
        animator.SetBool("IsGround", isGround);
        // ���� ����
        // 0~ 1 �� �� ���� ����
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            // ����Ű ���� ������ 1 �� ����
            jumpCount--;
            // ������ٵ� ���� ���� (Y������ ����������ŭ)
            //playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x ,0); // ���� ���ϱ� ���� �ӷ��� 0���� �ʱ�ȭ �Ѵ�.
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // ���� ���� ���
            // Play() ���� �Ҵ�� Ŭ���� ���
            audioSource.Play();
        }
        // Ű �Է��� ���´� ũ�� 3������ ����
        // ������ ��, ������ ��, �� ��
        // Ű�� �� ��,  �÷��̾��� �ӷ��� y���� 0���� ũ�ٸ�
        // �÷��̾ ��� ���� ��
        else if(Input.GetKeyUp(KeyCode.Space) && playerRigidbody.velocity.y > 0)
        {
            // playerRigidbody.velocity += playerRigidbody.velocity * 0.5f
            // ����Ϸ��� �ӷ��� ������ �Ǳ� ������ �� ���� �������� �����ϰ� �ȴ�.
            playerRigidbody.velocity *= 0.5f;
        }

    }

    // ����Ƽ�� �����ϴ� �浹 �Լ��� �Ű������� �浹 ������ ����ش�.

    // �����浹�� ���۵Ǿ��� �� ȣ��Ǵ� ����Ƽ �̺�Ʈ �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷����� ��ܿ� �浹 ���� ���� �����ϵ��� �����ؾ� �Ѵ�.
        // contacts �浹 ������ ����, [0]��° �̱� ������ ���� ù ���� => �浹 ���ڸ����� �븻�� �˻�
        if (collision.contacts[0].normal.y > 0.7)
        {
            jumpCount = maxJumpCount;
            isGround = true;
        }
    }
    // ���� �浹�� ������ ��
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
    // �� �浹�� ���� �Ǿ��� �� ȣ�� �Ǵ� ����Ƽ �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� �浹�� ���� �±װ� Dead���
        if (collision.CompareTag("Dead"))
        {
            Die();
        }
    }
    private void Die()
    {
        // ���� �ִϸ��̼� ���
        animator.SetTrigger("ToDie");

        // ���� Ŭ������ ��ü
        audioSource.clip = dieClip;
        // ���� ���� ���
        audioSource.Play();

        // ���� ó��
        isDie = true;

        // FindObjectOfType<������Ÿ��>(); ������Ÿ��(������Ʈ)�� ������ �ִ� ���ӿ�����Ʈ�� ã���ش�.
        GameManager gameManeger = FindObjectOfType<GameManager>();
        gameManeger.Gameover();
    }
}
