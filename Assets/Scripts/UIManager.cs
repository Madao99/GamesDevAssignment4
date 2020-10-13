using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    Button quitBtn;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    
    void Update()
    {
        
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
