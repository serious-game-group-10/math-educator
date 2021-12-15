using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotDialogue : MonoBehaviour
{
    private string[] storyText = new string[] 
    {
        "Scanning lifeform........",
        "Error... Error... Unidentified lifeform detected",
        "Engaging security protocol D36K67",
        "Preparing security questions...",
        "Unidentified lifeform must answer security questions to advance",
        "Here is the first question..."
    };

    private string wrongText = "Error... error... wrong answer was chosen...";
    private string correctText = "Correct...";
    private string nextText = "Here is the next question...";
    private string victoryText = "The robot exploded...";

    [SerializeField] GameObject uiController;
    [SerializeField] Text displayText;
    [SerializeField] int textIndex;

    private void Start()
    {
        if (uiController == null)
        {
            uiController = GameObject.Find("GUIcontroller");
        }
        textIndex = 0;
        UpdateStoryTextDisplay();
    }

    private void Update()
    {
        if (Input.GetKeyDown("z") && textIndex < storyText.Length)
        {
            UpdateStoryTextDisplay();
        }
        else if (Input.GetKeyDown("z") && textIndex >= storyText.Length) 
        {
            uiController.GetComponent<UIController>().DisplayQuestionPanel();
            this.gameObject.SetActive(false);
            // explosion animation
        }
    }

    private void UpdateStoryTextDisplay()
    {
        // write text to UI display 
        displayText.text = storyText[textIndex];
        textIndex++;
    }

    public void ShowWrongAnswerMessage()
    {
        displayText.text = wrongText;
    }

    public void ShowRightAnswerMessage()
    {
        displayText.text = correctText;
    }
   
    public void ShowNextMessage()
    {
        displayText.text = nextText;
    }

    public void ShowVictoryMessage()
    {
        displayText.text = victoryText;
    }
}
