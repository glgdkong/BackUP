using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // ��ֹ��� Ȱ��ȭ, ��Ȱ��ȭ ��Ų��.
    [SerializeField] private GameObject[] obstacles; // ��ֹ� ����, ��ֹ� 3�� ��������.
    private bool isStepped = false; // ������ �÷��̾ ��Ҵ��� ����
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    // ���� ������Ʈ�� Ȱ��ȭ �� ������ ȣ��Ǵ� ����Ƽ �̺�Ʈ �Լ�
    // ���� ������Ʈ�� Ȱ��ȭ �Ǿ��ٴ� ���� � �ǹ�? => ������ ���� �����Ǿ���
    private void OnEnable() // Instantiate���� �����Ǵ� ��쿡�� ȣ���� �ȴ�
    {
        
        isStepped = false;

        // 1/3 Ȯ���� �ϳ��� ��ֹ� Ȱ��ȭ, 1/9 Ȯ���� �ΰ��� ��ֹ� Ȱ��ȭ, 1/27 Ȯ���� ������ ��ֹ� Ȱ��ȭ 

        // �迭�� ���̸�ŭ �ݺ��� ����
        for (int i = 0; i < obstacles.Length; i++)
        {
            // �迭�� ������ �� ���� ��ȣ���� �������� ���� ���� 0 �̸� (1/3 Ȯ���� �����Ѱ�)
            if(Random.Range(0, obstacles.Length) == 0)
            {
                // i��° ��ֹ� ���ӿ�����Ʈ Ȱ��ȭ
                obstacles[i].SetActive(true);
            }
            else // �ƴ϶��
            {
                // i��° ��ֹ� ������Ʈ ��Ȱ��ȭ
                obstacles[i].SetActive(false);
            }
        }
    }

    // �÷��̾ ���ǿ� �������� �� ������ �߰�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Player") && !isStepped)
        {
            // Find�� �Լ��� ���̾��Ű�� �ִ� ��� ������Ʈ�� �˻��Ѵ�.
            // ȿ���� �ſ� ���� �ʴ�.
            // �� �ʿ��� ��쿡�� ����ؾ��Ѵ�
            //GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.AddScore(2);
            // ���� �ϳ� �� 1ȸ�� ���� �߰� �ϵ��� ����
            isStepped = true;
        }
    }
}
