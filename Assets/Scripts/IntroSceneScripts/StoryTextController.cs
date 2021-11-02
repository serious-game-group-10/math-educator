using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryTextController : MonoBehaviour
{
    private string[] storyText = new string[] {"Hello and welcome to the introduction scene", 
        "This is where we explain the story of our game and characerts", 
        "But for now we have placeholder text here to test the dialogue sound effects", 
        "More to come in the near future", 
        "Thanks for dropping by"};

    [SerializeField] TextWriter textWriter;
    [SerializeField] Button storyDialogueButton;
    [SerializeField] Text displayText;
    [SerializeField] int index = 0;
    [SerializeField] int currentSceneIndex = 1;

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
        } else if (Input.GetKeyDown("z") && index >= storyText.Length)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    private void UpdateStoryTextDisplay()
    {
        // write letters to display
        textWriter.AddTextDialogue(displayText, storyText[index], 0.08f);
        index++;
        Debug.Log("story index after change" + index);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
