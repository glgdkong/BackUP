using System;

// 색상 종류
[Serializable]
public class ColorType
{
    public enum TYPE { RED, BLUE } // 색상 종류(빨간색, 파란색)

    public TYPE type =TYPE.RED; // 색상 종류 설정 변수
}