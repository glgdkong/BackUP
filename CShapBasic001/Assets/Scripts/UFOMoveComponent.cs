using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UFO �̵� ������Ʈ

public class UFOMoveComponent : MonoBehaviour
{
    // ����(�Ӽ�) ����(����) -> ���� ���� �޸� ����

    // X �̵� ����
    public float X;
    // Y �̵� ����
    public float Y;
    // Z �̵� ����
    public float Z;

    // �̵� �ӵ�
    public float MoveSpeed;

    // ����Ƽ �̺�Ʈ ���� �޼ҵ�
    // Start �޼ҵ� : ���� ������Ʈ�� ������ ���ӿ�����Ʈ�� ȭ�鿡 ������(�׷�����) �ٷ� ���� ����Ƽ�� �� 1�� ��������ִ� �̺�Ʈ �޼ҵ�
    public void Start()
    {
        Debug.Log("UFO ������ �ٷ� ���� ó���� ����");

        // ����(�Ӽ�)�� ����
        // ���� -> ������ = ��;

        X = 1f; // X ���Ⱚ ���� (�޸�/���� �� ����)
        Y = 0f; // Y ���Ⱚ ����
        Z = 0f; // Z ���Ⱚ ����

        MoveSpeed = 1.2f; // UFO �̵� �ӵ� ����

        // Debug.Log($"{������} ���ڿ� ����")

        Debug.Log($"����({X}, {Y}, {Z}), �ӵ�({MoveSpeed})");

    }

    // ����Ƽ �̺�Ʈ �޼ҵ�
    // Update : ȭ�鿡 ���� ������Ʈ�� ���� ���ӿ�����Ʈ�� �׷��������� ȣ��(����)�Ǵ� �̺�Ʈ �޼ҵ�
    // ��) 60fps -> �ʴ� 60������ -> 1�� 60�� �����
    public void Update()
    {
        
        
        // �̵� �ڵ� ���� (����(�Ӽ�)�� ���丸 ������ ��)
        transform.Translate(new Vector3(X, Y, Z) * MoveSpeed * Time.deltaTime);
    }
}
