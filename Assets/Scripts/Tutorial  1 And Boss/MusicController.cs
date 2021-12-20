using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private AudioSource backgroundMusic;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.volume = DataPersistor.instance.getGameVolume();
    }

    private void Update()
    {
        backgroundMusic.volume = DataPersistor.instance.getGameVolume();

        if (SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7)
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayMusic()
    {
        if (backgroundMusic.isPlaying) return;
        backgroundMusic.Play();
    }

    public void StopMusic()
    {
        backgroundMusic.Stop();
    }
}
