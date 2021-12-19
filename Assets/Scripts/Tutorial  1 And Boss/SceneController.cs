using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject advanceText;
    private bool inContact = false;
 
    private void Start()
    {
        advanceText = GameObject.Find("AdvanceText");
        advanceText.GetComponent<Text>().text = "Press \"z\" to advance";
        advanceText.SetActive(false);

        //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().PlayMusic();
    }

    private void Update()
    {
        if(inContact)
        {
            if (Input.GetKeyDown("z"))
            {
                if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    DataPersistor.instance.addHighScore();
                }

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            advanceText.SetActive(true);

            inContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            advanceText.SetActive(false);
            inContact = false;
        }
    }
}
