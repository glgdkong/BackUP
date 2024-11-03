using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOverayUIManager : MonoBehaviour
{
    // 체력바 UI 게임오브젝트
    [SerializeField] protected GameObject hpBarUIPrefab;
    // 체력바 관리 UI 컴포넌트
    protected HpBarCharacterUI hpBarCharacterUI;

    private void Start()
    {
        // 체력바 생성
        hpBarCharacterUI =Instantiate(hpBarUIPrefab, GameObject.Find("HpBars").transform).GetComponent<HpBarCharacterUI>();   
    }

    private void LateUpdate()
    {
        // 체력바 위치 업데이트
        hpBarCharacterUI?.UpdateUIPosition(transform.position);
    }

    // 체력바 수치 업데이트
    public void UpdateHpUIProgress(float fillAmount)
    {
        hpBarCharacterUI?.UpdateHpProgress(fillAmount);
    }


    // 체력바 숨김(파괴)
    public void HideHpUI()
    {
        hpBarCharacterUI.DestroyUI();
        hpBarCharacterUI = null;
    }

}
