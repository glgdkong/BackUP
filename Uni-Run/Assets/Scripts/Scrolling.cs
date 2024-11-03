using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float scrollingSpeed = 10f;
    GameManager gameManeger;
    private void Start()
    {
        // FindObjectOfType 등의 Find류 함수는 하이어라키에 올려진 모든 게임오브젝트를 일일이 검사 합니다.
        // 그래서 비용이 비싸다.(메모리 많이 소모함)
        gameManeger = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        // Translate 전환
        // 게임에서 무언가를 이동 시킬 때 꼭 곱해줘야하는 것이 있습니다.
        // Time.deltaTime 을 곱하면 속도가 1이된다.
        // 왼쪽으로 초당 10 만큼 움직이는 코드
        if(!gameManeger.isGameover)
        { transform.Translate((Vector2)Vector3.left * scrollingSpeed * Time.deltaTime); }

    }
}
