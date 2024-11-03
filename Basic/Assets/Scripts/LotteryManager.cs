using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// �ζ� ��ȣ ��÷�� �����.
// 1. A�� B���� 2���� ������.
// 2. A���ڿ��� 1���� 45�� ���ڰ� ���� �� 45���� �������.
// 3. A���ڿ��� �������� �� �ϳ��� �̾Ƽ� B���ڿ� �ű�.
// 4. 3�� ������ �� ������ �ݺ��Ͽ� B���ڿ� �� ���� ���� ���� ��ܾ� ��.
// 5. �������� ��÷ ���ڸ� ������������ ����
// 6. �� ���ڴ� �ϳ����� �����ϹǷ� �ߺ��� ��ȣ�� �־�� �� ��.

// �ζ� : 1~ 45�� ���� �� ���� ���� ������ ��ȣ�� ��÷�ϴ� ��.
// ��ȣ ��÷�� �ڵ带 �ϼ��ϸ� �ش� �ڵ尡 �����̽��ٸ� ������ ������ �����ϵ��� ����

// �̹��� �ζ� ��� (21, 33, 35, 38, 42, 44,)
// �� �Ʒ� �ڵ带 ����ؼ� ���� ���� �������� �ݺ� �ڵ� �ۼ� �׸��� ���� ȶ���� Ȯ�� ���ϴ°�

// 455057

public class LotteryManager : MonoBehaviour
{
    // ��÷ ���� ���� ����

    public Color[] colorsOfLottery;
    [SerializeField]
    private Image[] ballImage;
    [SerializeField]
    private TextMeshProUGUI[] tmpNumber;

    // ��� �Ķ� ���� ȸ�� �ʷ�
    // 1 ~ 10 / 11 ~ 20/ 21 ~ 30/ 31 ~  40 / 41 ~ 45 


    // 1.
    private List<int> lottoNumberBoxA = new List<int>();
    private List<int> lottoNumberBoxB = new List<int>();

    // �������(���α׷��� �ϴ� ���� ��ġ �ʴ� ��)
    // ����� ����Ģ�� ���� �����Ƿ� ������ �����̴�
    // ����� ó�� �ʱ�ȭ�� ������ ��� ������ε� ���� ������ �� ����.
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
    // ��÷�� �ζ� ��ȣ�� �缳��
    private void LottoNumberBoxAReset()
    {
        // 2.
        for (int i = 1; i <= Max_Ball_Count; i++)
        {
            lottoNumberBoxA.Add(i);
        }
    }
    // ������ ���� ��÷
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
    // ��÷�� �ζǹ�ȣ�� ȭ�鿡 ǥ��
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
        string lottoResult = "�ζ� ���ǥ : ";
        string lottoString = string.Join(", ", lottoNumberBoxB);
        Debug.Log(lottoResult + lottoString);
    }
    // ��÷�� �μ����� ����
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
            Debug.Log("�ζ� ����� ��ġ! �ݺ��� �����մϴ�.");
            Debug.Log($"���� Ƚ�� : {++lotteryNum}");
            isLottoEquals = true;
            //break;
        }
        else
        {
            PrintLotto();
            Debug.Log("�ζ� ����� ����ġ �ζǸ� ����÷�մϴ�.");
            Debug.Log($"���� Ƚ�� : {++lotteryNum}");
        }

    }

    // ���� Ÿ���� ������ �Լ� �ۼ�
    // ������ �����Ǵ� ���� ����
    // ��÷ ��ȣ�� ����
    private Color GetColor(int number)
    {
        // ���� �ӽú��� �ۼ�
        // ���� ������ �ʱ�ȭ�� �ؾ� �Ѵ�
        // ���Ƿ� �ϴ� ������� �ʱ�ȭ �Ѵ�.
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
