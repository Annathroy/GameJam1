using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public TMP_Text volumeText;
    public Slider volumeSlider;
    public AudioSource volumeSource;

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
}


