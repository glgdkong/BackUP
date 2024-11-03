using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 체력바 UI 컴포넌트
public class HpBarCharacterUI : MonoBehaviour
{
    // 체력 프로그래스 이미지
    [SerializeField] private Image hpBarProgressImage;

    // 오프셋 위치
    [SerializeField] private Vector3 offset;

    // 체력바 위치 업데이트 (월드위치 -> 스크린(캔버스) 위치로
    public void UpdateUIPosition(Vector3 characterUIPosition)
    {
        transform.position = Camera.main.WorldToScreenPoint(characterUIPosition + offset);
    }

    // 체력바 체력 수치 업데이트
    public void UpdateHpProgress(float fillAmount)
    {
        hpBarProgressImage.fillAmount = fillAmount;
    }

    // 체력바 제거
    public void DestroyUI()
    {
        Destroy(gameObject); 
    }
}
