using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    [SerializeField] GameObject curtains;
    [SerializeField] const float RAISE_CURTAIN_TIME = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if (curtains == null)
        {
            curtains = GameObject.Find("Curtains");
        }
    }

    public void NextLevel()
    {
        StartCoroutine(AdvanceLevel());
    }

    // Update is called once per frame
    IEnumerator AdvanceLevel()
    {
        // drop curtains
        while (curtains.transform.position.y > -0.5f)
        {
            curtains.transform.Translate(new Vector2(0, -1f) * RAISE_CURTAIN_TIME * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1);

        // change scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
