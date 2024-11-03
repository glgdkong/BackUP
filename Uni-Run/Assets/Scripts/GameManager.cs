using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // 게임의 상태와 점수
    public bool isGameover = false;
    public TextMeshProUGUI[] tmpScore;
    public GameObject gameoverUI;

    private int score = 0;

    private void Update()
    {
        // 게임 재시작
        // 게임 오버인지, 스페이스키를 눌렀는지? 검사
        if (isGameover && Input.GetKeyDown(KeyCode.Space))
        {
            // 씬은 불러오면 게임이 재시작 된다.
            // 씬을 불러오는 함수 LoadScene(), 파라미터로 문자열 혹은 정수를 넘길 수 있습니다.
            // 문자열일 때는 씬의 이름, 정수일 때는 빌드 인덱스
            //SceneManager.LoadScene("Uni Run");

            // 현재 활성화 된 씬의 이름을 가져옴.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // 게임 오버

    public void Gameover()
    {
        isGameover = true;

        gameoverUI.SetActive(true);
        int bestScore = PlayerPrefs.GetInt("BestScoer", 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScoer", score);
            PlayerPrefs.Save();
        }
        tmpScore[1].gameObject.SetActive(true);
        tmpScore[1].text = "최고 점수 : " + PlayerPrefs.GetInt("BestScoer").ToString();
        /*for (int i = 0; i < scrollings.Length; i++)
        {
            scrollings[i].scrollingSpeed = 0;
        }*/
    }

    // 점수 추가 
    public void AddScore(int newScore)
    {
        // 게임오버강 아닌동안에만 점수를 추가하도록 함.
        if (!isGameover)
        {
            score += newScore;
            tmpScore[0].text = "점수 : " + score;
        }
    }

}
