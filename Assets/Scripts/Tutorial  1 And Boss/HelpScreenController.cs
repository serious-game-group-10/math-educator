using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScreenController : MonoBehaviour
{
    [SerializeField] GameObject helpPanel;
    [SerializeField] HelpManager computerScreen;

    GameObject[] computers;

    int startIndex;
    int endIndex;

    private void Start()
    {
        if (computers == null)
        {
            computers = GameObject.FindGameObjectsWithTag("Computers");
        }

        if (helpPanel == null)
        {
            helpPanel = GameObject.Find("ComputerScreen");
        }

        if (computerScreen == null)
        {
            computerScreen = GameObject.Find("ComputerScreen").GetComponent<HelpManager>();
        }

        helpPanel.SetActive(false);
    }

    private void DisplayHelpScreen(int index, int upperLimit)
    {
        helpPanel.SetActive(true);

        computerScreen.SetHelpIndex(index);
        computerScreen.SetLowerLimit(index);
        computerScreen.SetUpperLimit(upperLimit);
        computerScreen.DisplayFirstImage();
        
        Time.timeScale = 0;
    }

    public void DisplayHelpScreen1()
    {
        SetStartAndEnd(0, 2);
        DisplayHelpScreen(startIndex, endIndex);
    }

    public void DisplayHelpScreen3()
    {
        SetStartAndEnd(3, 6);
        DisplayHelpScreen(startIndex, endIndex);
    }

    public void DisplayHelpScreen2()
    {
        SetStartAndEnd(7, 10);
        DisplayHelpScreen(startIndex, endIndex);
    }

    public void HideHelpScreen()
    {
        helpPanel.SetActive(false);
        EnableComputers();

        Time.timeScale = 1;
    }

    private void SetStartAndEnd(int start, int end)
    {
        this.startIndex = start;
        this.endIndex = end;
    }

    // computer button disablers 

    public void DisableComp1()
    {
        computers[0].GetComponent<Button>().interactable = false;
    }

    public void DisableComp2()
    {
        computers[1].GetComponent<Button>().interactable = false;
    }
    public void DisableComp3()
    {
        computers[2].GetComponent<Button>().interactable = false;
    }

    private void EnableComputers()
    {
        foreach (GameObject computer in computers)
        {
            computer.GetComponent<Button>().interactable = true;
        }
    }
}
