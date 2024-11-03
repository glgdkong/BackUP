using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // ������ ���¿� ����
    public bool isGameover = false;
    public TextMeshProUGUI[] tmpScore;
    public GameObject gameoverUI;

    private int score = 0;

    private void Update()
    {
        // ���� �����
        // ���� ��������, �����̽�Ű�� ��������? �˻�
        if (isGameover && Input.GetKeyDown(KeyCode.Space))
        {
            // ���� �ҷ����� ������ ����� �ȴ�.
            // ���� �ҷ����� �Լ� LoadScene(), �Ķ���ͷ� ���ڿ� Ȥ�� ������ �ѱ� �� �ֽ��ϴ�.
            // ���ڿ��� ���� ���� �̸�, ������ ���� ���� �ε���
            //SceneManager.LoadScene("Uni Run");

            // ���� Ȱ��ȭ �� ���� �̸��� ������.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // ���� ����

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
        tmpScore[1].text = "�ְ� ���� : " + PlayerPrefs.GetInt("BestScoer").ToString();
        /*for (int i = 0; i < scrollings.Length; i++)
        {
            scrollings[i].scrollingSpeed = 0;
        }*/
    }

    // ���� �߰� 
    public void AddScore(int newScore)
    {
        // ���ӿ����� �ƴѵ��ȿ��� ������ �߰��ϵ��� ��.
        if (!isGameover)
        {
            score += newScore;
            tmpScore[0].text = "���� : " + score;
        }
    }

}
