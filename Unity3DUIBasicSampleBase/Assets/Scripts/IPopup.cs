using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 팝업 인터페이스
public interface IPopup 
{
    // 팝업 실행 결과 확인 이벤트
    public void OnConfirm(bool isSuccess);
    // 팝업 실행 결과 확인 및 데이터 전달 이벤트
    public void OnDataConfirm(object data);
}
