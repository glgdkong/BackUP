using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IPopup
{
    // �Է� �ؽ�Ʈ �ʵ� ������Ʈ
    [SerializeField] private InputField textInputField;

    // ��� �ؽ�Ʈ ������Ʈ
    [SerializeField] private Text printText;

    // ��Ӵٿ�
    [SerializeField] private Dropdown musicDropDown;

    // ���� ���� �ε���
    public int selectMusicIndex;

    // ���� �����
    [SerializeField] private MusicPlayer musicPlayer;
    // �÷��� ��ư ���ӿ�����Ʈ ����
    [SerializeField] private GameObject playBtnImage;
    // ��ž ��ư ���ӿ�����Ʈ ����
    [SerializeField] private GameObject stopBtnImage;

    // ������ �˾� ������Ʈ ����
    [SerializeField] private AddItemPopup addItemPopup;

    // ������ �� �θ� Transform
    [SerializeField] private Transform cellContentView;

    // ������ �� ������
    [SerializeField] private GameObject cellPrefab;

    // ���� UI ǥ�� �г�
    [SerializeField] private GameObject mainUIPanel;

    // ���� UI �г� �ݱ�
    public void OnCloseMainUIPanelButtonClick()
    {
        mainUIPanel.SetActive(false);
    }
    // ���� UI �г� ����
    public void OnOpenMainUIPanelButtonClick()
    {
        mainUIPanel.SetActive(true);
    }

    // �ؽ�Ʈ ��� ��ư Ŭ��
    public void OnTextPrintButtonClick()
    {
        printText.text = textInputField.text;
    }

    // �ؽ�Ʈ ��� �̹��� Ŭ��
    public void OnTextPrintImageButtonClick()
    {
        printText.text = textInputField.text;
    }

    // Ȱ�� ���� ����(��� �̺�Ʈ)
    public void OnInputEnableToggleCheck(bool isOn)
    {
        textInputField.interactable = isOn;
    }
    // ��Ȱ�� ���� ����(��� �̺�Ʈ)
    public void OnInputDisableToggleCheck(bool isOn)
    {
        textInputField.interactable = !isOn;
    }

    // �ؽ�Ʈ ���� �۾� ���� ��� �̺�Ʈ
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

    // ���� ���� ����(��Ӵٿ� �̺�Ʈ)
    public void OnSelectMusicIndexDropDown(int musicIndex)
    {
        Stop(); // ���� ����� ���� ���� ��� ����
        musicDropDown.value = musicIndex; // 1 �� �׸� ����
    }

    // ���� ���
    private void Play()
    {
        playBtnImage.SetActive(false); // �÷��� ��ư ��Ȱ��ȭ
        stopBtnImage.SetActive(true);   // ���� ��ư Ȱ��ȭ
        musicPlayer.Play(musicDropDown.value); // ���� ���
    }
    // ���� ��� ����
    private void Stop()
    {
        musicPlayer.Stop(); // ���� ����
        playBtnImage.SetActive(true); // �÷��� ��ư Ȱ��ȭ
        stopBtnImage.SetActive(false); // ���� ��ư ��Ȱ��ȭ
    }

    // ���� ��� ��ư Ŭ��(��ư �̺�Ʈ) 
    public void MusicPlayStopButtonClick()
    {
        // �̹� ������ ��� ���̸�
        if(musicPlayer.IsPlaying())
        {
            Stop(); // ����
        }
        else
        {
            Play(); // ���
        }
    }

    // ���� ����(�����̴� �̺�Ʈ)
    public void SetVolumeSlider(float vol)
    {
        // ���� ����
        musicPlayer.SetVolume(vol);
    }

    
    public void OnItemAddButtonClick()
    {
        // ������ �˾��� ������
        addItemPopup.Open(this);
    }

    // �˾� �������̽� �޼ҵ� ����

    public void OnConfirm(bool isSuccess)
    {
        
    }

    // �˾� ������ ���� �ݹ� �޼ҵ�
    // object : C#�� ��� Ÿ���� ���� Ÿ�� ( * ���Ÿ���� object Ÿ������ ��ĳ������ ������)
    // Object : ����Ƽ�� �ֻ��� ���� Ÿ�� ( * Object Ŭ������ ��� ���� �ڽ� Ÿ�Ե鸸 ��ĳ������ ������)
    public void OnDataConfirm(object data)
    {
        if (data == null) return;

        // �ٿ� ĳ������ ���� �����͸� ������ ���� Ÿ������ ����
        ItemData itemData = (ItemData)data;

        Debug.Log($"{itemData.ItemName} �������� �߰���");

        // ������ �� ���ӿ�����Ʈ ����
        GameObject cell = Instantiate(cellPrefab, cellContentView);
        cell.GetComponent<ContentCell>().Init(itemData);
    }

}
