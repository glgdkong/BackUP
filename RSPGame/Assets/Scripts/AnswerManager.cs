using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    // �ؽ�Ʈ �迭 ����
    [SerializeField] private TextMeshProUGUI[] numberTexts;
    [SerializeField] private TMP_InputField input;

    // ��ư ����
    [SerializeField] private Button answerButton;

    private void Start()
    {
        //answerButton.onClick.AddListener(Answer);
    }

    public void Answer()
    {
        // ������ Ÿ���� ���� �ٸ� ��� int.Parse�� ����ȯ�ؾ��Ѵ�.
        //int num = int.Parse(numberText.text);
        int num;
        int digitCount = 0;
        // �Ľ��� �����ϸ� �Ľ��ؼ� out ������ �������ش�.
        // �Ľ��� �Ұ����ϸ� false ����
        if (int.TryParse(input.text, out num))
        {
            if (num == 0)
                { numberTexts[1].text = $"�Է� ���� ���� �ƴմϴ�. �ٽ� �Է����ּ���"; return; }
            while (num > 0)
            {
                num /= 10; // 10���� ������ �ڸ��� ����
                digitCount++;
                if (digitCount >= 5)
                {
                    numberTexts[1].text = $"�Է� ���� ���� �ƴմϴ�. �ٽ� �Է����ּ���";
                    return;
                }
            }
            numberTexts[1].text = $"{digitCount}�� �ڸ��� �Դϴ�";
        }
        else
        {
            input.text = string.Empty;
            numberTexts[0].text = "1���� 9999������\r\n���� �ٽ� �Է��ϼ���";
        }
    }
}
