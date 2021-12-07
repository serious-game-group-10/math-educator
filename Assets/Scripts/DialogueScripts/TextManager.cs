using System;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private string[] firstTutorialLevelHelp = { "hello", "world", "bye" };
    private int maxPages;
    [SerializeField] int helpTextIndex = 0;

    private GameObject helpText;
    private GameObject pageNumberText;
    private GameObject nextButton;
    private GameObject prevButton;
    private GameObject helpPanel;

    private void Start()
    {
        helpText = GameObject.Find("HelpText");
        pageNumberText = GameObject.Find("PageNumbers");
        nextButton = GameObject.FindGameObjectWithTag("NextButton");
        prevButton = GameObject.FindGameObjectWithTag("PrevButton");
        helpPanel = GameObject.FindGameObjectWithTag("HelpPanel");
        prevButton.SetActive(false);
        helpPanel.SetActive(false);

        maxPages = firstTutorialLevelHelp.Length;
    }

    // start from beginning when help book clicked
    public void DisplayHelpPanel()
    {
        Debug.Log("display");
        // display help text panel
        helpPanel.SetActive(true);

        helpTextIndex = 0;
        UpdateHelpText();
        UpdatePageNumberText();
        UpdateNextButtonText();
    }

    // next button handler
    public void IncrementTextIndex()
    {
        helpTextIndex++;
        prevButton.SetActive(true);

        if (helpTextIndex >= firstTutorialLevelHelp.Length)
        {
            CloseHelpPanel();
            return;
        }

        UpdateHelpText();
        UpdateNextButtonText();
        UpdatePageNumberText();
    }

    // prev button handler
    public void DecrementHelpTextIndex()
    {
        helpTextIndex--;

        if (helpTextIndex <= 0)
        {
            prevButton.SetActive(false);
        }

        UpdateHelpText();
        UpdateNextButtonText();
        UpdatePageNumberText();
    }

    public void CloseHelpPanel()
    {
        prevButton.SetActive(false);
        helpPanel.SetActive(false);
    }

    private void UpdateHelpText()
    {
        helpText.GetComponent<Text>().text = firstTutorialLevelHelp[helpTextIndex];
    }

    private void UpdateNextButtonText()
    {
        if (helpTextIndex >= firstTutorialLevelHelp.Length - 1)
        {
            nextButton.GetComponentInChildren<Text>().text = "Close";
        }
        else
        {
            nextButton.GetComponentInChildren<Text>().text = "Next";
        }
    }

    private void UpdatePageNumberText()
    {
        pageNumberText.GetComponent<Text>().text = (helpTextIndex + 1) + " / " + maxPages;
    }
}
