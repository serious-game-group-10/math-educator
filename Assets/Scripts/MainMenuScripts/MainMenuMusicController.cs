using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicController : MonoBehaviour
{
    [SerializeField] AudioSource menuMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (menuMusic == null)
        {
            menuMusic = GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(menuMusic.clip, transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
