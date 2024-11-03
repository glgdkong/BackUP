using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 음악 플레이어
public class MusicPlayer : MonoBehaviour
{
    // 음악 파일 참조 배열
    [SerializeField] private AudioClip[] musicAudioClips;

    // 음악 재생기 컴포넌트 참조
    [SerializeField] private AudioSource audioSource;

    // 현재 음악 재생중 체크
    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }

    // 음악 재생
    public void Play(int musicIndex)
    {
        audioSource.clip = musicAudioClips[musicIndex];
        audioSource.Play();
    }

    // 음악 재생 중지
    public void Stop()
    {
        // 완전 정지
        audioSource.Stop();  // -> 다시 재생시 처음부터
        // 일시 정지
        //audioSource.Pause(); // -> 다시 재생시 연결해서
    }

    // 음악 볼륨 설정
    public void SetVolume(float vol)
    {
        audioSource.volume = vol;
    }



}
