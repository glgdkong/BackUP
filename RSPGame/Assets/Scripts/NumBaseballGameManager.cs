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
    // ���� �Է� ��ȣ
    [SerializeField] private InputField inputNum;
    [SerializeField] private InputField resultPrint;

    private int strikeCount = 0;
    private int ballCount = 0;
    private int outCount = 0;
    private int loseCount = 0;
    private int gameCount = 12;

    private List<string> numbers = new List<string>(); // ��ư Ŭ���� ���� ������ ����Ʈ

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
        if (numbers.Count < 3) // ������ ������ 3�� �̸��� ��츸 �߰�
        {
            if (!numbers.Contains(number.ToString())) // �ߺ� üũ
            {
                numbers.Add(number.ToString()); // Ŭ���� ���ڸ� ���ڿ��� ����Ʈ�� �߰�
                UpdateUIText(); // UI �ؽ�Ʈ ������Ʈ
            }
        }
    }
    private void UpdateUIText()
    {
        inputNum.text = string.Join(" ", numbers); // ����Ʈ�� ���ڸ� �� �������� �����Ͽ� ����
    }

    
    public void CompareNum()
    {
        if (!isStart) return;
        if (!dropdown.gameObject.activeSelf) dropdown.gameObject.SetActive(true);
        strikeCount = 0;
        ballCount = 0;
        outCount = 0;
        gameCount--;

        // ��Ʈ����ũ�� �� üũ
        for (int i = 0; i < numbers.Count; i++)
        {
            bool hasNumber = false; // ���ڰ� �߰ߵǾ������� �����ϴ� ����
            // ��Ʈ����ũ üũ
            if (int.Parse(numbers[i]) == SelectedNum[i])
            {
                //Debug.Log($"{SelectedNum[i]}�� {numbers[i]}�� �ڸ����� ��ȣ�� ��ġ");
                strikeCount++;
                continue;
            }
            else
            {
                // �� üũ
                for (int j = 0; j < SelectedNum.Count; j++)
                {
                    if (int.Parse(numbers[i]) == SelectedNum[j]) // �ڸ����� �ٸ��� ���ڰ� ���� ���
                    {
                        //Debug.Log($"��: {SelectedNum[j]}");
                        ballCount++;
                        hasNumber = true; // ���ڰ� �߰ߵ�
                        break; // �� �� �߰��ϸ� �������� �Ѿ
                    }
                }
            }
            // �ƿ� üũ
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
        resultPrint.text = $"���� ���� Ƚ�� [{gameCount}]\r\n��� ��Ʈ����ũ[{strikeCount}], ��[{ballCount}], �ƿ�[{outCount}]";
        if (outCount == 3)
        {
            resultPrint.text = $"���� ���� Ƚ�� [{gameCount}]\r\n��� ��Ʈ����ũ[{strikeCount}], ��[{ballCount}], �ƿ�[{outCount}]\r\n�ƿ��� 3 �̹Ƿ� �ѹ� �й��ϼ̽��ϴ�. \r\n���� �й��� ���� [{loseCount}]";
        }

    }

    private void GameWin()
    {
        if (strikeCount == 3)
        {
            resultPrint.text = "�����մϴ�. ���ӿ��� �¸��ϼ̽��ϴ�.";
            startButton.interactable = true;
        }
    }

    private void GameLose()
    {
        if (loseCount == 3 || gameCount == 0) 
        {
            resultPrint.text = "���ӿ��� ���̽��ϴ�. ������ �ٽ� �����ϼ���";
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
        string printCR = $"[{12 - gameCount}]ȸ, ���� �Է� �� : [{inputNum.text}], ��Ʈ����ũ[{strikeCount}], ��[{ballCount}], �ƿ�[{outCount}]";
        return printCR;
    }
}
