using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float scrollingSpeed = 10f;
    GameManager gameManeger;
    private void Start()
    {
        // FindObjectOfType ���� Find�� �Լ��� ���̾��Ű�� �÷��� ��� ���ӿ�����Ʈ�� ������ �˻� �մϴ�.
        // �׷��� ����� ��δ�.(�޸� ���� �Ҹ���)
        gameManeger = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        // Translate ��ȯ
        // ���ӿ��� ���𰡸� �̵� ��ų �� �� ��������ϴ� ���� �ֽ��ϴ�.
        // Time.deltaTime �� ���ϸ� �ӵ��� 1�̵ȴ�.
        // �������� �ʴ� 10 ��ŭ �����̴� �ڵ�
        if(!gameManeger.isGameover)
        { transform.Translate((Vector2)Vector3.left * scrollingSpeed * Time.deltaTime); }

    }
}
