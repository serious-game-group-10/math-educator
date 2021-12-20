using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().StopMusic();
        DataPersistor.instance.setInFight(false);
        DataPersistor.instance.setPlayerHealth(100);
        DataPersistor.instance.gameReset();
    }

    public void StartOver()
    {
        SceneManager.LoadScene(0);
    }
}
