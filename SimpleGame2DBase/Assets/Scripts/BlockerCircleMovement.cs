using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerCircleMovement : MonoBehaviour
{
    [SerializeField] private Transform centerTransform; // ��� ��ġ ������ ���� Transform ������Ʈ
    [SerializeField] private Transform targetTransform; // �̵��� ��ġ ������ ���� Transform ������Ʈ

    [SerializeField] private float moveSpeed; // ���Ŀ �̵� �ӵ�

    [SerializeField] private Vector2 targetPosition; // �̵��� Ÿ�� ��ġ ���� ����

    [SerializeField] private bool moveTo = false; // �̵� ���� (�������� ��ġ����)

    [SerializeField] private Transform colorBlockerCircleTransform; // ���� ���Ŀ Transform ������Ʈ

    void Start()
    {
        // ���� ���Ŀ�� ������ġ�� ��� ��ġ�� ����
        colorBlockerCircleTransform.position = centerTransform.position;
        // �̵��� ��ġ ���� ����(������ ���� �̵����� �ʱ� ������ ���� ���Ŀ�� ��ġ�� Ÿ������ ����)
        targetPosition = centerTransform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // ������ Ÿ�� ��ġ�� ���ӿ�����Ʈ�� �̵� ��Ŵ
        colorBlockerCircleTransform.position = Vector2.MoveTowards(colorBlockerCircleTransform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    // ���Ŀ ���� �̵� ó��(���콺 Ŭ���� ����)
    public void ReverseMove()
    {
        // �̵� ���� ����(�̵�����)
        moveTo = !moveTo;
        targetPosition = moveTo ? targetTransform.position : centerTransform.position;
    }
}
