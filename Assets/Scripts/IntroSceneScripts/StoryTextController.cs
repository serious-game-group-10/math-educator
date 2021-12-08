using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryTextController : MonoBehaviour
{
    private string[] storyText = new string[] {"The year is 3667.",
        "The world has been taken over by man-made machines that have risen to become sentient beings.",
        "Able to feel pain and emotions, the androids became fed up with the Human species and revolted.",
        "The androids started abducting the humans, taking them to the blackhole called the \"null\" where they would be discarded.",
        "The story begins with a bright young lad who has been abducted by the androids.",
        "Desparetely looking for a way out, the young lad makes his way through the android ship..."};

    [SerializeField] TextWriter textWriter;
    [SerializeField] Text displayText;
    [SerializeField] int textIndex = 0;
    [SerializeField] const float TEXT_WRITING_SPEED = 0.08f;

    // audio 
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] const float TIME_MUSIC_DELAY = 2;

    [SerializeField] const int CURRENT_SCENE_INDEX = 1;

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
        if (Input.GetKeyDown("z") && textIndex < storyText.Length)
        {
            // wait until second dialogue text appears
            if (textIndex == 1)
            {
                StartBackgroundMusic(); // play background music
                // fade in all scene props
                StartCoroutine(FadeInLamp(LAMP_FADE_IN_TIME));
                StartCoroutine(FadeInLight(SPOTLIGHT_FADE_IN_TIME));
            } 
            else if (textIndex == 2)
            {
                StartCoroutine(FadeInPlayer(PLAYER_FADE_IN_TIME));
            }

            UpdateStoryTextDisplay();
        } 
        else if (Input.GetKeyDown("z") && textIndex >= storyText.Length)
        {
            LoadNextLevel();
        }
    }

    private void UpdateStoryTextDisplay()
    {
        // write text to UI display using utility class
        textWriter.AddTextDialogue(displayText, storyText[textIndex], TEXT_WRITING_SPEED);
        textIndex++;
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
        SceneManager.LoadScene(CURRENT_SCENE_INDEX + 1);
    }
}
