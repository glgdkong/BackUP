using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 일시정지 이벤트를 받을 IPause 인터페이스를 구현한 게임오브젝트들
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
            TogglePause();  // 일시 정지 처리 반전 
        }
    }


    public void TogglePause()
    { 
        isPaused = !isPaused;

        if (isPaused )
        {
            // 일시 정지 이벤트를 구현한 오브젝트들에게
            foreach ( IPause obj in pauseObjects )
            {
                obj.OnPause(); // 일시 정지 이벤트 알림을 발생함
            }
        }
        else 
        {
            // 일시 정지 이벤트를 구현한 오브젝트들에게
            foreach (IPause obj in pauseObjects)
            {
                obj.OnResume(); // 일시 해제 이벤트 알림을 발생함
            }
        }
    }
}
