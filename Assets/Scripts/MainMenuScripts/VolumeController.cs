using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Text volumeText;

    private void Start()
    {
        if (volumeSlider == null)
        {
            volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        }
        volumeSlider.value = DataPersistor.instance.getGameVolume();
    }

    public void setVolume()
    {
        DataPersistor.instance.setGameVolume(volumeSlider.value);
        updateVolumeText();
    }

    private void updateVolumeText()
    {
        volumeText.text = System.Math.Round(DataPersistor.instance.getGameVolume() * 100).ToString();
    }
}

