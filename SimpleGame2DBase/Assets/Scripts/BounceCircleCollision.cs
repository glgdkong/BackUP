using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCircleCollision : MonoBehaviour
{
    [SerializeField] private ColorType colorType;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Color[] circleColors;

    [SerializeField] private VerticalBounceMovement movement;

    [SerializeField] private GameObject[] destoryColorFxPrefabs;

    [SerializeField] private Animator animator;

    [SerializeField] private AudioClip successSound;
    [SerializeField] private AudioClip failureSound;

    private GameManager gameManager; // ���� ������

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // �ٿ ��Ŭ ���� ���� ���� �޼ҵ�
    public void RandomCircleColor()
    {
        // ���� ���� �ε���(0,1)
        int colorIndex = Random.Range(0, circleColors.Length);

        // �ٿ ��Ŭ�� ������ ����
        spriteRenderer.color = circleColors[colorIndex];

        // ���� �ε����� Į�� Ÿ��(Enum) Ÿ������ ĳ���� �ؼ� ���� ������ ������
        colorType.type = (ColorType.TYPE)colorIndex;
    }
    // �ٿ ��Ŭ�� �浹 �̺�Ʈ �޼ҵ�
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٿ ��Ŭ�� ���Ŀ ��Ŭ�� �浹 �ߴٸ�
        if(collision.gameObject.tag.Equals("Blocker"))
        {
            BlockerCircleCollision blockrCircle = collision.gameObject.GetComponent<BlockerCircleCollision>();
            // �浹�� ���Ŀ ��Ŭ�� ������ ���� �ٿ ��Ŭ ����� �ٸ��ٸ�
            if (blockrCircle.ColorType.type != colorType.type)
            {
                // ���� ���� ���
                AudioSource.PlayClipAtPoint(failureSound, Camera.main.transform.position);

                // ���� ���� ó��
                gameManager.GameOver();

                // �ٿ ��Ŭ �ı� ����Ʈ ����
                GameObject fxPrefab = destoryColorFxPrefabs[(int)colorType.type];
                // ����Ʈ ����
                GameObject colorFx =Instantiate(fxPrefab, transform.position, fxPrefab.transform.rotation);
                Destroy(colorFx, 1.5f); // 1.5�ʵڿ� ����Ʈ �ı�

                // �ٿ ��Ŭ �ı�
                Destroy(gameObject);
                return;
            }

            // ���� ���� ���
            AudioSource.PlayClipAtPoint(successSound, Camera.main.transform.position);

            // ���� ���� �ο�
            gameManager.ScoreUp();

            // �ִϸ����Ϳ� 'Bouncing' Ʈ���� �Ķ���Ͱ� ���� -> �ٿ �ִϸ��̼� ���
            animator.SetTrigger("Bouncing");

            // �̵� ����
            movement.ReverseDirection();

            // ������ ������ �� �ٿ ��Ŭ�� ���� ���� ����
            RandomCircleColor();
        }
    }
}
