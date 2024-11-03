using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 슬라임 흭득 처리 컴포넌트
public class PickUpSlime : MonoBehaviour
{
    // 게임 매니저 컴포넌트 참조 변수
    [SerializeField] private GameManager gameManager;

    // 슬라임 흭득 이펙트 프리펩
    [SerializeField] private GameObject pickUpEffectPrefab;

    // 슬라임 흭득 사운드 재생기(컴포넌트) 참조
    [SerializeField] private AudioSource pickUpAudioSource;

    // Trigger가 활성화된 콜라이더와 충돌 됨(유니티 이벤트 메소드)
    private void OnTriggerEnter(Collider collider)
    {
        // 흭득한(충돌한) 게임오브젝트의 태그가 Slime이면
        if(collider.tag.Equals("Slime"))
        {
            // 오디오 재생기 실행
            pickUpAudioSource.Play();

            // 슬라임 흭득 이펙트 생성
            Instantiate(pickUpEffectPrefab, collider.transform.position, Quaternion.identity);
            
            // 충돌한 슬라임의 정보 컴포넌트 참조
            SlimeStat slimeStat = collider.GetComponent<SlimeStat>();

            // 흭득한 슬라임의 드랍할 아이템 컴포넌트 참조
            DropItem dropItem = collider.GetComponent<DropItem>();

            // 아이템 떨굼 컴포넌트가 존재할 때만
            if (dropItem != null) 
            {
                dropItem.Drop(); // 아이템 떨굼처리
            }

            // 흭득한 슬라임의 점수를 게임 점수로 출력함
            gameManager.ScoreUp(slimeStat.Score);

            // 흭득한 슬라임 게임 오브젝트 파괴
            Destroy(collider.gameObject);
        }
    }
}
