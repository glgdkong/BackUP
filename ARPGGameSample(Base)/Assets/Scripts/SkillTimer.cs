using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTimer : MonoBehaviour
{
    // Filled Ÿ������ ������ Image ������Ʈ ����
    [SerializeField] private Image filledImage;
    // Ÿ�̸� ���� �ð� (��)
    private float timerDuration;
    // Ÿ�̸� ������ ����
    private bool isTimerRunning = false;
    // �ð�
    private float timer;

    // ��ų ���� ó�� ������Ʈ
    private SkillAttack skillAttack;


    private void Update()
    {
        // Ÿ�̸Ӱ� ���� ���̶��
        if (isTimerRunning)
        {
            // �ð��� �帥�ٸ�
            if(timer > 0)
            {
                // Ÿ�� ����
                timer -= Time.deltaTime;

                // ���� ���� Filled Ÿ�� �̹����� ����
                filledImage.fillAmount = timer / timerDuration;
            }
            else
            {
                EndTimer();
            }
        }
    }

    // Ÿ�̸� ����
    public void StartTimer(SkillAttack skillAttack, float timeDuration)
    {
        this.skillAttack = skillAttack;

        timerDuration = timeDuration;

        // ���� Ÿ�� ����
        timer = timerDuration;
        // Ÿ�̸� ���� ����
        isTimerRunning = true;
        // ��ġ �Ұ��� ���� ����
        filledImage.raycastTarget = false; // ��ġ �Ұ��� ���·� ����
    }

    public void EndTimer()
    {
        // Ÿ�̸� ����
        isTimerRunning = false;
        // Filled Ÿ�� �̹��� �ʱ�ȭ
        filledImage.fillAmount = 0f;
        // ��ġ ���� ���·� ����
        filledImage.raycastTarget = true;
     
        skillAttack.EndSkill();
    }
}
