using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ControlBox : MonoBehaviour
{
    // 컨트롤 박스 구동 메시지
    [SerializeField] protected string massage;
    // 메시지 
    [SerializeField] protected Text infoText;

    //
    protected void Start()
    {
        infoText.gameObject.SetActive(false);
        infoText.text = massage;
    }

    // 컨트롤 박스 사용
    public abstract void Use();

    // 플레이어가 컨트롤 박스 제어 영역안에 들어오면
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            // 구동 메시지 출력
            infoText.gameObject.SetActive(true);
        }
    }

    // 플레이어가 컨트롤 박즈 제어 영역 안에서 나가면
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            // 구동 메시지 출력 해제
            infoText.gameObject.SetActive(false);
        }
    }
}
