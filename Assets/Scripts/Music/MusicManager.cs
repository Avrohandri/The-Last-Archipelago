using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] sceneMusics; // Daftar musik untuk setiap scene, urutkan sesuai build index

    private AudioSource audioSource;

    void Awake()
    {
        // Pastikan MusicManager hanya ada satu (Singleton)
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        // Dengarkan event perpindahan scene
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ambil musik untuk scene yang baru dimuat
        int sceneIndex = scene.buildIndex;
        if (sceneIndex < sceneMusics.Length)
        {
            AudioClip newMusic = sceneMusics[sceneIndex];

            if (newMusic != null && audioSource.clip != newMusic)
            {
                ChangeMusic(newMusic);
            }
        }
    }

    public void ChangeMusic(AudioClip newMusic)
    {
        audioSource.Stop();
        audioSource.clip = newMusic;
        audioSource.Play();
    }

    void OnDestroy()
    {
        // Lepaskan event saat objek dihancurkan
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
