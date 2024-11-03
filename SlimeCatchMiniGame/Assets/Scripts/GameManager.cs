using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���ھ� ǥ�� �ؽ�Ʈ ������Ʈ ����
    [SerializeField] private Text scoreText;

    [SerializeField] private Text bestScoreText;

    [SerializeField] private int startTime; // ���۽ð� 

    [SerializeField] private Text timerText; // ���� ���� ǥ�� �ؽ�Ʈ ������Ʈ ����
    private int time;

    private void Start()
    {
        //
        bestScoreText.text = PlayerPrefs.GetString("BEST_SCORE", "0");

        StartCoroutine(GameTimerCoroutine());
    }

    private void UpdateBestScore()
    {
        // �� ���� �������� �������� ����
        int bestScore = int.Parse(bestScoreText.text);
        int score = int.Parse(scoreText.text);

        // ���� ������ �ְ� ���� ��
        if (bestScore < score)
        {
            // �ְ� ���� ����
            bestScoreText.text = scoreText.text;
            PlayerPrefs.SetString("BEST_SCORE", scoreText.text);
        }
        // ���� ���ھ ����
        PlayerPrefs.SetString("SCORE", scoreText.text);
        PlayerPrefs.Save();
    }

    private void GameEnd()
    {
        // �� ���� �������� �������� ����
        int bestScore = int.Parse(bestScoreText.text);
        int score = int.Parse(scoreText.text);

        // ���� ������ �ְ� ���� ��
        if(bestScore < score)
        {
            // �ְ� ���� ����
            PlayerPrefs.SetString("BEST_SCORE", scoreText.text);
        }
        // ���� ���ھ ����
        PlayerPrefs.SetString("SCORE", scoreText.text);
        PlayerPrefs.Save();

        // ���� ��������� �̵�
        //SceneManager.LoadScene("EndScene");


    }

    IEnumerator GameTimerCoroutine()
    { 
        time = startTime; // ���� �ð� ����

        while (time > 0) // �ð��� 0�� �ɶ� ���� �ݺ�
        {
            // �ð� ���
            timerText.text = time.ToString();
            // 1�� ����
            yield return new WaitForSeconds(1f);
            // �ð� ����
            time--;
        }
        // ���� �ð� ǥ�� -> 0��
        timerText.text = time.ToString();

        // ���� ����
        GameEnd();
    }

    public void TimeUp(int time)
    {
        // ���� �ؽ�Ʈ�� ǥ�õ� �ð� ���� ����
        int t = this.time;

        // �ð����� ó��
        t += time ;
        // Ÿ�̹� ������Ʈ
        this.time = t;
    }

    public void ScoreUp(int slimeScore)
    {
        // ���� ���ھ� �ؽ�Ʈ�� ���������� ��ȯ
        int score = int.Parse(scoreText.text);
        
        // ���ھ� ���� ����
        score += slimeScore;

        // ���ھ� �������� ���ڿ��� ��ȯ�Ͽ� �ؽ�Ʈ ������Ʈ�� ����
        scoreText.text = score.ToString();
        UpdateBestScore();
    }
}
