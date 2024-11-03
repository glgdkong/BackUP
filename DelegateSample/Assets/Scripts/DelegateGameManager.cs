using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateGameManager : MonoBehaviour
{
    private bool isPaused = false; // �Ͻ� ���� ����

    // �̺�Ʈ ��������Ʈ �޼ҵ� ���� ���� (��������Ʈ Ÿ�� ����)
    public delegate void OnPauseDelegate(); // �Ͻ� ���� �̺�Ʈ ��������Ʈ ����
    public delegate void OnResumeDelegate(); // �Ͻ� ���� ���� �̺�Ʈ ��������Ʈ ����

    // ��������Ʈ �̺�Ʈ ���� ����
    // * ��������Ʈ�� �� static���� ���� ������ �� �ʿ�� ����
    public static OnPauseDelegate onPauseDelegate;
    public static OnResumeDelegate onResumeDelegate;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();  // �Ͻ� ���� ó�� ���� 
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // �Ͻ����� �̺�Ʈ ���� ��������Ʈ �޼ҵ� ����
            onPauseDelegate();
        }
        else
        {
            // �Ͻ����� ���� �̺�Ʈ ���� ��������Ʈ �޼ҵ� ����
            onResumeDelegate();
        }
    }
}
