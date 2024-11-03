using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOverayUIManager : MonoBehaviour
{
    // ü�¹� UI ���ӿ�����Ʈ
    [SerializeField] protected GameObject hpBarUIPrefab;
    // ü�¹� ���� UI ������Ʈ
    protected HpBarCharacterUI hpBarCharacterUI;

    private void Start()
    {
        // ü�¹� ����
        hpBarCharacterUI =Instantiate(hpBarUIPrefab, GameObject.Find("HpBars").transform).GetComponent<HpBarCharacterUI>();   
    }

    private void LateUpdate()
    {
        // ü�¹� ��ġ ������Ʈ
        hpBarCharacterUI?.UpdateUIPosition(transform.position);
    }

    // ü�¹� ��ġ ������Ʈ
    public void UpdateHpUIProgress(float fillAmount)
    {
        hpBarCharacterUI?.UpdateHpProgress(fillAmount);
    }


    // ü�¹� ����(�ı�)
    public void HideHpUI()
    {
        hpBarCharacterUI.DestroyUI();
        hpBarCharacterUI = null;
    }

}
