using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    private AudioSource mainAudioSource;
    
    private Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = GetComponent<Slider>();
        mainAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        volumeSlider.onValueChanged.AddListener(OnVolumeChange);

        OnVolumeChange(30);
    }

    public void OnVolumeChange(float volume)
    {
        Debug.Log($"volume: {volume}");
        Debug.Log($"mainAudioSource: {mainAudioSource is null}");
        mainAudioSource.volume = (volume / 100f);
    }
}
