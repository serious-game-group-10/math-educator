using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    GameObject[] mainMenuObjects;
    GameObject[] settingMenuObjects;
    GameObject[] instructionObjects;
    GameObject backdrop;
    private int currentSceneIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuObjects = GameObject.FindGameObjectsWithTag("MainScreen");
        settingMenuObjects = GameObject.FindGameObjectsWithTag("SettingsScreen");
        instructionObjects = GameObject.FindGameObjectsWithTag("InstructionsScreen");
        backdrop = GameObject.FindGameObjectWithTag("SettingBackdrop");

        this.HideBackdrop();
        this.ExitSettingsMenu();
        this.ExitInstructionsMenu();
    }

    // play game button function
    public void StartGame()
    {
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }


    // menu screen button operations
    public void EnterSettingsMenu()
    {
        this.ExitMainMenu();
        this.ShowBackdrop();
        foreach (GameObject obj in settingMenuObjects)
        {
            obj.SetActive(true);
        }
    }

    public void EnterInstructionsMenu()
    {
        this.ExitMainMenu();
        this.ShowBackdrop();
        foreach (GameObject obj in instructionObjects)
        {
            obj.SetActive(true);
        }
    }

    public void EnterMainMenu()
    {
        this.HideBackdrop();
        this.ExitSettingsMenu();
        this.ExitInstructionsMenu();
        foreach (GameObject obj in mainMenuObjects)
        {
            obj.SetActive(true);
        }
    }

    private void ExitSettingsMenu()
    {
        foreach (GameObject obj in settingMenuObjects)
        {
            obj.SetActive(false);
        }
    }

    private void ExitInstructionsMenu()
    {
        foreach (GameObject obj in instructionObjects)
        {
            obj.SetActive(false);
        }
    }

    private void ExitMainMenu()
    {
        foreach (GameObject obj in mainMenuObjects)
        {
            obj.SetActive(false);
        }
    }

    // grey transparent backdrop when instruction or setting screen is active
    private void HideBackdrop()
    {
        this.backdrop.SetActive(false);
    }

    private void ShowBackdrop()
    {
        this.backdrop.SetActive(true);
    }
}
