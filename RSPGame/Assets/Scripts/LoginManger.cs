using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManger : MonoBehaviour
{
    // 텍스트 참조
    [SerializeField] private TextMeshProUGUI[] nicknameTexts;

    // 텍스트 저장할 스태틱 문자열
    [SerializeField] public static string nickname;

    // 로그인 버튼 참조
    [SerializeField] private Button logingButton;


    // Start is called before the first frame update
    void Start()
    {
        logingButton.onClick.AddListener(TransGameScene); 
    }

    private void TransGameScene()
    {
        nickname = nicknameTexts[0].text;
        Debug.Log("다음 씬으로 넘어감");
    }





}
