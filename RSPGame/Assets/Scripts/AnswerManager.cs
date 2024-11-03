using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    // 텍스트 배열 참조
    [SerializeField] private TextMeshProUGUI[] numberTexts;
    [SerializeField] private TMP_InputField input;

    // 버튼 참조
    [SerializeField] private Button answerButton;

    private void Start()
    {
        //answerButton.onClick.AddListener(Answer);
    }

    public void Answer()
    {
        // 데이터 타입이 완전 다른 경우 int.Parse로 형변환해야한다.
        //int num = int.Parse(numberText.text);
        int num;
        int digitCount = 0;
        // 파싱이 가능하면 파싱해서 out 변수에 저장해준다.
        // 파싱이 불가능하면 false 리턴
        if (int.TryParse(input.text, out num))
        {
            if (num == 0)
                { numberTexts[1].text = $"입력 범위 값이 아닙니다. 다시 입력해주세요"; return; }
            while (num > 0)
            {
                num /= 10; // 10으로 나누어 자릿수 감소
                digitCount++;
                if (digitCount >= 5)
                {
                    numberTexts[1].text = $"입력 범위 값이 아닙니다. 다시 입력해주세요";
                    return;
                }
            }
            numberTexts[1].text = $"{digitCount}의 자릿수 입니다";
        }
        else
        {
            input.text = string.Empty;
            numberTexts[0].text = "1부터 9999까지의\r\n수를 다시 입력하세요";
        }
    }
}
