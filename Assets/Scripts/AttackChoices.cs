using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackChoices : MonoBehaviour
{
    [SerializeField] private GameObject attackChoicesPanel;
     private Weapon weapon;

    void Start()
    {
        if(weapon == null)
        {
            weapon = GameObject.Find("Player").GetComponent<Weapon>();
        }
    }

    void Update()
    {
        //if(Input.GetKeyDown("a"))
        //{
        //    checkAttackChoices(1);
        //}
        //else if(Input.GetKeyDown("b"))
        //{
        //    checkAttackChoices(2);
        //}
        //else if(Input.GetKeyDown("c"))
        //{
        //    checkAttackChoices(3);
        //}
        //else if(Input.GetKeyDown("d"))
        //{
        //    checkAttackChoices(4);
        //}
    }

    private void checkAttackChoices(int answerChoice)
    {
       if(answerChoice == 1)
        {
            weapon.ShootOne();
            attackChoicesPanel.SetActive(false);
        }
        else if(answerChoice == 2)
        {
            weapon.ShootTwo();
            attackChoicesPanel.SetActive(false);
        }
        else if(answerChoice == 3)
        {
            weapon.ShootThree();
            attackChoicesPanel.SetActive(false);
        }
        else
        {
            weapon.ShootFour();
            attackChoicesPanel.SetActive(false);
        }
    }

    public void AnswerA()
    {
        checkAttackChoices(1);
    }
    public void AnswerB()
    {
        checkAttackChoices(2);
    }
    public void AnswerC()
    {
        checkAttackChoices(3);
    }
    public void AnswerD()
    {
        checkAttackChoices(4);
    }
}
