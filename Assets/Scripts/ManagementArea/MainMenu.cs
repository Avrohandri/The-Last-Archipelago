using UnityEngine;
using UnityEngine.SceneManagement;  // Untuk mengelola scene
#if UNITY_EDITOR
using UnityEditor;  // Untuk mengakses EditorApplication di editor
#endif

public class MainMenu : MonoBehaviour
{
    public GameObject guideBookPanel;  // Panel untuk guide book

    // Fungsi untuk mulai permainan (load Scene1)
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    // Fungsi untuk membuka guide book
    public void OpenGuideBook()
    {
        guideBookPanel.SetActive(true); // Menampilkan panel guide book
    }

    // Fungsi untuk menutup guide book
    public void CloseGuideBook()
    {
        guideBookPanel.SetActive(false); // Menyembunyikan panel guide book
    }

    // Fungsi untuk keluar dari permainan
    public void Exit()
    {
#if UNITY_EDITOR
        // Berhenti bermain di editor
        EditorApplication.isPlaying = false;
#else
        // Keluar dari aplikasi (berfungsi di build)
        Application.Quit();
#endif
    }

    // Fungsi untuk pergi ke Scene_Menu
    public void GoToSceneMenu()
    {
        SceneManager.LoadScene("Scene_Menu");  // Memuat scene menu
    }

    // Fungsi untuk pergi ke Scene_Prolog
    public void GoToSceneProlog()
    {
        SceneManager.LoadScene("Scene_Prolog");  // Memuat scene prolog
    }
}