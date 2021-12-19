using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    GameObject[] helpImages;
    HelpScreenController screenController;
    GameObject prevBtn;
    GameObject nextBtn;

    private int helpIndex;
    private int upperLimit;
    private int lowerLimit;

    private void Start()
    {

        if (screenController == null)
        {
            screenController = GameObject.Find("ComputerController").GetComponent<HelpScreenController>();
        }

        if (prevBtn == null)
        {
            prevBtn = GameObject.Find("PreviousButton");
        }

        if (nextBtn == null)
        {
            nextBtn = GameObject.Find("NextButton");
        }

        if (helpImages == null)
        {
            helpImages = GameObject.FindGameObjectsWithTag("Help");
        }

        foreach (GameObject img in helpImages)
        {
            img.SetActive(false);
        }
    }


    // screen buttons

    public void DisplayNextImage()
    {
        HideCurrentImage();
        
        SetHelpIndex(helpIndex + 1);
        if (helpIndex > upperLimit)
        {
            CloseHelpScreen();
            return;
        }

        DisplayCurrentImage();
        ShowPrevBtn();
    }

    public void DisplayPreviousImage()
    {
        HideCurrentImage();

        SetHelpIndex(helpIndex - 1);
        if (helpIndex <= lowerLimit)
        {
            HidePrevBtn();
        }

        DisplayCurrentImage();
    }

    public void CloseHelpScreen()
    {
        HideImages();
        screenController.HideHelpScreen();
    }

   
    // called by screen controller

    public void DisplayFirstImage()
    {
        DisplayCurrentImage();
        HidePrevBtn();
    }

    public void SetHelpIndex(int index)
    {
        this.helpIndex = index;
    }

    public void SetUpperLimit(int limit)
    {
        this.upperLimit = limit;
    }

    public void SetLowerLimit(int limit)
    {
        this.lowerLimit = limit;
    }


    // helpers
    private void HideCurrentImage()
    {
        helpImages[helpIndex].SetActive(false);
    }

    private void DisplayCurrentImage()
    {
        helpImages[helpIndex].SetActive(true);
        SetTextNextToClose();
    }

    private void HidePrevBtn()
    {
        prevBtn.SetActive(false);
    }

    private void ShowPrevBtn()
    {
        prevBtn.SetActive(true);
    }

    private void SetTextNextToClose()
    {
        if (helpIndex >= upperLimit)
        {
            nextBtn.GetComponentInChildren<Text>().text = "Close";
        }
        else
        {
            nextBtn.GetComponentInChildren<Text>().text = "Next";
        }
    }

    private void HideImages()
    {
        foreach (GameObject img in helpImages)
        {
            img.SetActive(false);
        }
    }
}
