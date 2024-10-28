using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource audioSource; // ������� ����� AudioSource ������Ʈ

    public AudioClip bgmClip; // ��� �������� ����� ����� Ŭ��

    public override void Awake()
    {
        // �̱��� �ν��Ͻ��� ���� (Singleton<T>�� Awake �޼��� ȣ��)
        base.Awake();

        // ���� �ν��Ͻ��� �� AudioManager��� �Ʒ� �ڵ� ����
        if (Instance == this)
        {
            // ����� ����� ���� AudioSource ������Ʈ�� �߰�
            audioSource = gameObject.AddComponent<AudioSource>();

            // BGM�� �ݺ� ����ϵ��� ����
            audioSource.loop = true;

            // ����� ������ 20%�� ����
            audioSource.volume = 0.2f;

            // AudioSource�� BGM ����� Ŭ�� �Ҵ�
            audioSource.clip = bgmClip;

            // BGM ��� ����
            audioSource.Play();
        }
    }
}
