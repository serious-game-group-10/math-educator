using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    [SerializeField] GameObject mainMenuOverlay;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject highscorePanel;
    [SerializeField] InputField nameInput;

    private void Start()
    {
        mainMenuOverlay = GameObject.FindGameObjectWithTag("Overlay");
        settingsPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        highscorePanel.SetActive(false);
    }

    public void GoToSettings()
    {
        Debug.Log("settings");
        mainMenuOverlay.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToInstructions()
    {
        Debug.Log("instructions");
        mainMenuOverlay.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void MainMenu()
    {
        settingsPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        highscorePanel.SetActive(false);
        mainMenuOverlay.SetActive(true);
    }

    public void GoToHighScores()
    {
        Debug.Log("HighScores");
        mainMenuOverlay.SetActive(false);
        highscorePanel.SetActive(true);
        DisplayHighscore highscore = highscorePanel.GetComponent<DisplayHighscore>();
        highscore.displayOne();
        highscore.displayTwo();
        highscore.displayThree();
        highscore.displayFour();
        highscore.displayFive();
    }

    public void inputName()
    {
        DataPersistor.instance.setPlayername(nameInput.text);
    }
}
