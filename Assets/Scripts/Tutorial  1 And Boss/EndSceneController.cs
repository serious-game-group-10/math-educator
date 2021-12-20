using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
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
    }

    public void StartOver()
    {
        SceneManager.LoadScene(0);
    }
}
