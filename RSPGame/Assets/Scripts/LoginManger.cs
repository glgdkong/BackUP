using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManger : MonoBehaviour
{
    // �ؽ�Ʈ ����
    [SerializeField] private TextMeshProUGUI[] nicknameTexts;

    // �ؽ�Ʈ ������ ����ƽ ���ڿ�
    [SerializeField] public static string nickname;

    // �α��� ��ư ����
    [SerializeField] private Button logingButton;


    // Start is called before the first frame update
    void Start()
    {
        logingButton.onClick.AddListener(TransGameScene); 
    }

    private void TransGameScene()
    {
        nickname = nicknameTexts[0].text;
        Debug.Log("���� ������ �Ѿ");
    }





}
