using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 스코어 표시 텍스트 컴포넌트 참조
    [SerializeField] private Text scoreText;

    [SerializeField] private Text bestScoreText;

    [SerializeField] private int startTime; // 시작시간 

    [SerializeField] private Text timerText; // 게임 시작 표시 텍스트 컴포넌트 참조
    private int time;

    private void Start()
    {
        //
        bestScoreText.text = PlayerPrefs.GetString("BEST_SCORE", "0");

        StartCoroutine(GameTimerCoroutine());
    }

    private void UpdateBestScore()
    {
        // 각 비교할 점수들을 정수값을 변경
        int bestScore = int.Parse(bestScoreText.text);
        int score = int.Parse(scoreText.text);

        // 현재 점수와 최고 점수 비교
        if (bestScore < score)
        {
            // 최고 점수 갱신
            bestScoreText.text = scoreText.text;
            PlayerPrefs.SetString("BEST_SCORE", scoreText.text);
        }
        // 현재 스코어를 저장
        PlayerPrefs.SetString("SCORE", scoreText.text);
        PlayerPrefs.Save();
    }

    private void GameEnd()
    {
        // 각 비교할 점수들을 정수값을 변경
        int bestScore = int.Parse(bestScoreText.text);
        int score = int.Parse(scoreText.text);

        // 현재 점수와 최고 점수 비교
        if(bestScore < score)
        {
            // 최고 점수 갱신
            PlayerPrefs.SetString("BEST_SCORE", scoreText.text);
        }
        // 현재 스코어를 저장
        PlayerPrefs.SetString("SCORE", scoreText.text);
        PlayerPrefs.Save();

        // 게임 종료씬으로 이동
        //SceneManager.LoadScene("EndScene");


    }

    IEnumerator GameTimerCoroutine()
    { 
        time = startTime; // 시작 시간 설정

        while (time > 0) // 시간이 0이 될때 까지 반복
        {
            // 시간 출력
            timerText.text = time.ToString();
            // 1초 지연
            yield return new WaitForSeconds(1f);
            // 시간 감소
            time--;
        }
        // 최종 시간 표시 -> 0초
        timerText.text = time.ToString();

        // 게임 종료
        GameEnd();
    }

    public void TimeUp(int time)
    {
        // 현재 텍스트에 표시된 시간 값을 참조
        int t = this.time;

        // 시간증가 처리
        t += time ;
        // 타이버 업데이트
        this.time = t;
    }

    public void ScoreUp(int slimeScore)
    {
        // 현재 스코어 텍스트를 정수값으로 변환
        int score = int.Parse(scoreText.text);
        
        // 스코어 누적 연산
        score += slimeScore;

        // 스코어 정수값을 문자열로 변환하여 텍스트 컴포넌트에 적용
        scoreText.text = score.ToString();
        UpdateBestScore();
    }
}
