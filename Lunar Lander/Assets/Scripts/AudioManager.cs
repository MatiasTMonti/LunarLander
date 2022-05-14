using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Toggle toggle;

    private string volume = "volume";

    private void Awake()
    {
        SaveDataMute();
    }

    void Update()
    {
        MuteAudio();
    }

    private void SaveDataMute()
    {
        if (PlayerPrefs.HasKey(volume))
        {
            if (PlayerPrefs.GetInt(volume) == 1)
            {
                toggle.isOn = true;
            }
            else
            {
                toggle.isOn = false;
            }
        }
    }

    private void MuteAudio()
    {
        if (toggle.isOn)
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt(volume, 1);
        }
        else
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt(volume, 0);
        }
        PlayerPrefs.Save();
    }
}
