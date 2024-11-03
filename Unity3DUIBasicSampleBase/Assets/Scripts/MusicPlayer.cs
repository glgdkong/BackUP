using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �÷��̾�
public class MusicPlayer : MonoBehaviour
{
    // ���� ���� ���� �迭
    [SerializeField] private AudioClip[] musicAudioClips;

    // ���� ����� ������Ʈ ����
    [SerializeField] private AudioSource audioSource;

    // ���� ���� ����� üũ
    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }

    // ���� ���
    public void Play(int musicIndex)
    {
        audioSource.clip = musicAudioClips[musicIndex];
        audioSource.Play();
    }

    // ���� ��� ����
    public void Stop()
    {
        // ���� ����
        audioSource.Stop();  // -> �ٽ� ����� ó������
        // �Ͻ� ����
        //audioSource.Pause(); // -> �ٽ� ����� �����ؼ�
    }

    // ���� ���� ����
    public void SetVolume(float vol)
    {
        audioSource.volume = vol;
    }



}
