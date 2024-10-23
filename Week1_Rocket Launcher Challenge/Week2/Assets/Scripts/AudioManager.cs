using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource audioSource; // 오디오를 재생할 AudioSource 컴포넌트

    public AudioClip bgmClip; // 배경 음악으로 사용할 오디오 클립

    public override void Awake()
    {
        // 싱글톤 인스턴스를 설정 (Singleton<T>의 Awake 메서드 호출)
        base.Awake();

        // 현재 인스턴스가 이 AudioManager라면 아래 코드 실행
        if (Instance == this)
        {
            // 오디오 재생을 위한 AudioSource 컴포넌트를 추가
            audioSource = gameObject.AddComponent<AudioSource>();

            // BGM을 반복 재생하도록 설정
            audioSource.loop = true;

            // 오디오 볼륨을 20%로 설정
            audioSource.volume = 0.2f;

            // AudioSource에 BGM 오디오 클립 할당
            audioSource.clip = bgmClip;

            // BGM 재생 시작
            audioSource.Play();
        }
    }
}
