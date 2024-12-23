using System.Collections;
using UnityEngine;
using TMPro;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 15f;
    [SerializeField] private AudioClip damageSFX;  // Audio clip untuk efek suara ketika terkena damage
    [SerializeField] private float sfxVolume = 0.7f;  // Volume untuk SFX
    [SerializeField] private GameObject winPanel;  // Panel yang akan muncul setelah musuh mati

    private int currentHealth;
    private Knockback knockback;
    private Flash flash;
    private AudioSource audioSource;  // AudioSource untuk memainkan SFX

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Tambahkan AudioSource jika belum ada
        }

        audioSource.playOnAwake = false; // Jangan putar otomatis saat game dimulai
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Memainkan efek suara saat monster terkena damage
        if (damageSFX != null)
        {
            audioSource.PlayOneShot(damageSFX, sfxVolume); // Memutar efek suara dengan volume yang ditentukan
        }

        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            GetComponent<PickUpSpawner>().DropItems();
            EconomyManager.Instance.UpdateCurrentGold();  // Update gold ketika musuh mati

            // Menampilkan panel kemenangan
            if (winPanel != null)
            {
                winPanel.SetActive(true);  // Menampilkan panel
            }

            Destroy(gameObject);
        }
    }
}
