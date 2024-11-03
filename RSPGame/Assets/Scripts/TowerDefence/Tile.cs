using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // 현재 타일에 타워가 설치되어있는지?
    private bool isBuilted;
    public bool IsBuilted { get => isBuilted; set => isBuilted = value; }

    // 변수는 비공개, 프로퍼티 공개
}
