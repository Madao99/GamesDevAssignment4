using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip GhostScared;
    public AudioClip GhostNormal;
    public AudioClip GhostDead;
    private UIManager gameUI;
    private bool isPlaying;
    
    
    void Start()
    {
        gameUI = GameObject.Find("MapLoader").GetComponent<UIManager>();
        isPlaying = false;
        
    }

    
    void Update()
    {
        if (gameUI.countdownTxt.text == "GO!!" && isPlaying == false)
        {
            isPlaying = true;
            StartCoroutine(playMusic());
        }
    }

    IEnumerator playMusic()
    {
        
        GetComponent<AudioSource>().clip = GhostNormal;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().volume = 0.35f;
        yield return new WaitForSeconds(0);
    }


}
