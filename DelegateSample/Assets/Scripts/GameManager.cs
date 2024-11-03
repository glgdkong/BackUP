using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �Ͻ����� �̺�Ʈ�� ���� IPause �������̽��� ������ ���ӿ�����Ʈ��
    [SerializeField] private IPause[] pauseObjects;

    private bool isPaused = false;

    private void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Pause");
        pauseObjects = new IPause[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            pauseObjects[i] = objects[i].GetComponent<IPause> ();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();  // �Ͻ� ���� ó�� ���� 
        }
    }


    public void TogglePause()
    { 
        isPaused = !isPaused;

        if (isPaused )
        {
            // �Ͻ� ���� �̺�Ʈ�� ������ ������Ʈ�鿡��
            foreach ( IPause obj in pauseObjects )
            {
                obj.OnPause(); // �Ͻ� ���� �̺�Ʈ �˸��� �߻���
            }
        }
        else 
        {
            // �Ͻ� ���� �̺�Ʈ�� ������ ������Ʈ�鿡��
            foreach (IPause obj in pauseObjects)
            {
                obj.OnResume(); // �Ͻ� ���� �̺�Ʈ �˸��� �߻���
            }
        }
    }
}
