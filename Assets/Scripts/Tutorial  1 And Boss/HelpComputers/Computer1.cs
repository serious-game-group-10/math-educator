using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer1 : MonoBehaviour
{
    GameObject[] helpSet1;
    int helpIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (helpSet1 == null)
        {
            helpSet1 = GameObject.FindGameObjectsWithTag("Help");
        }

        helpIndex = 0;

        foreach (GameObject img in helpSet1)
        {
            img.SetActive(false);
        }

        helpSet1[helpIndex].SetActive(true);
    }

    public void DisplayNext()
    {
        helpSet1[helpIndex].SetActive(false);
        helpIndex++;
        helpSet1[helpIndex].SetActive(true);
    }
}

