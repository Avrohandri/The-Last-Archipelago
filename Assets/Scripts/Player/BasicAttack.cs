using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public AudioClip attackClip; // File audio yang akan diseret
    private AudioSource audioSource;
    
    [Range(0f, 1f)] // Membatasi slider volume antara 0 hingga 1
    public float sfxVolume = 0.7f; // Volume yang bisa diatur dari Inspector

    private void Start()
    {
        // Tambahkan AudioSource otomatis jika belum ada
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Pastikan AudioSource tidak memutar otomatis
        audioSource.playOnAwake = false;
    }

    public void PlayAttackSFX()
    {
        if (attackClip != null)
        {
            // Memutar audio dengan volume yang diatur melalui sfxVolume
            audioSource.PlayOneShot(attackClip, sfxVolume); 
            Debug.Log("Basic attack SFX played!");
        }
        else
        {
            Debug.LogWarning("Attack Clip not assigned!");
        }
    }

    private void Update()
    {
        // Contoh trigger dengan mouse click kiri
        if (Input.GetMouseButtonDown(0)) // 0 = Left Mouse Button
        {
            PlayAttackSFX();
        }
    }
}
