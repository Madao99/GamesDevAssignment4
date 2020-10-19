using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip GhostScared;
    public AudioClip GhostNormal;
    public AudioClip GhostDead;

    
    
    void Start()
    {
        StartCoroutine(playMusic());
    }

    
    void Update()
    {
        
    }

    IEnumerator playMusic()
    {
        
        GetComponent<AudioSource>().clip = GhostNormal;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
        yield return new WaitForSeconds(0);
    }


}
