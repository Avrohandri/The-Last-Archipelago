using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Untuk menggunakan Button

public class TextReveal : MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplay; // Komponen TextMeshPro untuk menampilkan teks
    [SerializeField] private Button mainMenuButton; // Referensi ke tombol Main Menu
    [SerializeField] private string text1 = "Halo";  // Teks pertama
    [SerializeField] private string text2 = "Hali";  // Teks kedua
    [SerializeField] private float typingSpeed = 0.1f; // Kecepatan untuk efek typing
    [SerializeField] private float switchDelay = 2.0f; // Delay antara pergantian teks

    private void Start()
    {
        mainMenuButton.gameObject.SetActive(false); // Sembunyikan tombol saat mulai
        StartCoroutine(SwitchText()); // Mulai coroutine untuk mengganti teks
    }

    private IEnumerator SwitchText()
    {
        yield return StartCoroutine(TypeText(text1)); // Tampilkan teks pertama
        yield return new WaitForSeconds(switchDelay); // Tunggu sebelum berganti
        yield return StartCoroutine(TypeText(text2)); // Tampilkan teks kedua
        yield return new WaitForSeconds(switchDelay); // Tunggu sebelum berganti
        
        // Setelah semua teks ditampilkan dan ditunggu, hilangkan teks dan GameObject
        textDisplay.text = ""; // Kosongkan teks
        Destroy(gameObject); // Hancurkan GameObject ini

        // Menghancurkan GameObject bernama "Main"
        GameObject mainObject = GameObject.Find("MainGyatt");
        if (mainObject != null)
        {
            Destroy(mainObject); // Hancurkan GameObject bernama "Main"
        }

        // Tampilkan tombol Main Menu
        mainMenuButton.gameObject.SetActive(true); // Menampilkan tombol Main Menu
    }

    private IEnumerator TypeText(string text)
    {
        textDisplay.text = ""; // Kosongkan teks sebelumnya
        foreach (char letter in text.ToCharArray())
        {
            textDisplay.text += letter; // Tambahkan huruf satu per satu
            yield return new WaitForSeconds(typingSpeed); // Tunggu sesuai kecepatan
        }
    }
}