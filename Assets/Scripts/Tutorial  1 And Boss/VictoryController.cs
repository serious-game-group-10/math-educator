using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour
{
    [SerializeField] AudioSource creditMusic;

    private void Start()
    {
        if (creditMusic == null)
        {
            creditMusic = GetComponent<AudioSource>();
        }

        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().StopMusic();
        creditMusic.Play();
        creditMusic.volume = DataPersistor.instance.getGameVolume();
    }

    private void Update()
    {
        creditMusic.volume = DataPersistor.instance.getGameVolume();
    }

    public void StartOver()
    {
        SceneManager.LoadScene(0);
        DataPersistor.instance.setPlayerHealth(100);
        DataPersistor.instance.gameReset();
    }
}
