using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject questionUI;
    [SerializeField] GameObject dialogueUI;

    private void Start()
    {
        HideDialogueBox();
        HideQuestionPanel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DisplayDialogueBox();
        }
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
    }

    public void DisplayQuestionPanel()
    {
        questionUI.SetActive(true);
    }

    public void DisplayDialogueBox()
    {
        dialogueUI.SetActive(true);
    }

    public void HideQuestionPanel()
    {
        questionUI.SetActive(false);
    }

    public void HideDialogueBox()
    {
        dialogueUI.SetActive(false);
    }

    public void ShowNext()
    {
        DisplayDialogueBox();
        dialogueUI.GetComponent<RobotDialogue>().ShowNextMessage();
    }

    public void ShowWrong()
    {
        DisplayDialogueBox();
        dialogueUI.GetComponent<RobotDialogue>().ShowWrongAnswerMessage();
    }

    public void ShowCorrect()
    {
        DisplayDialogueBox();
        dialogueUI.GetComponent<RobotDialogue>().ShowRightAnswerMessage();
    }
}
