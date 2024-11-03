using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExitPopup : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private void OnEnable()
    {
        // ���� ������Ʈ�� ���� �Ͻ� ���� �˸�(�̺�Ʈ)�� ���� �� �ְ� ��������Ʈ �޼ҵ带 �����
        DelegateGameManager.onPauseDelegate += OnOpen;
        // ���� ������Ʈ�� ���� �Ͻ� ���� ���� �˸�(�̺�Ʈ)�� ���� �� �ְ� ��������Ʈ �޼ҵ带 �����
        DelegateGameManager.onResumeDelegate += OnClose;


    }

    // OnDisable : ���ӿ�����Ʈ�� ��Ȱ��ȭ(SetActive(false)) ���� �� ȣ�� �Ǵ� �̺�Ʈ �޼ҵ�
    // * Destroy �ɶ��� ȣ���
    private void OnDisable()
    {
        // ���� ������Ʈ�� ���� �Ͻ� ���� �˸�(�̺�Ʈ)�� ���� �� �ְ� ��������Ʈ �޼ҵ带 ����� ������
        DelegateGameManager.onPauseDelegate -= OnOpen;
        // ���� ������Ʈ�� ���� �Ͻ� ���� ���� �˸�(�̺�Ʈ)�� ���� �� �ְ� ��������Ʈ �޼ҵ带 ����� ������
        DelegateGameManager.onResumeDelegate -= OnClose;
    }
    public void OnOpen()
    {
        Debug.Log("���� �˾� ����");
        panel.gameObject.SetActive(true);
    }

    public void OnClose()
    {
        Debug.Log("���� �˾� ����");
        panel.gameObject.SetActive(false);
    }
}
