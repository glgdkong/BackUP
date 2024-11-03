using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// 로또 번호 추첨기 만들기.
// 1. A와 B상자 2개가 존재함.
// 2. A상자에는 1부터 45의 숫자가 적힌 공 45개가 들어있음.
// 3. A상자에서 랜덤으로 공 하나를 뽑아서 B상자에 옮김.
// 4. 3번 행위를 총 여섯번 반복하여 B상자에 총 여섯 개의 공이 담겨야 함.
// 5. 여섯개의 당첨 숫자를 오름차순으로 정렬
// 6. 각 숫자는 하나씩만 존재하므로 중복된 번호가 있어서는 안 됨.

// 로또 : 1~ 45의 숫자 중 여섯 개의 랜덤한 번호를 추첨하는 것.
// 번호 추첨기 코드를 완성하면 해당 코드가 스페이스바를 눌렀을 때마다 동작하도록 수정

// 이번주 로또 결과 (21, 33, 35, 38, 42, 44,)
// 를 아래 코드를 사용해서 같은 값이 나오도록 반복 코드 작성 그리고 시행 횃수로 확률 구하는것

// 455057

public class LotteryManager : MonoBehaviour
{
    // 당첨 공의 색상 정의

    public Color[] colorsOfLottery;
    [SerializeField]
    private Image[] ballImage;
    [SerializeField]
    private TextMeshProUGUI[] tmpNumber;

    // 노랑 파랑 빨강 회색 초록
    // 1 ~ 10 / 11 ~ 20/ 21 ~ 30/ 31 ~  40 / 41 ~ 45 


    // 1.
    private List<int> lottoNumberBoxA = new List<int>();
    private List<int> lottoNumberBoxB = new List<int>();

    // 상수선언(프로그래밍 하는 동안 변치 않는 수)
    // 상수의 명명규칙은 따로 없으므로 개인의 취향이다
    // 상수는 처음 초기화한 값에서 어떠한 방법으로도 값을 변경할 수 없다.
    private const int Max_Ball_Count = 45;
    private const int Lottery_Count = 6;


    public int lotteryNum;
    public bool isLottoEquals;
    // Start is called before the first frame update
    void Start()
    {

        isLottoEquals = false;
        //LotteryRepeat();
        //loasdfsa();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.F1) && !isLottoEquals)
        {
            LotteryRepeat();
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Lottery();
        }
    }

    private void Lottery()
    {
        LottoBoxClear();
        LottoNumberBoxAReset();
        LotteryAtoB();
        PrintLotto();
    }
    // 추첨할 로또 번호를 재설정
    private void LottoNumberBoxAReset()
    {
        // 2.
        for (int i = 1; i <= Max_Ball_Count; i++)
        {
            lottoNumberBoxA.Add(i);
        }
    }
    // 랜덤한 수를 추첨
    private void LotteryAtoB()
    {
        // 4.
        for (int i = 0; i < Lottery_Count; i++)
        {
            // 3.
            int index = Random.Range(0, lottoNumberBoxA.Count);
            lottoNumberBoxB.Add(lottoNumberBoxA[index]);
            lottoNumberBoxA.RemoveAt(index);
        }
        lottoNumberBoxB.Sort(); // 6.
    }
    // 추첨한 로또번호를 화면에 표시
    private void PrintLotto()
    {
        for (int i = 0; i < Lottery_Count; i++)
        {
            /*if (lottoNumberBoxB[i] < 11)
            {
                ballImage[i].color = colorsOfLottery[0];
                tmpNumber[i].text = lottoNumberBoxB[i].ToString();
            }
            else if (lottoNumberBoxB[i] < 21)
            {
                ballImage[i].color = colorsOfLottery[1];
                tmpNumber[i].text = lottoNumberBoxB[i].ToString();

            }
            else if (lottoNumberBoxB[i] < 31)
            {
                ballImage[i].color = colorsOfLottery[2];
                tmpNumber[i].text = lottoNumberBoxB[i].ToString();
            }
            else if (lottoNumberBoxB[i] < 41)
            {
                ballImage[i].color = colorsOfLottery[3];
                tmpNumber[i].text = lottoNumberBoxB[i].ToString();
            }
            else
            {
                ballImage[i].color = colorsOfLottery[4];
                tmpNumber[i].text = lottoNumberBoxB[i].ToString();
            }*/
            ballImage[i].color = GetColor(lottoNumberBoxB[i]);
            tmpNumber[i].text = lottoNumberBoxB[i].ToString();
        }
        string lottoResult = "로또 결과표 : ";
        string lottoString = string.Join(", ", lottoNumberBoxB);
        Debug.Log(lottoResult + lottoString);
    }
    // 추첨한 인수들을 제거
    private void LottoBoxClear()
    {
        lottoNumberBoxA.Clear();
        lottoNumberBoxB.Clear();
    }
    // (21, 33, 35, 38, 42, 44,)
    private void LotteryRepeat()
    {
        LottoBoxClear();
        LottoNumberBoxAReset();
        /*lottoNumberBoxA.Add(21);
        lottoNumberBoxA.Add(33);
        lottoNumberBoxA.Add(35);
        lottoNumberBoxA.Add(38);
        lottoNumberBoxA.Add(42);
        lottoNumberBoxA.Add(44);*/
        LotteryAtoB();
        if ((lottoNumberBoxB[0] == 21 && lottoNumberBoxB[1] == 33 && lottoNumberBoxB[2] == 35 && lottoNumberBoxB[3] == 38 && lottoNumberBoxB[4] == 42 && lottoNumberBoxB[5] == 44))
        {
            PrintLotto();
            Debug.Log("로또 결과값 일치! 반복을 종료합니다.");
            Debug.Log($"시행 횟수 : {++lotteryNum}");
            isLottoEquals = true;
            //break;
        }
        else
        {
            PrintLotto();
            Debug.Log("로또 결과값 불일치 로또를 재추첨합니다.");
            Debug.Log($"시행 횟수 : {++lotteryNum}");
        }

    }

    // 리턴 타입이 색상인 함수 작성
    // 색상이 결정되는 것이 뭔가
    // 당첨 번호의 범위
    private Color GetColor(int number)
    {
        // 색상 임시변수 작성
        // 지역 변수는 초기화를 해야 한다
        // 임의로 일단 흰색으로 초기화 한다.
        Color temp = Color.white;

        if (number < 11)
        {
            temp = colorsOfLottery[0];
        }
        else if (number < 21)
        {
            temp = colorsOfLottery[1];
        }
        else if (number < 31)
        {
            temp = colorsOfLottery[2];
        }
        else if (number < 41)
        {
            temp = colorsOfLottery[3];
        }
        else
        {
            temp = colorsOfLottery[4];
        }
        return temp;
    }
}
