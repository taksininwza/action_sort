using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [System.Serializable]
    public class MyAudio
    {
        public AudioClip audioClip;
        [Range(0f, 1f)] public float volumn;
    }

    [SerializeField] MyAudio shootingAudioClip;
    [SerializeField] MyAudio shootingEnemyAudioClip;

    [SerializeField] MyAudio explosionAudioClip;
    [SerializeField] MyAudio explosionEnemyAudioClip;

    [SerializeField] MyAudio hitAudioClip;
    public static AudioPlayer Instance { get; private set; }
    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayShootingAudio()
    {
        PlayAudioClip(shootingAudioClip);
    }
    public void PlayEnemyShootingAudio()
    {
        PlayAudioClip(shootingEnemyAudioClip);
    }

    public void PlayExplosionAudio()
    {
        PlayAudioClip(explosionAudioClip);
    }
    public void PlayEnemyExplosionAudio()
    {
        PlayAudioClip(explosionEnemyAudioClip);
    }

    public void PlayHitAudio()
    {
        PlayAudioClip(hitAudioClip);
    }

    void PlayAudioClip(MyAudio audio)
    {
        if (audio.audioClip == null)
            return;
        AudioSource.PlayClipAtPoint(audio.audioClip, Camera.main.transform.position, audio.volumn);
    }
}
