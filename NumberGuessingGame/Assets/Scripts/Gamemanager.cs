using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Text[] texts;
    private int number;
    private int gameCount;
    private int equlasNumCount = 0;
    [Range(1, 99), SerializeField] private int lowNumber = 1;
    public int LowNumber { get => lowNumber; set => lowNumber = value; }

    [Range(2,100), SerializeField] private int highNumber = 100;
    public int HighNumber { get => highNumber; set => highNumber = value; }

    private bool isGameable = true;

    void Start()
    {
        number = Random.Range(LowNumber, HighNumber);
        texts[1].text = $"����� ������ ���ڴ� {number}�Դϱ�?";
        buttons[0].onClick.AddListener(NumberIsTrue);
        buttons[1].onClick.AddListener(NumberIsBig);
        buttons[2].onClick.AddListener(NumberIsLow);
        buttons[3].onClick.AddListener(GameReStart);
        StartCoroutine("NumberCheckCoroutine");
    }
    private void NumberIsTrue()
    {
        if (isGameable)
        {
            texts[2].fontSize = 63;
            texts[2].text = $"����� �����ϴ� ���ڴ� {number}�Դϴ�.";
            texts[0].text = $"{gameCount}��";
            isGameable = false;
        }
    }

    private void NumberIsLow()
    {
        if (isGameable)
        {
            LowNumber = (number == 100 ? 100 : number + 1);
            LowNumber = LowNumber > HighNumber ? HighNumber : LowNumber;
            number = Random.Range(LowNumber, HighNumber);
            texts[1].text = $"����� ������ ���ڴ� {number}�Դϱ�?";
            gameCount++;
            texts[0].text = $"{gameCount}��";
        }
        if (number == 1 || number == 100)
        {
            equlasNumCount++;
            if (equlasNumCount >= 3)
            {
                texts[2].text = $"�ùٸ� ���ڸ� �ٽ� �������ּ���";
                isGameable = false;
            }
        }
    }

    private void NumberIsBig()
    {
        if (isGameable)
        {
            HighNumber = (number == 1 ? 1 : number - 1);
            HighNumber = LowNumber > HighNumber ? LowNumber : HighNumber;
            number = Random.Range(LowNumber, HighNumber);
            texts[1].text = $"����� ������ ���ڴ� {number}�Դϱ�?";
            gameCount++;
            texts[0].text = $"{gameCount}��";
        }

        if (number == 1 || number == 100)
        {
            equlasNumCount++;
            if (equlasNumCount >= 3)
            {
                texts[2].text = $"�ùٸ� ���ڸ� �ٽ� �������ּ���";
                isGameable = false;
            }
        }
    }
    private void GameReStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    IEnumerator NumberCheckCoroutine()
    {
        bool reset = true;
        while(isGameable)
        {
            yield return new WaitForFixedUpdate();
            if (gameCount == 10 && reset)
            {
                texts[2].fontSize = 40;
                texts[2].text = $"��ư�� �߸� �����̳���? ������ �ٽ� �ʱ�ȭ �ص�Ƚ��ϴ�.";
                LowNumber = 1;
                HighNumber = 100;
                reset = false;
                yield return new WaitForSeconds(1f);
                texts[2].text = "";
            }
            if (gameCount == 20)
            {
                texts[2].fontSize = 63;
                texts[2].text = $"����� �����ϴ� ���ڸ� �𸣰ڽ��ϴ�";
                isGameable = false;
                yield break;
            }
        }
    }
}
