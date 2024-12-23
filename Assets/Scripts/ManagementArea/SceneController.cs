using UnityEngine;
using UnityEngine.SceneManagement;  // Untuk mengelola scene

public class SceneController : MonoBehaviour
{
    // Fungsi untuk restart ke Scene1
    public void RestartGame()
    {
        // Muat scene "Scene1"
        SceneManager.LoadScene("Scene1");
    }

    // Fungsi untuk kembali ke Main Menu
    public void GoToMainMenu()
    {
        // Ganti "MainMenu" dengan nama scene menu utama Anda
        SceneManager.LoadScene("Scene_Menu");  
    }

    // Fungsi untuk berpindah ke Scene_Selesai1
    public void GoToSceneSelesai1()
    {
        SceneManager.LoadScene("Scene_Selesai1");
    }
}