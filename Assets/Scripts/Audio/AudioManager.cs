using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public TMP_Text volumeText;
    public Slider volumeSlider;
    public AudioSource volumeSource;

    [Header("Audio Clips")] 
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip pickUpSound;
    [SerializeField] private AudioClip buttonPressSound;
    [SerializeField] private AudioClip useScrewdriverSound;
    [SerializeField] private AudioClip dynamiteSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(VolumeFunction);
        VolumeFunction(volumeSlider.value);
    }
    
    public void VolumeFunction(float volume)
    {
        volumeText.text = $"Volume :{Mathf.RoundToInt(volume*100)}%";
        volumeSource.volume = volume;
    }

    public void PlayButtonClickSound()
    {
        volumeSource.PlayOneShot(buttonClickSound);
    }

    public void PlayPickUpSound()
    {
        volumeSource.PlayOneShot(pickUpSound);
    }

    /// <summary>
    /// Sound for the in-game button, NOT the UI button
    /// </summary>
    public void PlayButtonPressedSound()
    {
        volumeSource.PlayOneShot(buttonPressSound);
    }

    public void UseScrewdriverSound()
    {
        volumeSource.PlayOneShot(useScrewdriverSound);
    }

    public void PlantDynamiteSound()
    {
        volumeSource.PlayOneShot(dynamiteSound);
    }
}


