using UnityEngine.SceneManagement;
using UnityEngine;

public class CrashDetecttor : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] ParticleSystem _snowEffect;
    AudioSource audioSource;
    [SerializeField] AudioClip crashSFX;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            audioSource.PlayOneShot(crashSFX);
            _particleSystem.Play();
            Invoke("ReloadScene", 1f);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _snowEffect.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _snowEffect.Stop();
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
