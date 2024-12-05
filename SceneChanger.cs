using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public AudioClip buttonClickSound; // Audio clip untuk suara tombol
    private AudioSource audioSource;

    private void Start()
    {
        // Mendapatkan komponen AudioSource pada GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Jika tidak ada AudioSource, tambahkan otomatis
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void ChangeScene(string sceneName)
    {
        // Memutar suara tombol klik
        if (buttonClickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }

        // Tunggu sampai suara selesai sebelum mengganti scene
        StartCoroutine(ChangeSceneAfterSound(sceneName));
    }

    private System.Collections.IEnumerator ChangeSceneAfterSound(string sceneName)
    {
        // Tunggu durasi suara jika ada
        if (buttonClickSound != null)
        {
            yield return new WaitForSeconds(buttonClickSound.length);
        }

        // Ganti scene
        SceneManager.LoadScene(sceneName);
    }
}
