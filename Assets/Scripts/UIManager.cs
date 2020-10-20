using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR.WSA.Input;

public class UIManager : MonoBehaviour
{
    Button quitBtn;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI ghostTimerTxt;
    public TextMeshProUGUI gameTimeTxt;
    public TextMeshProUGUI countdownTxt;
    private string gameTimeText;
    private int countdown;
    public static string score;
    public float ghostTimer;
    public GameObject[] lives = new GameObject[3];
    public static int lifeNumber = 3;
    private float minutes, seconds, milliseconds;
    GameObject life1;
    GameObject life2;
    GameObject life3;
    private bool started;



    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (ghostTimerTxt != null)
        {
            ghostTimerTxt.GetComponent<TextMeshProUGUI>().enabled = false;
        }
        ghostTimer = 10f;
    }

    
    void Update()
    {
        if(started == false)
        {
            started = true;
            StartCoroutine(LevelCountdown());
        }
        GameTimer();
        if(scoreTxt != null)
            scoreTxt.text = score;

        if(ghostTimerTxt != null && ghostTimerTxt.GetComponent<TextMeshProUGUI>().enabled == true)
        {           
            ghostTimer -= Time.deltaTime;
            ghostTimerTxt.text = "Ghost Timer: " + Mathf.Round(ghostTimer).ToString();
            if(Mathf.Round(ghostTimer) == 0)
            {
                ghostTimerTxt.GetComponent<TextMeshProUGUI>().enabled = false;
                
            }
        }

        if(lifeNumber == 2 && life3 != null)
        {
            life3.GetComponent<Image>().enabled = false;
        }
        if (lifeNumber == 1 && life2 != null)
        {
            life2.GetComponent<Image>().enabled = false;
        }
        if (lifeNumber == 0 && life1 != null)
        {
            life1.GetComponent<Image>().enabled = false;
        }
    }

    void GameTimer()
    {
        minutes = (int)(Time.timeSinceLevelLoad / 60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        milliseconds = (int)(Time.timeSinceLevelLoad * 100);
        milliseconds = milliseconds % 100;
        gameTimeText = "Game Time: " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        gameTimeTxt.text = gameTimeText;
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
            //StartCoroutine(LevelCountdown());
            GameObject.FindGameObjectWithTag("QuitBtn").GetComponent<Button>().onClick.AddListener(LoadStartScene);
            life1 = Instantiate(lives[0], GameObject.Find("HUD").transform);
            life2 = Instantiate(lives[1], GameObject.Find("HUD").transform);
            life3 = Instantiate(lives[2], GameObject.Find("HUD").transform);
            life3.GetComponent<Image>().enabled = true;
            lifeNumber = 3;
        }
    }

    IEnumerator LevelCountdown()
    {
        countdownTxt.enabled = true;
        countdown = 3;
        Time.timeScale = 0;
        while (countdown > 0)
        {
            countdownTxt.text = countdown.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdown--;
        }
        if (countdown == 0)
        {
            countdownTxt.text = "GO!!";
            yield return new WaitForSecondsRealtime(1f);
            Time.timeScale = 1;
            countdownTxt.enabled = false;
        }
    }
}
