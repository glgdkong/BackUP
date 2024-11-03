using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatePlayer : MonoBehaviour
{
    private bool isRotating = true;
    [SerializeField] private float rotateSpeed;
    void Update()
    {
        if (!isRotating) return;

        // �÷��̾��� ���� �ڵ�
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
    // OnEnable : ���ӿ�����Ʈ�� Ȱ��ȭ(SetActive(true)) ���� �� ȣ�� �Ǵ� �̺�Ʈ �޼ҵ�
    // * Instactiate �ɶ��� ȣ���
    private void OnEnable()
    {
        // ���� ������Ʈ�� ���� �Ͻ� ���� �˸�(�̺�Ʈ)�� ���� �� �ְ� ��������Ʈ �޼ҵ带 �����
        DelegateGameManager.onPauseDelegate += OnPause;
        // ���� ������Ʈ�� ���� �Ͻ� ���� ���� �˸�(�̺�Ʈ)�� ���� �� �ְ� ��������Ʈ �޼ҵ带 �����
        DelegateGameManager.onResumeDelegate += OnResume;


    }

    // OnDisable : ���ӿ�����Ʈ�� ��Ȱ��ȭ(SetActive(false)) ���� �� ȣ�� �Ǵ� �̺�Ʈ �޼ҵ�
    // * Destroy �ɶ��� ȣ���
    private void OnDisable()
    {
        // ���� ������Ʈ�� ���� �Ͻ� ���� �˸�(�̺�Ʈ)�� ���� �� �ְ� ��������Ʈ �޼ҵ带 ����� ������
        DelegateGameManager.onPauseDelegate -= OnPause;
        // ���� ������Ʈ�� ���� �Ͻ� ���� ���� �˸�(�̺�Ʈ)�� ���� �� �ְ� ��������Ʈ �޼ҵ带 ����� ������
        DelegateGameManager.onResumeDelegate -= OnResume;
    }

    public void OnPause()
    {
        Debug.Log("ȸ�� ������ ����");
        isRotating = false;
    }

    public void OnResume()
    {
        Debug.Log("ȸ�� ������ �ٽ� ����");
        isRotating = true;
    }
}
