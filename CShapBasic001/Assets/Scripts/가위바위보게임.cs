using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 가위바위보게임 : MonoBehaviour
{
    // 1. 컴퓨터 1, 컴퓨터 2의 가위바위보를 입력 받을 변수를 만들어 보세요. (가위, 바위, 보 값은 정수값입니다.)
    public int Computer1RSPNum;
    // 2. 컴퓨터 1, 컴퓨터 2의 가위바위보를 입력 받을 변수를 만들어 보세요. (가위, 바위, 보 값은 정수값입니다.)
    public int Computer2RSPNum; 
    
    


    // Start is called before the first frame update
    void Start()
    {
        // 3. 컴퓨터 1의 가위바위보값을 랜덤하게 뽑아보세요.
        // (가위: 0, 바위: 1, 보: 2)
        Computer1RSPNum = Random.Range(0, 3);
        // 3. 컴퓨터 2의 가위바위보값을 랜덤하게 뽑아보세요.
        Computer2RSPNum = Random.Range(0, 3);

        
        // 5. 컴퓨터 1이 가위를 낸게 맞는지 출력하세요.
        // (예. '컴퓨터 1가 가위를 낸게 true/False 입니다.)
        Debug.Log($"컴퓨터 1({Computer1RSPNum})이 가위를 낸게{Computer1RSPNum == 0}입니다.");

        // 6. 컴퓨터 1이 바위를 낸게 맞는지 출력하세요.
        // (예. '컴퓨터 1가 바위를 낸게 true/False 입니다.)

        Debug.Log($"컴퓨터 1({Computer1RSPNum})가 바위를 낸게 {Computer1RSPNum == 1} 입니다");

        // 7. 컴퓨터 1이 보를 낸게 맞는지 출력하세요.
        // (예. '컴퓨터 1가 보위를 낸게 true/False 입니다.)

        Debug.Log($"컴퓨터 1({Computer1RSPNum})가 보를 낸게 {Computer1RSPNum == 2} 입니다");


        // 8. 컴퓨터 2이 가위를 낸게 맞는지 출력하세요.
        // (예. '컴퓨터 2가 가위를 낸게 true/False 입니다.)
        Debug.Log($"컴퓨터 2({Computer2RSPNum})가 가위를 낸게{Computer2RSPNum == 0}입니다.");

        // 9. 컴퓨터 2이 바위를 낸게 맞는지 출력하세요.
        // (예. '컴퓨터 2가 바위를 낸게 true/False 입니다.)
        Debug.Log($"컴퓨터 2({Computer2RSPNum})가 바위를 낸게{Computer2RSPNum == 1}입니다.");

        // 10. 컴퓨터 2이 보를 낸게 맞는지 출력하세요.
        // (예. '컴퓨터 2가 보위를 낸게 true/False 입니다.)
        Debug.Log($"컴퓨터 2({Computer2RSPNum})가 보를 낸게{Computer2RSPNum == 2}입니다.");


        // (가위: 0, 바위: 1, 보: 2)

        // 컴퓨터1과 컴퓨터2의 가위바위보 판정을 출력하시오.
        // 컴퓨터1이 컴퓨터2를 이긴게 맞는지를 출력하시오.
        // (예. '컴퓨터1이 컴퓨터2를 이긴게 true/false 입니다.')
        // -> 컴퓨터1이 가위를 내고 컴퓨터2가 보를 냈을 때        (Computer1RSPNum == 0 && Computer2RSPNum == 2)  => 첫번째 컴퓨터1의 승리조건
        // -> 컴퓨터1이 바위를 내고 컴퓨터2가 가위를 냈을 때      (Computer1RSPNum == 1 && Computer2RSPNum == 0)  => 두번째 컴퓨터1의 승리조건
        // -> 컴퓨터1이 보를 내고 컴퓨터2가 바위를 냈을 때        (Computer1RSPNum == 2 && Computer2RSPNum == 1)  => 세번째 컴퓨터1의 승리조건
        // ==> 세가지 조건 중에 하나만 성립되면 컴퓨터 1이 승리함    =>
        bool isComputer1Win = (Computer1RSPNum == 0 && Computer2RSPNum == 2) || (Computer1RSPNum == 1 && Computer2RSPNum == 0) || (Computer1RSPNum == 2 && Computer2RSPNum == 1);
        Debug.Log($"컴퓨터1이 컴퓨터2를 이긴게 {isComputer1Win}입니다.");
        

        // 컴퓨터1이 컴퓨터2에게 비긴게 맞는지를 출력하시오.
        // (예. '컴퓨터1이 컴퓨터2에게 비긴게 true/false 입니다.')
        // 컴퓨터1의 가위바위보의 값이랑 컴퓨터2의 가위바위보의 값이랑 같을 때
        //bool isComputer1Draw = (Computer1RSPNum == 0 && Computer2RSPNum == 0) || (Computer1RSPNum == 1 && Computer2RSPNum == 1) || (Computer1RSPNum == 2 && Computer2RSPNum == 2);
        bool isComputer1Draw = Computer1RSPNum == Computer2RSPNum;
        Debug.Log($"컴퓨터1과 컴퓨터2는 비긴게 {isComputer1Draw}입니다.");

        // 컴퓨터1이 컴퓨터2에게 패배한게 맞는지를 출력하시오.
        // (예. '컴퓨터1이 컴퓨터2에게 패배한게 true/false 입니다.')
        //bool isComputer1Lose = (Computer1RSPNum == 2 && Computer2RSPNum == 0) || (Computer1RSPNum == 0 && Computer2RSPNum == 1) || (Computer1RSPNum == 1 && Computer2RSPNum == 2);
        bool isComputer1Lose = !isComputer1Win && !isComputer1Draw;
        Debug.Log($"컴퓨터1이 컴퓨터2에게 패배한게 {isComputer1Lose}입니다.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
