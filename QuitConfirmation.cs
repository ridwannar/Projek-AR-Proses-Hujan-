using UnityEngine;
using UnityEngine.UI;

public class QuitConfirmation : MonoBehaviour
{
    public GameObject popUpPanel; // Panel pop-up
    public Button quitButton; // Tombol Quit di UI utama
    public Button yesButton; // Tombol "Ya" di pop-up
    public Button noButton; // Tombol "Tidak" di pop-up

    void Start()
    {
        // Sembunyikan pop-up saat awal
        popUpPanel.SetActive(false);

        // Tambahkan listener ke tombol
        quitButton.onClick.AddListener(ShowPopUp);
        yesButton.onClick.AddListener(QuitGame);
        noButton.onClick.AddListener(ClosePopUp);
    }

    void ShowPopUp()
    {
        popUpPanel.SetActive(true); // Tampilkan pop-up
    }

    void ClosePopUp()
    {
        popUpPanel.SetActive(false); // Sembunyikan pop-up
    }

    void QuitGame()
    {
        Debug.Log("Keluar dari permainan!");
        Application.Quit(); // Keluar dari aplikasi
    }
}
