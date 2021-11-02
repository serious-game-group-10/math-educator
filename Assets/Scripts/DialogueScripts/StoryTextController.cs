using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextController : MonoBehaviour
{
    private string[] storyText = new string[] {"Hello", "This is the game intro", "Thanks"};
    [SerializeField] TextWriter textWriter;
    [SerializeField] Button storyDialogueButton;
    [SerializeField] Text displayText;
    [SerializeField] int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateStoryTextDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") && index < storyText.Length)
        {
            UpdateStoryTextDisplay();
        }
    }

    private void UpdateStoryTextDisplay()
    {
        // write letters to display
        textWriter.AddTextDialogue(displayText, storyText[index], 0.1f);
        index++;
        Debug.Log("story index after change" + index);
    }
}
