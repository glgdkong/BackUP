using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SwitchCaseGrammar : MonoBehaviour
{
    // switch ~ case ��
    // switch : �б��ϴ�, case : ���.
    // ��쿡 ���� �б��ϴ� �ڵ�

    private int inputNumber;
    private string myName;
    private string weather;

    void Start()
    {
        // inputNumber�� ����� ���� 100������� case 100������ ������ �ϴµ�
        // ȿ�������� �ʴ�.
        // ����� ���� ���� �ʰ� ��Ȯ�ϰ� ������ ���� �� ����Ѵ�.
        switch (inputNumber)
        {
            case 0:
                Debug.Log("0");
                break; // break; : switch ���� ������.

            case 1:
                Debug.Log("1");
                break;
                    
            case 2:
                Debug.Log("2");
                break;
                    
            case 3:
                Debug.Log("3");
                break;
                    
            case  4:
                Debug.Log("4");
                break;

            default:
                Debug.Log("0 ~ 4 �� �ƴ� ��");
                break;
        }
        switch (myName)
        {
            case "��ö��":
                Debug.Log("������� �̸��Դϴ�");
                break;
            case "������":
                Debug.Log("���� �л��� �̸��Դϴ�");
                break;
            case "���ÿ�":
                Debug.Log("�ÿ� �л��� �̸��Դϴ�");
                break;
            default:
                Debug.Log("��ö��, ����, �ÿ� �� ������ �̸��� �ƴմϴ�");
                break;
        }
        switch (weather)
        {
            case "��":
            case "��":
                Debug.Log($"������ ������ {weather}��(��) ����ǹǷ� ����� ì��� ���� ��õ�մϴ�");
                break;
            case "��ǳ":
                Debug.Log($"������ ������ {weather}��(��) ����ǹǷ� ������ �������� ��õ�մϴ�");
                break;
            case "����":
                Debug.Log($"������ ������ {weather}��(��) ����ǹǷ� ������ �������� ��õ�մϴ�");
                break;
            case "����":
                Debug.Log($"������ ������ {weather}��(��) ����ǹǷ� ������ �������� ��õ�մϴ�");
                break;
            case "Ȳ��":
                Debug.Log($"������ ������ {weather}��(��) ����ǹǷ� ������ �������� ��õ�մϴ�");
                break;
        }

    }

}
