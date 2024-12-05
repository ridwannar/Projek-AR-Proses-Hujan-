using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audioMixer; // Drag Audio Mixer ke sini di Inspector
    public string volumeParameter = "Volume"; // Nama parameter exposed di Audio Mixer
    public float fadeDuration = 1f; // Waktu fade
    private float targetVolume = 0f; // Volume target

    void Start()
    {
        // Set volume awal ke 0dB
        audioMixer.SetFloat(volumeParameter, 0f);
    }

    public void FadeOut()
    {
        StartCoroutine(FadeVolume(-20f)); // Redupkan suara (-20dB)
    }

    public void FadeIn()
    {
        StartCoroutine(FadeVolume(0f)); // Kembalikan suara ke normal (0dB)
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        float currentVolume;
        audioMixer.GetFloat(volumeParameter, out currentVolume);
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float newVolume = Mathf.Lerp(currentVolume, targetVolume, elapsed / fadeDuration);
            audioMixer.SetFloat(volumeParameter, newVolume);
            yield return null;
        }

        audioMixer.SetFloat(volumeParameter, targetVolume);
    }
}