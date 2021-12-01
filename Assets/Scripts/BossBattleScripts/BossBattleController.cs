using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        // add game music here


        curtains = GameObject.Find("Curtains");
        player = GameObject.Find("Player");
        netflixBoss = GameObject.Find("NetflixBoss");
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

        // backgroundMusic.Play();
    }
}
