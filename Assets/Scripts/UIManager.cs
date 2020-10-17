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
    public static string score;



    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {
        scoreTxt.text = score;
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
