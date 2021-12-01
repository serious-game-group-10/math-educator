using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistMusic : MonoBehaviour
{
    [SerializeField] AudioSource tutorialMusic;

    // Start is called before the first frame update
    void Start()
    {
        tutorialMusic = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic());
        DontDestroyOnLoad(this.gameObject);
    }

    IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(1);
        tutorialMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetSceneByName("BossBattle");
        Scene currentScene = SceneManager.GetActiveScene();
        if (scene.name == currentScene.name)
        {
            Destroy(this.gameObject);
        }
    }
}
