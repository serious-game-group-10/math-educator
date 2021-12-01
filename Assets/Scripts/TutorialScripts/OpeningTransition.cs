using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningTransition : MonoBehaviour
{
    [SerializeField] GameObject playerTransition;
    [SerializeField] Vector3 scaleChange = new Vector3(-1f, -1f, 0f);
    [SerializeField] float shrinkSpeed = 0.01f;
    [SerializeField] float moveSpeed = 1f;
    private Vector3 endPosition = new Vector3(-5f, 0.2f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        playerTransition = GameObject.Find("PlayerTransition");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShrinkTransition());

        if (transform.position != endPosition)
        {
            MoveTransition();
        } 
        else
        {
            StartCoroutine(WaitOneSecondLoadNextScene());
        }
    }

    IEnumerator ShrinkTransition()
    {
        yield return new WaitForSeconds(2);

        while (playerTransition.transform.localScale.x > 1)
        {
            Vector3 playerScale = new Vector3(-0.01f, -0.01f, 0f);
            playerTransition.transform.localScale += playerScale * shrinkSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private void MoveTransition()
    {
        playerTransition.transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * moveSpeed);
    }

    IEnumerator WaitOneSecondLoadNextScene()
    {
        yield return new WaitForSeconds(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
