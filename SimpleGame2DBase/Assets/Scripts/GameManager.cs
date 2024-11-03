using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ���Ŀ �̵� ������Ʈ�� ����
    [SerializeField] private BlockerCircleMovement[] blockerCircleMovements;

    private int score; // ����
    [SerializeField] private Text scoreText; // ���� ��� �ؽ�Ʈ

    [SerializeField] private float gameReStartDelayTime; // ���� ����� ���� ����

    private float time; // �ð� ���� ����
    [SerializeField]private float inputWaitTime; // ���� �Է� ���� �ð�

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        // ���콺 ���� ��ư�� �����ٸ�
        if (Input.GetMouseButtonDown(0) && time >= inputWaitTime )
        {
            // for (int = 0; i<blockerCircleMovement.Length; i++){blockerMovement.ReverseMove();}
            foreach (BlockerCircleMovement blockerMovement in blockerCircleMovements)
            {
                // ���Ŀ ���� �޼ҵ� ����
                blockerMovement.ReverseMove();
            }
            time = 0;
        }
    }

    public void ScoreUp()
    {
        score++; // ���� ����
        // ���� �ְ� ���� �ҷ�����
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
