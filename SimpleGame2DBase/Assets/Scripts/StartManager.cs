using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public AudioClip clickSound;

    public Text bestScoreText;

	private void Start()
	{
        int bestScore = PlayerPrefs.GetInt("BEST", 0);

        string bestScoreTag = $"<color='#75BCFF'>BEST : </color> <color='white'>{bestScore}</color>";
        bestScoreText.text = bestScoreTag;
	}

	public void OnStartButtonClick()
    {
        AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);

        StartCoroutine("GameStartCoroutine");
    }

    IEnumerator GameStartCoroutine()
    {
        yield return new WaitForSeconds(1f);

		SceneManager.LoadScene("GameScene");
	}
}
