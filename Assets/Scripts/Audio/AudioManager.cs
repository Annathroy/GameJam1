using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public TMP_Text volumeText;
    public Slider volumeSlider;
    public AudioSource volumeSource;
    public AudioSource backgroundMusicSource;

    [Header("Audio Clips")] 
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip pickUpSound;
    [SerializeField] private AudioClip buttonPressSound;
    [SerializeField] private AudioClip dynamiteSound;
    
    [SerializeField] private AudioClip gameplayBackgroundMusic;
    [SerializeField] private AudioClip mainMenuBackgroundMusic;
    [SerializeField] private AudioClip nuclearBackgroundMusic;
    [SerializeField] private AudioClip neutralBackgroundMusic;

    [SerializeField] private AudioClip doorExitSound;
    [SerializeField] private AudioClip openHatchSound;
    [SerializeField] private AudioClip robotCrashSound;
    [SerializeField] private AudioClip boxCrashSound;
    [SerializeField] private AudioClip vibrateScrew;
    [SerializeField] private AudioClip screwdriverSound;
    [SerializeField] private AudioClip playerJumpSound;
    [SerializeField] private AudioClip glassBreakSound;
    [SerializeField] private AudioClip nuclearExplosionSound;


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
        volumeText.text = $"Volume: {Mathf.RoundToInt(volume*100)}%";
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

    public void PlantDynamiteSound()
    {
        volumeSource.PlayOneShot(dynamiteSound);
    }

    public void PlayGameBackgroundMusic()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.resource = gameplayBackgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayMainMenuBackgroundMusic()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.resource = mainMenuBackgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayDoorExitSound()
    {
        volumeSource.PlayOneShot(doorExitSound);
    }

    public void PlayOpenHatch()
    {
        volumeSource.PlayOneShot(openHatchSound);
    }

    public void PlayRobotCrash()
    {
        volumeSource.PlayOneShot(robotCrashSound);
    }

    public void PlayBoxCrash()
    {
        volumeSource.PlayOneShot(boxCrashSound);
    }

    public void PlayVibrateScrew()
    {
        volumeSource.PlayOneShot(vibrateScrew);
    }

    public void PlayScrewdriverSound()
    {
        volumeSource.PlayOneShot(screwdriverSound);
    }

    public void PlayPlayerJump()
    {
        volumeSource.PlayOneShot(playerJumpSound);
    }

    public void PlayGlassBreak()
    {
        volumeSource.PlayOneShot(glassBreakSound);
    }

    public void PlayBadEnding()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.resource = nuclearBackgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
        volumeSource.PlayOneShot(nuclearExplosionSound);
    }

    public void PlayNeutralEnding()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.resource = neutralBackgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }
}


