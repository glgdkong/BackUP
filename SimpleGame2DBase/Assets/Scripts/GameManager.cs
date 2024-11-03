using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 블로커 이동 컴포넌트들 참조
    [SerializeField] private BlockerCircleMovement[] blockerCircleMovements;

    private int score; // 점수
    [SerializeField] private Text scoreText; // 점수 출력 텍스트

    [SerializeField] private float gameReStartDelayTime; // 게임 재시작 지연 시잔

    private float time; // 시간 계산용 변수
    [SerializeField]private float inputWaitTime; // 연속 입력 제한 시간

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        // 마우스 왼쪽 버튼을 눌렀다면
        if (Input.GetMouseButtonDown(0) && time >= inputWaitTime )
        {
            // for (int = 0; i<blockerCircleMovement.Length; i++){blockerMovement.ReverseMove();}
            foreach (BlockerCircleMovement blockerMovement in blockerCircleMovements)
            {
                // 블로커 반전 메소드 실행
                blockerMovement.ReverseMove();
            }
            time = 0;
        }
    }

    public void ScoreUp()
    {
        score++; // 점수 증가
        // 이전 최고 점수 불러오기
        int bestScore = PlayerPrefs.GetInt("BEST", 0);
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("BEST", score);
            PlayerPrefs.Save();
        }

        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        StartCoroutine("GameOverCoroutine");
    }
    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(gameReStartDelayTime);

        SceneManager.LoadScene("StartScene");
    }
}
