using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheaterController : MonoBehaviour
{
    // sprites
    [SerializeField] GameObject player;
    [SerializeField] GameObject netflixBoss;

    // curtains
    [SerializeField] GameObject curtains;
    [SerializeField] const float RAISE_CURTAIN_TIME = 5f;

    // Start is called before the first frame update
    void Start()
    {
        curtains = GameObject.Find("Curtains");
        player = GameObject.Find("Player");
        netflixBoss = GameObject.Find("NetflixBoss");
    }

    // Update is called once per frame
    void Update()
    {
        if (curtains.transform.position.y < 8.5f)
        {
            RaiseCurtains();
            Debug.Log("The curtain y position " + curtains.transform.position.y);
        }
    }

    private void FixedUpdate()
    {

    }

    private void RaiseCurtains()
    {
        curtains.transform.Translate(new Vector2(0, 1) * RAISE_CURTAIN_TIME * Time.deltaTime);
    }

    // fade in player
    IEnumerator FadeInPlayer(float fadeInSpeed)
    {
        while (player.GetComponent<SpriteRenderer>().color.a < 1)
        {
            Color playerColor = player.GetComponent<SpriteRenderer>().color; // current color values
            float playerOpacity = playerColor.a;
            player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, playerOpacity + fadeInSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
