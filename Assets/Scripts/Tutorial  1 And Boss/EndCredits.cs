using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCredits : MonoBehaviour
{
    [SerializeField] Text creditsDisplay;

    string[] credits = new string[] { 
    "Null made by: Serious Game Group 10\nRuimin Xu\nMeagan Ruan\nMiguel Abundis Cruz\nGilman Huang",

    "Narrative by:\nMiguel Abundis Cruz",

    "Art Style & Music:\nMeagan Ruan",

    "Animations:\nMeagan Ruan",

    "Educational Material:\nRuimin Xu\nMiguel Abundis Cruz\nGilman Huang",

    "Combat System:\nRuimin Xu",

    "Level Design:\nGilman Huang",

    "UI Design:\nMeagan Ruan\nRuimin Xu\nGilman Huang",
    
    "Programming Game Logic:\nRuimin Xu\nMeagan Ruan\nMiguel Abundis Cruz\nGilman Huang",   

    "The End"};


    // Start is called before the first frame update
    void Start()
    {
        if (creditsDisplay == null)
        {
            creditsDisplay = GameObject.Find("Credits").GetComponent<Text>();
        }

        StartCoroutine(EndCreditText());
    }

    IEnumerator EndCreditText()
    {
        for (int i = 0; i < credits.Length; i++)
        {
            creditsDisplay.text = credits[i];
            yield return new WaitForSeconds(3);
        }
    }

}
