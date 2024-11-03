using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPopup : MonoBehaviour, IPause
{
    [SerializeField] private GameObject panel;
    public void OnPause()
    {
        Debug.Log("Á¾·á ÆË¾÷ ¿­¸²");
        panel.gameObject.SetActive(true);
    }

    public void OnResume()
    {
        Debug.Log("Á¾·á ÆË¾÷ ´ÝÈû");
        panel.gameObject.SetActive(false);
    }
}
