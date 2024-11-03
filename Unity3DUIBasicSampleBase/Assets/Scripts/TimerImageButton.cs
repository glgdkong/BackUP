using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimerImageButton : MonoBehaviour
{
    // Fille Ÿ������ ������ Image ������Ʈ ����
    [SerializeField] private Image filledImage;
    // Ÿ�̸� ���� �ð�(��)
    [SerializeField] private float timerDuration;

    // Ÿ�̸� ���� �� ����
    private bool isTimerRunning = false;

    // �ð�
    private float timer;

    private void Update()
    {
        // Ÿ�̸Ӱ� ���� ���̶��
        if(isTimerRunning)
        {
            // ������ �帥�ٸ�
            if (timer > 0)
            {
                // Ÿ�� ����
                timer -= Time.deltaTime;
                // ���� ���� Filled Ÿ�� �̹����� ����
                filledImage.fillAmount = timer / timerDuration;
            }
            else
            { 
                // Ÿ�̸� ����
                isTimerRunning = false;
                // Filled Ÿ�� �̹��� �ʱ�ȭ
                filledImage.fillAmount = 0f;
                // ��ġ ���� ���·� ����
                filledImage.raycastTarget = true;
            }
        }
    }

    // �̹��� Ŭ�� �̺�Ʈ(Point Down)
    public void OnPointerDown(BaseEventData evt)
    {
        if (!isTimerRunning)
        {
            // Ÿ�̸� ����
            StartTimer();
        } 
    }
    // Ÿ�̸� ����
    private void StartTimer()
    {
        // ���� Ÿ�� ����
        timer = timerDuration;
        // Ÿ�̸� ���� ����
        isTimerRunning = true;
        // ��ġ �Ұ��� ���� ����
        filledImage.raycastTarget = false; // ��ġ �Ұ��� ���·� ����
    }
}
