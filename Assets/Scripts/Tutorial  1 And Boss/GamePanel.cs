using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePanel : MonoBehaviour
{
    [SerializeField] GameObject resumePauseBtnGO;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject black;
    
    [SerializeField] GameObject positions;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gui;

    private void Start()
    {
        if (positions == null)
        {
            positions = GameObject.Find("BoundariesAndPositions");
        }

        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        if (gui == null)
        {
            gui = GameObject.Find("GUI");
        }

        if(resumePauseBtnGO == null)
        {
            resumePauseBtnGO = GameObject.Find("ResumePauseBtn");
        }

        if (black == null)
        {
            black = GameObject.Find("black");
        }

        if (menu == null)
        {
            menu = GameObject.Find("Menu");
        }

        black.SetActive(false);
        menu.SetActive(false);
    }

    public void GoToMain()
    {
        SetInactive();
        menu.SetActive(true);
        black.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitMainMenu()
    {
        SetActive();
        menu.SetActive(false);
        black.SetActive(false);
        Time.timeScale = 1;
    }

    private void SetInactive()
    {
        positions.SetActive(false);
        player.SetActive(false);
        gui.SetActive(false);
    }

    private void SetActive()
    {
        positions.SetActive(true);
        player.SetActive(true);
        gui.SetActive(true);
    }
}
