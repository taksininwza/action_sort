using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem _particleSystem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _particleSystem.Play();
            this.GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delay);
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
