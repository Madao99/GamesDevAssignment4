using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioClip GameIntro;
    private AudioClip GhostNormal;
    
    
    void Start()
    {
        GameIntro = Resources.Load<AudioClip>("Audio/GameIntro");
        GhostNormal = Resources.Load<AudioClip>("Audio/GhostNormal");
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
