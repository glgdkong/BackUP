using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// UFO �̵��ϱ� Ŭ����(������Ʈ)
public class UFO�̵�������Ʈ : MonoBehaviour
{
    public Transform ����ƼƮ������������Ʈ��������;

    public float �̵��ӵ�; // �̵� �ӵ� ����

    public void �Է��̵�ó���ϱ�()
    {
        // ���� �Է�Ű�� ����
        float �¿�Ű�� = Input.GetAxisRaw("Horizontal");
        float ���Ʒ�Ű�� = Input.GetAxisRaw("Vertical");

        // �̵� ���� ���� ����
        Vector2 �̵����� = new Vector2(�¿�Ű��, ���Ʒ�Ű��);

        //Debug.Log($"�̵����⺤�� : {�̵�����}");

        // Transform.Translate �޼ҵ�
        // Transform��������.Translate(�̵����� * �ӵ� *  Time.deltaTime)

        // ����Ƽ�� Trnasform ������Ʈ�� ���������� ���� Translate �޼ҵ带 ������
        ����ƼƮ������������Ʈ��������.Translate(�̵����� * �̵��ӵ� * Time.deltaTime);
    }
}
