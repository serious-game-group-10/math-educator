using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject advanceText;

    private void Start()
    {
        advanceText = GameObject.Find("AdvanceText");
        advanceText.GetComponent<Text>().text = "Press a to advance";
        advanceText.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            advanceText.SetActive(true);
        }
    }
}
