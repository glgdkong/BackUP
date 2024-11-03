using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.UI;

public class NumBaseballGameManager : MonoBehaviour
{
    private const int Max_Baseball = 9;
    // 
    private List<int> RandomBaseball = new List<int>();
    private List<int> SelectedNum = new List<int>();
    private const int Baseball_Count = 3;
    // 유저 입력 번호
    [SerializeField] private InputField inputNum;
    [SerializeField] private InputField resultPrint;

    private int strikeCount = 0;
    private int ballCount = 0;
    private int outCount = 0;
    private int loseCount = 0;
    private int gameCount = 12;

    private List<string> numbers = new List<string>(); // 버튼 클릭한 수를 저장할 리스트

    [SerializeField] private Dropdown dropdown;
    private List<string> resultTitle = new List<string>();

    private bool isStart = false;

    [SerializeField] private Button startButton;


    private void Start()
    {
        
    }

    private void BallBoxClear()
    {
        RandomBaseball.Clear();
        SelectedNum.Clear(); 
        InputClear();
        strikeCount = 0;
        ballCount = 0;
        outCount = 0;
        loseCount = 0;
        resultTitle.Clear();
        dropdown.gameObject.SetActive(false);
        dropdown.ClearOptions();
    }
    private void BaseballReset()
    {
        // 2.
        for (int i = 1; i <= Max_Baseball; i++)
        {
            RandomBaseball.Add(i);
        }
    }
    private void ComRandomBaseNum()
    {
        // 4.
        for (int i = 0; i < Baseball_Count; i++)
        {
            // 3.
            int index = UnityEngine.Random.Range(0, RandomBaseball.Count);
            SelectedNum.Add(RandomBaseball[index]);
            RandomBaseball.RemoveAt(index);
        }
        string lottoString = string.Join(", ", SelectedNum);
        Debug.Log(lottoString);
    }
    public void GameRestart()
    {
        isStart = true;
        gameCount = 12;
        BallBoxClear();
        BaseballReset();
        ComRandomBaseNum();
        resultPrint.text = string.Empty;
        startButton.interactable = false;
    }

    private void InputClear()
    {
        inputNum.text = string.Empty;
        numbers.Clear();
    }


    public void InputNumber(int number)
    {
        if (numbers.Count < 3) // 숫자의 개수가 3개 미만인 경우만 추가
        {
            if (!numbers.Contains(number.ToString())) // 중복 체크
            {
                numbers.Add(number.ToString()); // 클릭한 숫자를 문자열로 리스트에 추가
                UpdateUIText(); // UI 텍스트 업데이트
            }
        }
    }
    private void UpdateUIText()
    {
        inputNum.text = string.Join(" ", numbers); // 리스트의 숫자를 빈 공간으로 연결하여 설정
    }

    
    public void CompareNum()
    {
        if (!isStart) return;
        if (!dropdown.gameObject.activeSelf) dropdown.gameObject.SetActive(true);
        strikeCount = 0;
        ballCount = 0;
        outCount = 0;
        gameCount--;

        // 스트라이크와 볼 체크
        for (int i = 0; i < numbers.Count; i++)
        {
            bool hasNumber = false; // 숫자가 발견되었는지를 추적하는 변수
            // 스트라이크 체크
            if (int.Parse(numbers[i]) == SelectedNum[i])
            {
                //Debug.Log($"{SelectedNum[i]}과 {numbers[i]}이 자릿수와 번호가 일치");
                strikeCount++;
                continue;
            }
            else
            {
                // 볼 체크
                for (int j = 0; j < SelectedNum.Count; j++)
                {
                    if (int.Parse(numbers[i]) == SelectedNum[j]) // 자릿수가 다르고 숫자가 같은 경우
                    {
                        //Debug.Log($"볼: {SelectedNum[j]}");
                        ballCount++;
                        hasNumber = true; // 숫자가 발견됨
                        break; // 한 번 발견하면 다음으로 넘어감
                    }
                }
            }
            // 아웃 체크
            if (!hasNumber)
            {
                outCount++;
            }
        }
        if(outCount == 3)
        {
            loseCount++;
        }
        CompareResult();
        ResultPrint();
        InputClear();
        GameLose();
        GameWin();
    }

    private void ResultPrint()
    {
        resultPrint.text = $"현재 게임 횟수 [{gameCount}]\r\n결과 스트라이크[{strikeCount}], 볼[{ballCount}], 아웃[{outCount}]";
        if (outCount == 3)
        {
            resultPrint.text = $"현재 게임 횟수 [{gameCount}]\r\n결과 스트라이크[{strikeCount}], 볼[{ballCount}], 아웃[{outCount}]\r\n아웃이 3 이므로 한번 패배하셨습니다. \r\n현재 패배한 숫자 [{loseCount}]";
        }

    }

    private void GameWin()
    {
        if (strikeCount == 3)
        {
            resultPrint.text = "축하합니다. 게임에서 승리하셨습니다.";
            startButton.interactable = true;
        }
    }

    private void GameLose()
    {
        if (loseCount == 3 || gameCount == 0) 
        {
            resultPrint.text = "게임에서 지셨습니다. 다음에 다시 도전하세요";
            startButton.interactable = true;
        }
    }

    private void CompareResult()
    {
        resultTitle.Add(CR());
        dropdown.AddOptions(resultTitle);
        resultTitle.Clear();
    }


    private string CR()
    {
        string printCR = $"[{12 - gameCount}]회, 유저 입력 값 : [{inputNum.text}], 스트라이크[{strikeCount}], 볼[{ballCount}], 아웃[{outCount}]";
        return printCR;
    }
}
