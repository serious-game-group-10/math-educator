using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextController : MonoBehaviour
{
    private string[] storyText = new string[] {"Hello", "This is the game intro", "Thanks"};
    [SerializeField] Button storyDialogueButton;
    [SerializeField] Text displayText;
    [SerializeField] int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        displayText.text = storyText[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            UpdateStoryTextDisplay();
        }
    }

    public void UpdateStoryTextDisplay()
    {
        displayText.text = storyText[++index];
        Debug.Log("story index after change" + index);
    }
}
