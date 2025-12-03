using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    void Start()
    {
        // Load saved volume or set to default
        float volume = PlayerPrefs.GetFloat("volume", 0.75f);
        volumeSlider.value = volume;
        SetVolume(volume);
    }

    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("volume", value);
    }
}
