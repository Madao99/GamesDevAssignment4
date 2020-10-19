using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    Button quitBtn;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI ghostTimerTxt;
    public static string score;
    public float ghostTimer;



    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ghostTimerTxt.GetComponent<TextMeshProUGUI>().enabled = false;
        ghostTimer = 10f;
    }

    
    void Update()
    {
        if(scoreTxt != null)
            scoreTxt.text = score;

        if(ghostTimerTxt.GetComponent<TextMeshProUGUI>().enabled == true)
        {           
            ghostTimer -= Time.deltaTime;
            ghostTimerTxt.text = "Ghost Timer: " + Mathf.Round(ghostTimer).ToString();
            if(Mathf.Round(ghostTimer) == 0)
            {
                ghostTimerTxt.GetComponent<TextMeshProUGUI>().enabled = false;
                
            }
        }
    }

    public float GetGhostTimer()
    {
        return ghostTimer;
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 1)
        {
            GameObject.FindGameObjectWithTag("QuitBtn").GetComponent<Button>().onClick.AddListener(LoadStartScene); 
        }
    }
}
