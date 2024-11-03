using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 버튼 배열 참조
    [SerializeField] private Button[] buttons;
    // 텍스트 배열 참조
    [SerializeField] private Text[] texts;
    // 이미지 배열 참조
    [SerializeField] private Image[] images;
    // 스프라이트 배열 참조
    [SerializeField] private Sprite[] sprites;
    // 캔버스 배열 참조
    [SerializeField] private Canvas[] canvas;

    // 가위바위보 문자열 배열
    private string[] rSP = {"가위", "바위", "보"};
    // 승패 카운트를 담을 정수형 배열
    private int[] ints;
    // 가위바위보 랜덤 인수 
    private int randomNum;
    // 컴퓨터 가위바위보 문자열
    private string comRSP;
    // 플레이어 가위바위보 문자열
    private string playerRSP;

    private int golds = 0;

    // 게임 클리어 여부
    private bool isGameClear = false;

    void Start()
    {
        ints = new int[rSP.Length];
        randomNum = Random.Range(0, rSP.Length);
        comRSP = rSP[randomNum];
        //Debug.Log($"다음에 낼 가위바위보 {comRSP}");
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
            // 결과 출력
            texts[1].text = $"User({playerRSP}) Vs Com({comRSP}) 결과는? ... 무승부!";
            // 무승부 카운트
            ints[2]++;
            // 전적 출력
            texts[0].text = $"전적 : 승({ints[0]}), 패({ints[1]}), 무승부({ints[2]})";
            // 컴퓨터 가위바위보 재출력
            randomNum = Random.Range(0, rSP.Length);
            comRSP = rSP[randomNum];
            //Debug.Log($"다음에 낼 가위바위보 {comRSP}");
            // 무승부 골드 추가
            golds += 10;
            texts[2].text = $"{golds} 골드";
        }
        else if((rspIndex.Equals(0) && randomNum.Equals(2))|| (rspIndex.Equals(1) && randomNum.Equals(0)) || (rspIndex.Equals(2) && randomNum.Equals(1)))
        {
            // 결과 출력
            texts[1].text = $"User({playerRSP}) Vs Com({comRSP}) 결과는? ... User 승!";
            // 우승 카운트
            ints[0]++;
            // 전적 출력
            texts[0].text = $"전적 : 승({ints[0]}), 패({ints[1]}), 무승부({ints[2]})";
            // 컴퓨터 가위바위보 재출력
            randomNum = Random.Range(0, rSP.Length);
            comRSP = rSP[randomNum];
            //Debug.Log($"다음에 낼 가위바위보 {comRSP}");
            // 우승 골드 추가
            golds += 100;
            texts[2].text = $"{golds} 골드";
        }
        else
        {
            // 결과 출력
            texts[1].text = $"User({playerRSP}) Vs Com({comRSP}) 결과는? ... Com 승!";
            // 패배 카운트
            ints[1]++;
            // 전적 출력
            texts[0].text = $"전적 : 승({ints[0]}), 패({ints[1]}), 무승부({ints[2]})";
            // 컴퓨터 가위바위보 재출력
            randomNum = Random.Range(0, rSP.Length);
            comRSP = rSP[randomNum];
            //Debug.Log($"다음에 낼 가위바위보 {comRSP}");
            // 패배 골드 추가
            golds += -20;
            texts[2].text = $"{golds} 골드";
        }
    }
    private void Update()
    {
        if (golds >= 2000 && !isGameClear)
        {
            canvas[0].gameObject.SetActive(false);
            canvas[1].gameObject.SetActive(true);
            texts[3].text = $"전적 : 승({ints[0]}), 패({ints[1]}), 무승부({ints[2]})";
            isGameClear = true;
        }
    }
}
