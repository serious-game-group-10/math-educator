using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    GameObject[] helpImages;
    GameObject nextButton;
    GameObject prevButton;
    GameObject pageText;
    GameObject helpScreen;
    private int helpIndex;

    private void Start()
    {
        nextButton = GameObject.Find("NextButton");
        prevButton = GameObject.Find("PreviousButton");
        pageText = GameObject.Find("PageNumber");
        helpScreen = GameObject.Find("ComputerScreen");

        helpIndex = 0;
        if (helpImages == null)
        {
            helpImages = GameObject.FindGameObjectsWithTag("Help");
        }

        foreach (GameObject helpImg in helpImages)
        {
            helpImg.SetActive(false);
        }

        helpImages[helpIndex].SetActive(true);
        prevButton.SetActive(false);
        UpdatePageNumber();ChangeButtonToClose();
    }

    public void DisplayNextHelp()
    {
        helpImages[helpIndex].SetActive(false);
        helpIndex++;
        prevButton.SetActive(true);

        if (helpIndex >= helpImages.Length)
        {
            CloseHelpScreen();
            return;
        }

        helpImages[helpIndex].SetActive(true);
        DisplayPreviousButton();
        UpdatePageNumber();
        ChangeButtonToClose();
    }

    public void DisplayPreviousHelp()
    {
        helpImages[helpIndex].SetActive(false);
        helpIndex--;

        if (helpIndex <= 0)
        {
            HidePreviousButton();
        }

        helpImages[helpIndex].SetActive(true);
        UpdatePageNumber();
        ChangeButtonToClose();
    }

    private void DisplayPreviousButton()
    {
        prevButton.SetActive(true);
    }

    private void HidePreviousButton()
    {
        prevButton.SetActive(false);
    }

    private void UpdatePageNumber()
    {
        pageText.GetComponent<Text>().text = (helpIndex + 1) + " / 3";
    }

    private void ChangeButtonToClose()
    {
        if (helpIndex >= helpImages.Length - 1)
        {
            nextButton.GetComponentInChildren<Text>().text = "Close";
        }
        else
        {
            nextButton.GetComponentInChildren<Text>().text = "Next";
        }
    }

    public void CloseHelpScreen()
    {
        foreach (GameObject img in helpImages)
        {
            img.SetActive(false);
        }

        helpIndex = 0;
        helpImages[helpIndex].SetActive(true);

        HidePreviousButton();
        ChangeButtonToClose();
        UpdatePageNumber();
        helpScreen.SetActive(false);

        Time.timeScale = 1;
    }
}
