using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// text writing utility class

public class TextWriter : MonoBehaviour
{
    private AudioSource textAudio;
    private Text dialogue;
    private string textToWrite;
    private int letterIndex;
    private float dialogueSpeed;
    private float timer;

    private void Start()
    {
        if (textAudio == null)
        {
            textAudio = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue != null)
        {
            timer -= Time.deltaTime; // time between frames
            while (timer <= 0f)
            {
                timer += dialogueSpeed;
                letterIndex++;
                dialogue.text = textToWrite.Substring(0, letterIndex);
                textAudio.Play();

                if (letterIndex >= textToWrite.Length)
                {
                    dialogue = null;
                    return;
                }
            }
        }
    }

    // get the Text component to write to
    // get the words to write to text component
    // get the speed at which characters appear on display
    public void AddTextDialogue(Text displayText, string text, float writeSpeed) 
    {
        dialogue = displayText;
        textToWrite = text;
        dialogueSpeed = writeSpeed;
        letterIndex = 0;
    }
}
