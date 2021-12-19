using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePanel : MonoBehaviour
{
    [SerializeField] GameObject mainMenuBtn;
    [SerializeField] GameObject resumePauseBtnGO;

    private void Start()
    {
        if(resumePauseBtnGO == null)
        {
            resumePauseBtnGO = GameObject.Find("ResumePauseBtn");
        }
    }

    public void goToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void pauseOrResume()
    {
        Button button = resumePauseBtnGO.GetComponent<Button>();
        Debug.Log(resumePauseBtnGO);
        Debug.Log(button);
        Text text = button.GetComponentInChildren<Text>();

        if (text.text == "Pause")
        {
            Time.timeScale = 0;
            text.text = "Resume";
        }
        else
        {
            Time.timeScale = 1;
            text.text = "Pause";
        }
    }
}
