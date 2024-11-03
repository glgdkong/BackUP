using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 로또컴포넌트 : MonoBehaviour
{
    public int 게임횟수;
    public int rollTime;
    public string[] lottoRsult;
    public int[] lottoNumList;
    void Start()
    {
        lottoRsult = new string[게임횟수];
        lottoNumList = new int[45];
        // 추첨한 볼 6개 번호값을 저장할 배열 생성
        int[] lottoRandomNum = new int[6];

        // 6개의 로또볼을 추첨함
        /*for (int i = 0; i < lottoRandomNum.Length; i++)
        {
            // 로또볼 추첨
            lottoRandomNum[i] = Random.Range(1, 46);
            // 현재 뽑은 번호와 이전 번호들을 비교해서 같은 값이 뽑혔을 경우 다시 뽑도록 번째를 감소시킴
            for (int j = 0; j < i; j++)
            {
                if (lottoRandomNum[i] == lottoRandomNum[j])
                {
                    i--;
                    break;
                }
            }

        }

        Debug.Log("추첨한 로또볼 목록");
        for (int i = 0; i < lottoRandomNum.Length; i++)
        {
            Debug.Log($"{i + 1}번째 추첨공 번호 : {lottoRandomNum[i]}");
        }*/
        // [과제1]
        // 출력 볼 정보는 하나의 문자열로 출력하시오.
        // * 출력 볼 정보는 낮은 숫자부터 높은 숫자로 정렬하여 출력하시오.
        // 힌트) 버블 정렬 알고리즘을 사용할 것
        // [예시]
        // 게임 횟수 : 100회
        // 1번째 게임: 1 ,5 , 9, 30, 40, 45
        // 2번째 게임 : 7, 11, 27, 34, 36, 42
        // ...
        // 100번째 게임 : 9, 15, 24, 25, 34, 38
        for (int count = 0; count < lottoRsult.Length; count++)
        {
            lottoRsult[count] = $"{count + 1}번 게임 : ";
            for (int i = 0; i < lottoRandomNum.Length; i++)
            {
                // 로또볼 추첨
                lottoRandomNum[i] = Random.Range(1, 46);
                lottoNumList[lottoRandomNum[i] - 1]++;
                // 현재 뽑은 번호와 이전 번호들을 비교해서 같은 값이 뽑혔을 경우 다시 뽑도록 번째를 감소시킴
                for (int j = 0; j < i; j++)
                {
                    if (lottoRandomNum[i] == lottoRandomNum[j])
                    {
                        i--;
                        lottoNumList[lottoRandomNum[i] - 1]--;
                        break;
                    }
                }
            }
            // 앞 번호와 뒷 번호를 비교해서 앞 번호가 클 경우 서로 스왑
            for (int i = 0; i < lottoRandomNum.Length; i++)
            {
                for (int j = 0; j < lottoRandomNum.Length -1; j++)
                {
                    if (lottoRandomNum[j] > lottoRandomNum[j + 1])
                    {
                        int chageNum = lottoRandomNum[j + 1];
                        lottoRandomNum[j + 1] = lottoRandomNum[j];
                        lottoRandomNum[j] = chageNum;
                    }
                }
            }
            for (int i = 0; i < lottoRandomNum.Length; i++)
            {
                lottoRsult[count] += $"{lottoRandomNum[i]}, ";
            }
            Debug.Log(lottoRsult[count]);
        }
        /*for (int i = 0; i < lottoRsult.Length; i++)
        {
            Debug.Log(lottoRsult[i]);
        }*/
        for (int i = 0; i < lottoNumList.Length; i++)
        {
            rollTime += lottoNumList[i];
        }
        // [과제2]
        // 현재 로또볼 추첨 로직을 지정한 게임 횟수만큼 추첨하고 
        // 추첨볼의 번호별로 추첨한 빈도수를 출력하시오.
        // [예시]
        // 추첨 횟수 : 6000회
        // 1번 : 80회
        // 2번 : 10회
        // 3번 : 90회
        // 45번 : 100회
        Debug.Log($"추첨 횟수 : {rollTime}회");
        for (int i = 0; i < lottoNumList.Length; i++)
        {
            Debug.Log($"{i+1}번 : {lottoNumList[i]}");
        }
    }
}
