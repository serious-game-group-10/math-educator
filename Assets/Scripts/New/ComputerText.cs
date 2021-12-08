using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerText : MonoBehaviour
{
    GameObject checkComputerText;

    private void Start()
    {
        if (checkComputerText == null)
        {
            checkComputerText = GameObject.Find("ClickMeText");
        }

        checkComputerText.GetComponent<Text>().text = "Check Computers";
        checkComputerText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            checkComputerText.SetActive(true);
        }
    }
}
