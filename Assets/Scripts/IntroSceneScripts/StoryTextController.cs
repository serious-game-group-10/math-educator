using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryTextController : MonoBehaviour
{
    private string[] storyText = new string[] {"Hello and welcome to the introduction scene", 
        "This is where we explain the story of our game and characters", 
        "But for now we have placeholder text here to test the dialogue sound effects", 
        "More to come in the near future", 
        "Thanks for dropping by"};

    [SerializeField] TextWriter textWriter;
    [SerializeField] Text displayText;
    [SerializeField] int index = 0;
    [SerializeField] int currentSceneIndex = 1;

    // audio 
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] const float TIME_MUSIC_DELAY = 2;

    // scene props
    [SerializeField] GameObject streetLamp;
    [SerializeField] GameObject playerSprite;
    [SerializeField] GameObject spotlight;
    [SerializeField] const float LAMP_FADE_IN_TIME = 0.1f;
    [SerializeField] const float PLAYER_FADE_IN_TIME = 0.1f;
    [SerializeField] const float SPOTLIGHT_FADE_IN_TIME = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        streetLamp = GameObject.Find("Street-Lamp");
        playerSprite = GameObject.Find("Player");
        spotlight = GameObject.Find("Spotlight");

        // hide scene props 
        streetLamp.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        playerSprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        spotlight.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

        backgroundMusic = GetComponent<AudioSource>();
        UpdateStoryTextDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") && index < storyText.Length)
        {
            // wait until second dialogue text appears
            if (index == 1)
            {
                StartBackgroundMusic(); // play background music
                // fade in all scene props
                StartCoroutine(FadeInLamp(LAMP_FADE_IN_TIME));
                StartCoroutine(FadeInLight(SPOTLIGHT_FADE_IN_TIME));
            } 
            else if (index == 2)
            {
                StartCoroutine(FadeInPlayer(PLAYER_FADE_IN_TIME));
            }

            UpdateStoryTextDisplay();
        } 
        else if (Input.GetKeyDown("z") && index >= storyText.Length)
        {
            LoadNextLevel();
        }
    }

    private void UpdateStoryTextDisplay()
    {
        // write text to UI display using utility class
        textWriter.AddTextDialogue(displayText, storyText[index], 0.08f);
        index++;
    }

    private void StartBackgroundMusic()
    {
       backgroundMusic.PlayDelayed(TIME_MUSIC_DELAY); // wait 3 seconds before playing audio
    }

    // Coroutine - runs over several frames without resetting values
    // fade in street lamp
    IEnumerator FadeInLamp(float fadeInSpeed)
    {
        while (streetLamp.GetComponent<SpriteRenderer>().color.a < 1)
        {
            Color lampColor = streetLamp.GetComponent<SpriteRenderer>().color; // current color values
            float lampOpacity = lampColor.a;
            streetLamp.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, lampOpacity + fadeInSpeed * Time.deltaTime); // increase opacity
            yield return null;
        }
    }

    // fade in lamp spotlight
    IEnumerator FadeInLight(float fadeInSpeed)
    {
        while (spotlight.GetComponent<SpriteRenderer>().color.a < 0.6)
        {
            Color lightColor = spotlight.GetComponent<SpriteRenderer>().color; // current color values
            float lightOpacity = lightColor.a;
            spotlight.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, lightOpacity + fadeInSpeed * Time.deltaTime);
            yield return null;
        }
    }

    // fade in player
    IEnumerator FadeInPlayer(float fadeInSpeed)
    {
        while (playerSprite.GetComponent<SpriteRenderer>().color.a < 1)
        {
            Color playerColor = playerSprite.GetComponent<SpriteRenderer>().color; // current color values
            float playerOpacity = playerColor.a;
            playerSprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, playerOpacity + fadeInSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
