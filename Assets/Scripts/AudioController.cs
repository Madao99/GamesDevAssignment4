using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip GameIntro;
    public AudioClip GhostNormal;
    
    
    void Start()
    {
        StartCoroutine(playMusic());
    }

    
    void Update()
    {
        
    }

    IEnumerator playMusic()
    {
        GetComponent<AudioSource>().clip = GameIntro;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 0.6f;
        yield return new WaitForSeconds(GameIntro.length);
        GetComponent<AudioSource>().clip = GhostNormal;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
    }
}
