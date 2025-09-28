using UnityEngine;

public class ScenesMusicals : MonoBehaviour
{
    public AudioSource musicSource;

    void Start()
    {
        if (musicSource != null)
            musicSource.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Rock"))
        {
            Debug.Log("Player entr� en Rock");
            if (musicSource != null && !musicSource.isPlaying)
            {
                musicSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Rock"))
        {
            Debug.Log("Player sali� de Rock");
            if (musicSource != null)
            {
                musicSource.Stop();
            }
        }
    }
}
