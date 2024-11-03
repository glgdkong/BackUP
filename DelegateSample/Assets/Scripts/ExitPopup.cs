using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPopup : MonoBehaviour, IPause
{
    [SerializeField] private GameObject panel;
    public void OnPause()
    {
        Debug.Log("���� �˾� ����");
        panel.gameObject.SetActive(true);
    }

    public void OnResume()
    {
        Debug.Log("���� �˾� ����");
        panel.gameObject.SetActive(false);
    }
}
