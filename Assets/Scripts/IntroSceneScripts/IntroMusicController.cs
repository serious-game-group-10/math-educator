using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusicController : MonoBehaviour
{
    private AudioSource introSceneMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (introSceneMusic == null)
        {
            introSceneMusic = GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(introSceneMusic.clip, transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
