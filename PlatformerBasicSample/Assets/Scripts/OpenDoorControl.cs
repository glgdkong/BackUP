using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 문열기용 컨트롤 박스
public class OpenDoorControl : ControlBox
{
    // 도어 게임오브젝트
    [SerializeField] private GameObject door;

    // 문열기 컨트롤 박스를 사용함
    public override void Use()
    {
        door.SetActive(false);
    }
}
