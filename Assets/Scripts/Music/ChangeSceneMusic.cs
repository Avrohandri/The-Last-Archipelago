using UnityEngine;

public class ChangeSceneMusic : MonoBehaviour
{
    public AudioClip newMusic; // Masukkan AudioClip baru di Inspector

    void Start()
    {
        MusicManager musicManager = FindObjectOfType<MusicManager>();
        if (musicManager != null && newMusic != null)
        {
            musicManager.ChangeMusic(newMusic);
        }
    }
}
