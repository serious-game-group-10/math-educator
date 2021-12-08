using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreenController : MonoBehaviour
{
    [SerializeField] GameObject helpPanel;

    private void Start()
    {
        if (helpPanel == null)
        {
            helpPanel = GameObject.Find("QuestionPanel");
        }

        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().PlayMusic();
        helpPanel.SetActive(false);
    }

    public void DisplayHelpScreen()
    {
        helpPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideHelpScreen()
    {
        helpPanel.SetActive(false);
    }
}
