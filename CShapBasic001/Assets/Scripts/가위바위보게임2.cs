using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 가위바위보게임2 : MonoBehaviour
{
    // 0: 가위, 1: 바위, 2: 보
    string[] RSP = new string[3];


    // Start is called before the first frame update
    void Start()
    {
        int com1RSP = Random.Range(0, RSP.Length);
        int com2RSP = Random.Range(0, RSP.Length);
        RSPValue(com1RSP, com2RSP);
        bool isDraw = RSP[com1RSP] == RSP[com2RSP];
        bool isWin  = RSP[com1RSP] == RSP[0] && RSP[com2RSP] == RSP[1] ||
                      RSP[com1RSP] == RSP[1] && RSP[com2RSP] == RSP[2] ||
                      RSP[com1RSP] == RSP[2] && RSP[com2RSP] == RSP[0];
        RSPResult(isDraw, isWin);



        /*      
        if (com1RSP == 0)
        {
            Debug.Log("컴퓨터 1이 가위를 냈습니다.");
        }
        else if (com1RSP == 1)
        {
            Debug.Log("컴퓨터 1이 바위를 냈습니다.");
        }
        else
        {
            Debug.Log("컴퓨터 1이 보를 냈습니다.");
        }
        // 4. 컴퓨터 2가 낸 가위바위보를 출력하시오.
        // 예) 컴퓨터2가 가위를 냈습니다.
        if (com2RSP == 0)
        {
            Debug.Log("컴퓨터 2가 가위를 냈습니다.");
        }
        else if (com2RSP == 1)
        {
            Debug.Log("컴퓨터 2가 바위를 냈습니다.");
        }
        else
        {
            Debug.Log("컴퓨터 2가 보를 냈습니다.");
        }

        // 5. 컴퓨터 1과 컴퓨터 2의 가위바위보의 판정 결과를 출력하시오. (기준: 컴퓨터1)
        // 예) 컴퓨터 1이 패배했습니다.

        if (com1RSP == com2RSP)
        {
            Debug.Log("컴퓨터1 과 컴퓨터 2가 무승부 했습니다.");
        }
        else if (com1RSP == 0 && com2RSP == 1 || com1RSP == 1 && com2RSP == 2 || com1RSP == 2 && com2RSP == 0)
        {
            Debug.Log("컴퓨터1이 패배했습니다.");
        }
        else
        {
            Debug.Log("컴퓨터1이 승리했습니다.");
        } /**/


    }


    public void RSPResult(bool isDraw, bool isWin)
    {
        if (isDraw)
        {
            Debug.Log("컴퓨터1 과 컴퓨터 2가 무승부 했습니다.");
        }
        else if (isWin)
        {
            Debug.Log("컴퓨터1이 패배했습니다.");
        }
        else
        {
            Debug.Log("컴퓨터1이 승리했습니다.");
        }
    }
    
    public void RSPValue(int com1RSP, int com2RSP)
    {

        RSP[0] = "가위";
        RSP[1] = "바위";
        RSP[2] = "보";

        string 메시지 = "컴퓨터 1이 ";
        메시지 += RSP[com1RSP];
        메시지 += "를 냈습니다.";
        Debug.Log(메시지);

        메시지 = "컴퓨터 2이 ";
        메시지 += RSP[com2RSP];
        메시지 += "를 냈습니다.";
        Debug.Log(메시지);

        
    }
}
