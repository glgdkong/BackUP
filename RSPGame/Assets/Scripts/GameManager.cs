using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ��ư �迭 ����
    [SerializeField] private Button[] buttons;
    // �ؽ�Ʈ �迭 ����
    [SerializeField] private Text[] texts;
    // �̹��� �迭 ����
    [SerializeField] private Image[] images;
    // ��������Ʈ �迭 ����
    [SerializeField] private Sprite[] sprites;
    // ĵ���� �迭 ����
    [SerializeField] private Canvas[] canvas;

    // ���������� ���ڿ� �迭
    private string[] rSP = {"����", "����", "��"};
    // ���� ī��Ʈ�� ���� ������ �迭
    private int[] ints;
    // ���������� ���� �μ� 
    private int randomNum;
    // ��ǻ�� ���������� ���ڿ�
    private string comRSP;
    // �÷��̾� ���������� ���ڿ�
    private string playerRSP;

    private int golds = 0;

    // ���� Ŭ���� ����
    private bool isGameClear = false;

    void Start()
    {
        ints = new int[rSP.Length];
        randomNum = Random.Range(0, rSP.Length);
        comRSP = rSP[randomNum];
        //Debug.Log($"������ �� ���������� {comRSP}");
        buttons[0].onClick.AddListener(Scissors);
        buttons[1].onClick.AddListener(Rock);
        buttons[2].onClick.AddListener(Paper);
        buttons[3].onClick.AddListener(Restart);
        texts[4].text = LoginManger.nickname;
    }

    private void Scissors()
    {
        RSPResult(0);
    }
    private void Rock()
    {
        RSPResult(1);
    }
    private void Paper()
    {
        RSPResult(2);
    }
    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
    private void RSPResult(int rspIndex) 
    {
        playerRSP = rSP[rspIndex];
        images[0].sprite = sprites[rspIndex];
        images[1].sprite = sprites[randomNum];
        if (playerRSP == comRSP)
        {
            // ��� ���
            texts[1].text = $"User({playerRSP}) Vs Com({comRSP}) �����? ... ���º�!";
            // ���º� ī��Ʈ
            ints[2]++;
            // ���� ���
            texts[0].text = $"���� : ��({ints[0]}), ��({ints[1]}), ���º�({ints[2]})";
            // ��ǻ�� ���������� �����
            randomNum = Random.Range(0, rSP.Length);
            comRSP = rSP[randomNum];
            //Debug.Log($"������ �� ���������� {comRSP}");
            // ���º� ��� �߰�
            golds += 10;
            texts[2].text = $"{golds} ���";
        }
        else if((rspIndex.Equals(0) && randomNum.Equals(2))|| (rspIndex.Equals(1) && randomNum.Equals(0)) || (rspIndex.Equals(2) && randomNum.Equals(1)))
        {
            // ��� ���
            texts[1].text = $"User({playerRSP}) Vs Com({comRSP}) �����? ... User ��!";
            // ��� ī��Ʈ
            ints[0]++;
            // ���� ���
            texts[0].text = $"���� : ��({ints[0]}), ��({ints[1]}), ���º�({ints[2]})";
            // ��ǻ�� ���������� �����
            randomNum = Random.Range(0, rSP.Length);
            comRSP = rSP[randomNum];
            //Debug.Log($"������ �� ���������� {comRSP}");
            // ��� ��� �߰�
            golds += 100;
            texts[2].text = $"{golds} ���";
        }
        else
        {
            // ��� ���
            texts[1].text = $"User({playerRSP}) Vs Com({comRSP}) �����? ... Com ��!";
            // �й� ī��Ʈ
            ints[1]++;
            // ���� ���
            texts[0].text = $"���� : ��({ints[0]}), ��({ints[1]}), ���º�({ints[2]})";
            // ��ǻ�� ���������� �����
            randomNum = Random.Range(0, rSP.Length);
            comRSP = rSP[randomNum];
            //Debug.Log($"������ �� ���������� {comRSP}");
            // �й� ��� �߰�
            golds += -20;
            texts[2].text = $"{golds} ���";
        }
    }
    private void Update()
    {
        if (golds >= 2000 && !isGameClear)
        {
            canvas[0].gameObject.SetActive(false);
            canvas[1].gameObject.SetActive(true);
            texts[3].text = $"���� : ��({ints[0]}), ��({ints[1]}), ���º�({ints[2]})";
            isGameClear = true;
        }
    }
}
