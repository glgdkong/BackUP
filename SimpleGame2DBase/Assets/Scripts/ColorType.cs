using System;

// ���� ����
[Serializable]
public class ColorType
{
    public enum TYPE { RED, BLUE } // ���� ����(������, �Ķ���)

    public TYPE type =TYPE.RED; // ���� ���� ���� ����
}