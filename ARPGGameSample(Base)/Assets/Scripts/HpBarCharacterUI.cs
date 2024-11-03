using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ü�¹� UI ������Ʈ
public class HpBarCharacterUI : MonoBehaviour
{
    // ü�� ���α׷��� �̹���
    [SerializeField] private Image hpBarProgressImage;

    // ������ ��ġ
    [SerializeField] private Vector3 offset;

    // ü�¹� ��ġ ������Ʈ (������ġ -> ��ũ��(ĵ����) ��ġ��
    public void UpdateUIPosition(Vector3 characterUIPosition)
    {
        transform.position = Camera.main.WorldToScreenPoint(characterUIPosition + offset);
    }

    // ü�¹� ü�� ��ġ ������Ʈ
    public void UpdateHpProgress(float fillAmount)
    {
        hpBarProgressImage.fillAmount = fillAmount;
    }

    // ü�¹� ����
    public void DestroyUI()
    {
        Destroy(gameObject); 
    }
}
