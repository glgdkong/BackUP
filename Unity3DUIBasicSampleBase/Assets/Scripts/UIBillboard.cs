using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour
{
    // LateUpdate : Update 이벤트 실행후 한번더 렌더링 되기 전에 호출되는 렌더링 주기 관련 이벤트 메소드
    private void LateUpdate()
    {
        // UI 캔버스가 바라보는 방향을 카메라 시선 벡터에 맞춤 => 빌보드
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
