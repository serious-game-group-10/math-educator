using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattleController : MonoBehaviour
{
    // sprites
    [SerializeField] GameObject player;
    [SerializeField] const float SPRITE_FADE_TO_WHITE = 1f;
    [SerializeField] GameObject netflixBoss;

    // curtains
    [SerializeField] GameObject curtains;
    [SerializeField] const float RAISE_CURTAIN_TIME = 5f;

    // music
    [SerializeField] AudioSource backgroundMusic;

    //Gameobject
    private GameObject UIDisplay;

    // Start is called before the first frame update
    void Start()
    {
        // add game music here
        UIDisplay = GameObject.Find("UIDisplay");
        curtains = GameObject.Find("Curtains");
        player = GameObject.Find("Player");
        netflixBoss = GameObject.Find("Boss");
        UIDisplay.SetActive(false);
        player.SetActive(false);
        netflixBoss.SetActive(false);
        StartCoroutine(RaiseCurtains());
    }

    IEnumerator RaiseCurtains()
    {
        yield return new WaitForSeconds(2); // wait 2 seconds before executing below statements
        while (curtains.transform.position.y < 8.5f)
        {
            curtains.transform.Translate(new Vector2(0, 1f) * RAISE_CURTAIN_TIME * Time.deltaTime);
            yield return null;
        }

        UIDisplay.SetActive(true);
        player.SetActive(true);
        netflixBoss.SetActive(true);

        // backgroundMusic.Play();
    }
}
