using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance; // Singleton instance
    public GameObject pauseMenuUI; // Referensi ke UI Pause Menu
    private bool isPaused = false; // Status pause

    // Referensi ke komponen yang perlu dinonaktifkan
    private Sword sword; // Komponen Sword
    private SlashAnim slashAnim; // Komponen SlashAnim
    private BasicAttack basicAttack; // Komponen BasicAttack

    private void Awake()
    {
        // Menetapkan instance singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Memastikan tidak hancur saat memuat scene baru
        }
        else
        {
            Destroy(gameObject); // Menghancurkan instansi lain dari singleton
        }
    }

    void Start()
    {
        // Mengambil referensi ke komponen yang diperlukan
        sword = FindObjectOfType<Sword>();
        slashAnim = FindObjectOfType<SlashAnim>();
        basicAttack = FindObjectOfType<BasicAttack>();
    }

    void Update()
    {
        // Mengecek apakah tombol Escape ditekan
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Mengaktifkan kembali permainan
    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Menyembunyikan Pause Menu
        }

        Time.timeScale = 1f; // Mengembalikan waktu menjadi normal
        isPaused = false; // Status pause menjadi false
        EnableGameplay(); // Mengaktifkan kembali gameplay
    }

    // Menjeda permainan
    public void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true); // Menampilkan Pause Menu
        }

        Time.timeScale = 0f; // Menghentikan waktu
        isPaused = true; // Status pause menjadi true
        DisableGameplay(); // Menonaktifkan gameplay
    }

    // Menghentikan aplikasi
    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Jika di Unity Editor
        #else
        Application.Quit(); // Menghentikan aplikasi
        #endif
    }

    // Fungsi untuk menonaktifkan gameplay
    private void DisableGameplay()
    {
        // Menonaktifkan komponen yang relevan
        if (sword != null)
        {
            sword.enabled = false; // Menonaktifkan script Sword
        }

        if (slashAnim != null)
        {
            slashAnim.enabled = false; // Menonaktifkan script SlashAnim
        }

        if (basicAttack != null)
        {
            basicAttack.enabled = false; // Menonaktifkan script BasicAttack
        }
    }

    // Fungsi untuk mengaktifkan kembali gameplay
    private void EnableGameplay()
    {
        // Mengaktifkan kembali komponen yang relevan
        if (sword != null)
        {
            sword.enabled = true; // Mengaktifkan kembali script Sword
        }

        if (slashAnim != null)
        {
            slashAnim.enabled = true; // Mengaktifkan kembali script SlashAnim
        }

        if (basicAttack != null)
        {
            basicAttack.enabled = true; // Mengaktifkan kembali script BasicAttack
        }
    }
}