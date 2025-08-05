using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public TMP_Text volumeText;
    public Slider volumeSlider;
    public AudioSource sfxVolumeSource;
    public AudioSource musicVolumeSource;
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
	[SerializeField] private AudioClip goodBackgroundMusic;
	[SerializeField] private AudioClip trueBackgroundMusic;

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
        sfxVolumeSource.volume = volume;
        musicVolumeSource.volume = volume;
    }

    public void PlayButtonClickSound()
    {
        sfxVolumeSource.PlayOneShot(buttonClickSound);
    }

    public void PlayPickUpSound()
    {
        sfxVolumeSource.PlayOneShot(pickUpSound);
    }

    /// <summary>
    /// Sound for the in-game button, NOT the UI button
    /// </summary>
    public void PlayButtonPressedSound()
    {
        sfxVolumeSource.PlayOneShot(buttonPressSound);
    }

    public void PlantDynamiteSound()
    {
        sfxVolumeSource.PlayOneShot(dynamiteSound);
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
        sfxVolumeSource.PlayOneShot(doorExitSound);
    }

    public void PlayOpenHatch()
    {
        sfxVolumeSource.PlayOneShot(openHatchSound);
    }

    public void PlayRobotCrash()
    {
        sfxVolumeSource.PlayOneShot(robotCrashSound);
    }

    public void PlayBoxCrash()
    {
        sfxVolumeSource.PlayOneShot(boxCrashSound);
    }

    public void PlayVibrateScrew()
    {
        sfxVolumeSource.PlayOneShot(vibrateScrew);
    }

    public void PlayScrewdriverSound()
    {
        sfxVolumeSource.PlayOneShot(screwdriverSound);
    }

    public void PlayPlayerJump()
    {
        sfxVolumeSource.PlayOneShot(playerJumpSound);
    }

    public void PlayGlassBreak()
    {
        sfxVolumeSource.PlayOneShot(glassBreakSound);
    }

    public void PlayBadEnding()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.resource = nuclearBackgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
        sfxVolumeSource.PlayOneShot(nuclearExplosionSound);
    }

    public void PlayNeutralEnding()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.resource = neutralBackgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayGoodEnding()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.resource = goodBackgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayTrueEnding()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.resource = trueBackgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }
}


