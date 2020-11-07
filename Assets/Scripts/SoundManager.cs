using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip normalMusic, reverseMusic, itemMusic, obsMusic, clickMusic;

    AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "normalMusic":
                audioSrc.PlayOneShot(normalMusic);
                break;

            case "reverseMusic":
                audioSrc.PlayOneShot(reverseMusic);
                break;

            case "itemMusic":
                audioSrc.PlayOneShot(itemMusic);
                break;

            case "obsMusic":
                audioSrc.PlayOneShot(obsMusic);
                break;

            case "clickMusic":
                audioSrc.PlayOneShot(clickMusic);
                break;

        }
    }
}
