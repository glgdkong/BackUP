using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItemPopup : MonoBehaviour
{
    // 타입 배열
    [SerializeField] private string[] types = { "A", "B", "C" };
    // 선택 타입 인덱스
    private int typeIndex;

    // 아이템 이름 입력 필드
    [SerializeField] private InputField inputItemName;
    // 아이템 가격 입력 필드
    [SerializeField] private InputField inputItemPrice;

    // 로그 출력 텍스트
    [SerializeField] private Text logText;

    // 로그 출력 시간
    [SerializeField] private float logPrintTime;

    // 타입 선택 드롭다운
    [SerializeField] private Dropdown typeSelectDropDown;

    private IPopup callback; // 팝업 콜백 인터페이스 참조

    private Coroutine coroutine; // 로그출력 코루틴 참조

    // 타입 선택 드롭다운 이벤트(드롭다운)
    public void OnTypeCheckDropDown(int selectType)
    {
        typeIndex = selectType;
    }
    // 팝업 실행
    public void Open(IPopup callback)
    {
        this.callback = callback;


        gameObject.SetActive(true);
        logText.text = "";

        // 팝업 UI 초기화
        typeIndex = 0;
        typeSelectDropDown.value = typeIndex;
        inputItemName.text = "";
        inputItemPrice.text = "";
    }

    // 아이템 정보 추가하기 버튼 클릭 (버튼)
    public void OnAddButtonClick()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine); // 코루틴 참조를 통한 코루틴 종료
            coroutine = null;
        }
        //StopCoroutine("LogPrintingCoroutine");

        // 무결성 체크
        if (inputItemName.text.Trim().Length <= 0)
        {
            //coroutine = StartCoroutine(LogPrintingCoroutine("아이템 이름을 입력하세요."));
            coroutine = StartCoroutine("LogPrintingCoroutine", "아이템 이름을 입력하세요.");
            return;
        }
        if (inputItemPrice.text.Trim().Length <= 0)
        {
            coroutine = StartCoroutine("LogPrintingCoroutine", "아이템 가격을 입력하세요");
            return;
        }

        string strPrice = inputItemPrice.text.Trim();
        if (!int.TryParse(strPrice, out int result))
        {
            coroutine = StartCoroutine("LogPrintingCoroutine", "아이템 가격은 숫자만 가능합니다.");
            return;
        }

        // 아이템 정보 객체 생성
        ItemData itemData = new ItemData(types[typeIndex], inputItemName.text, inputItemPrice.text);

        // 아이템 정보 추가 완료 콜백 메소드 호출
        callback.OnDataConfirm(itemData);

        // 팝업 비활성화
        gameObject.SetActive(false);

    }

    // 로그 메시지 일정 시간 출력
    IEnumerator LogPrintingCoroutine(string logMessage)
    {
        logText.text = logMessage;
        yield return new WaitForSeconds(logPrintTime);

        logText.text = "";
    }

    // 팝업 닫기 버튼 클릭
    public void OnCloseButtonClick()
    {
        callback.OnDataConfirm(null);
        gameObject.SetActive(false);
    }
}
