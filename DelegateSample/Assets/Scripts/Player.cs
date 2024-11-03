using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPause
{
    private bool isRotating = true;
    [SerializeField] private float rotateSpeed;
    void Update()
    {
        if (!isRotating) return;


        // 플레이어의 동작 코드
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    public void OnPause()
    {
        Debug.Log("회전 동작을 멈춤");
        isRotating = false;
    }

    public void OnResume()
    {
        Debug.Log("회전 동작을 다시 수행");
        isRotating = true;
    }
}
