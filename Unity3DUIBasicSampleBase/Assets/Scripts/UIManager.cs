using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IPopup
{
    // 입력 텍스트 필드 컴포넌트
    [SerializeField] private InputField textInputField;

    // 출력 텍스트 컴포넌트
    [SerializeField] private Text printText;

    // 드롭다운
    [SerializeField] private Dropdown musicDropDown;

    // 음악 선택 인덱스
    public int selectMusicIndex;

    // 음악 재생기
    [SerializeField] private MusicPlayer musicPlayer;
    // 플레이 버튼 게임오브젝트 참조
    [SerializeField] private GameObject playBtnImage;
    // 스탑 버튼 게임오브젝트 참조
    [SerializeField] private GameObject stopBtnImage;

    // 아이템 팝업 컴포넌트 참조
    [SerializeField] private AddItemPopup addItemPopup;

    // 콘텐츠 셀 부모 Transform
    [SerializeField] private Transform cellContentView;

    // 콘텐츠 셀 프리펩
    [SerializeField] private GameObject cellPrefab;

    // 메인 UI 표시 패널
    [SerializeField] private GameObject mainUIPanel;

    // 메인 UI 패널 닫기
    public void OnCloseMainUIPanelButtonClick()
    {
        mainUIPanel.SetActive(false);
    }
    // 메인 UI 패널 열기
    public void OnOpenMainUIPanelButtonClick()
    {
        mainUIPanel.SetActive(true);
    }

    // 텍스트 출력 버튼 클릭
    public void OnTextPrintButtonClick()
    {
        printText.text = textInputField.text;
    }

    // 텍스트 출력 이미지 클릭
    public void OnTextPrintImageButtonClick()
    {
        printText.text = textInputField.text;
    }

    // 활성 선택 라디오(토글 이벤트)
    public void OnInputEnableToggleCheck(bool isOn)
    {
        textInputField.interactable = isOn;
    }
    // 비활성 선택 라디오(토글 이벤트)
    public void OnInputDisableToggleCheck(bool isOn)
    {
        textInputField.interactable = !isOn;
    }

    // 텍스트 굵은 글씨 적용 토글 이벤트
    public void OnTextBoldToggleCheck(bool isOn)
    {
        if (isOn)
        {
            if (printText.fontStyle == FontStyle.Italic) { printText.fontStyle = FontStyle.BoldAndItalic; }
            else { printText.fontStyle = FontStyle.Bold; }
        }
        else
        {
            if(printText.fontStyle == FontStyle.BoldAndItalic)
            {
                printText.fontStyle = FontStyle.Italic;
            }
            else
            {
                printText.fontStyle = FontStyle.Normal;
            }
        }
    }
    public void OnTextItalicToggleCheck(bool isOn)
    {
        if (isOn)
        {
            if (printText.fontStyle == FontStyle.Bold) { printText.fontStyle = FontStyle.BoldAndItalic; }
            else { printText.fontStyle = FontStyle.Italic; }
        }
        else
        {
            if(printText.fontStyle == FontStyle.BoldAndItalic)
            {
                printText.fontStyle = FontStyle.Bold;
            }
            else
            {
                printText.fontStyle = FontStyle.Normal;
            }
        }
    }

    // 음악 선택 적용(드롭다운 이벤트)
    public void OnSelectMusicIndexDropDown(int musicIndex)
    {
        Stop(); // 음악 변경시 이전 음악 재생 중지
        musicDropDown.value = musicIndex; // 1 번 항목 선택
    }

    // 음악 재생
    private void Play()
    {
        playBtnImage.SetActive(false); // 플레이 버튼 비활성화
        stopBtnImage.SetActive(true);   // 정지 버튼 활성화
        musicPlayer.Play(musicDropDown.value); // 음악 재생
    }
    // 음악 재생 중지
    private void Stop()
    {
        musicPlayer.Stop(); // 음악 정지
        playBtnImage.SetActive(true); // 플레이 버튼 활성화
        stopBtnImage.SetActive(false); // 정지 버튼 비활성화
    }

    // 음악 재생 버튼 클릭(버튼 이벤트) 
    public void MusicPlayStopButtonClick()
    {
        // 이미 음악이 재생 중이면
        if(musicPlayer.IsPlaying())
        {
            Stop(); // 중지
        }
        else
        {
            Play(); // 재생
        }
    }

    // 볼륨 조절(슬라이더 이벤트)
    public void SetVolumeSlider(float vol)
    {
        // 볼륨 설정
        musicPlayer.SetVolume(vol);
    }

    
    public void OnItemAddButtonClick()
    {
        // 아이템 팝업을 실행함
        addItemPopup.Open(this);
    }

    // 팝업 인터페이스 메소드 구현

    public void OnConfirm(bool isSuccess)
    {
        
    }

    // 팝업 데이터 응답 콜백 메소드
    // object : C#의 모든 타입의 기초 타입 ( * 모든타입은 object 타입으로 업캐스팅이 가능함)
    // Object : 유니티의 최상위 기초 타입 ( * Object 클래스를 상속 받은 자식 타입들만 업캐스팅이 가능함)
    public void OnDataConfirm(object data)
    {
        if (data == null) return;

        // 다운 캐스팅을 통해 데이터를 아이템 정보 타입으로 변경
        ItemData itemData = (ItemData)data;

        Debug.Log($"{itemData.ItemName} 아이템이 추가됨");

        // 아이템 셀 게임오브젝트 생성
        GameObject cell = Instantiate(cellPrefab, cellContentView);
        cell.GetComponent<ContentCell>().Init(itemData);
    }

}
