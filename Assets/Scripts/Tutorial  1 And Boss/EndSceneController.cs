using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().StopMusic();
    }

    public void StartOver()
    {
        SceneManager.LoadScene(0);
    }
}
