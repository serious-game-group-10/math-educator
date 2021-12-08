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


    [SerializeField] GameObject uiController;
    [SerializeField] TextWriter textWriter;
    [SerializeField] Text displayText;
    [SerializeField] int textIndex;
    [SerializeField] const float TEXT_WRITING_SPEED = 0.08f;

    private void Start()
    {
        if (uiController == null)
        {
            uiController = GameObject.Find("LevelController");
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
        // write text to UI display using utility class
        textWriter.AddTextDialogue(displayText, storyText[textIndex], TEXT_WRITING_SPEED);
        textIndex++;
    }

    public void ShowWrongAnswerMessage()
    {
        ShowNewMessage(wrongText);
    }

    public void ShowRightAnswerMessage()
    {
        ShowNewMessage(correctText);
    }
   
    public void ShowNextMessage()
    {
        ShowNewMessage(nextText);
    }

    private void ShowNewMessage(string newText)
    {
        textWriter.AddTextDialogue(displayText, newText, TEXT_WRITING_SPEED);
    }
}
