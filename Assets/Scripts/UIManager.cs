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
    public TextMeshProUGUI gameOverTxt;
    public Text bestTimeTxt;
    public Text bestScoreTxt;
    private int previousBestScore;
    private float previousBestTimeMins;
    private float previousBestTimeSecs;
    private float previousBestTimeMilli;
    private string gameTimeText;
    private int countdown;
    public static int score;
    public float ghostTimer;
    public GameObject[] lives = new GameObject[3];
    public static int lifeNumber = 3;
    private float minutes, seconds, milliseconds;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    private bool started;
    private bool startLoaded;
    private int lollyCount = 220;



    void Start()
    {

        //DontDestroyOnLoad(gameObject);
        if (ghostTimerTxt != null)
        {
            ghostTimerTxt.GetComponent<TextMeshProUGUI>().enabled = false;
        }
        ghostTimer = 10f;
        previousBestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreTxt.text = "Best Score: " + previousBestScore.ToString();
        previousBestTimeMins = PlayerPrefs.GetFloat("Minutes", 0);
        previousBestTimeSecs = PlayerPrefs.GetFloat("Seconds", 0);
        previousBestTimeMilli = PlayerPrefs.GetFloat("Milliseconds", 0);
        bestTimeTxt.text = "Best Time: " + previousBestTimeMins.ToString("00") + ":" + previousBestTimeSecs.ToString("00") + ":" + previousBestTimeMilli.ToString("00");
    }

    
    void Update()
    {
        if(started == false)
        {
            started = true;
            StartCoroutine(LevelCountdown());
        }

        
        if(gameTimeTxt != null)
        {
            GameTimer();
        }
        
        if(scoreTxt != null)
            scoreTxt.text = "Score: " + score.ToString();

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
        if (GameObject.Find("MapLoader") != null)
        {
            //lollyCount = GameObject.Find("MapLoader").GetComponent<LevelGenerator>().GetLollies();
            Debug.Log(lollyCount);
        }
        if (gameOverTxt != null)
        {
            if (lifeNumber == 0 || lollyCount == 0)
            {
                if (startLoaded == false)
                {
                    gameOverTxt.text = "Game Over";
                    StartCoroutine(GameOver());
                }
            }
        }
    }

    IEnumerator GameOver()
    {
        startLoaded = true;
        lifeNumber = 3;
        if(score > previousBestScore)
        {
            PlayerPrefs.SetInt("Best Score", score);
            PlayerPrefs.SetFloat("Minutes", minutes);
            PlayerPrefs.SetFloat("Seconds", seconds);
            PlayerPrefs.SetFloat("Milliseconds", milliseconds);
        }
        if(score == previousBestScore)
        {
            if(minutes < previousBestTimeMins)
            {
                PlayerPrefs.SetInt("Best Score", score);
                PlayerPrefs.SetFloat("Minutes", minutes);
                PlayerPrefs.SetFloat("Seconds", seconds);
                PlayerPrefs.SetFloat("Milliseconds", milliseconds);
            }
            else if(minutes == previousBestTimeMins && seconds < previousBestTimeSecs)
            {
                PlayerPrefs.SetInt("Best Score", score);
                PlayerPrefs.SetFloat("Minutes", minutes);
                PlayerPrefs.SetFloat("Seconds", seconds);
                PlayerPrefs.SetFloat("Milliseconds", milliseconds);
            }
        }
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3.0f);
        Time.timeScale = 1;
        LoadStartScene();
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
            /*if (life1 == null)
            {
                life1 = Instantiate(lives[0], GameObject.Find("HUD").transform);
            }
            if (life2 == null)
            {
                life2 = Instantiate(lives[1], GameObject.Find("HUD").transform);
            }
            if (life3 == null)
            {
                life3 = Instantiate(lives[2], GameObject.Find("HUD").transform);
            }*/
            if (life3 != null)
            {
                life3.GetComponent<Image>().enabled = true;
            }
            if (life2 != null)
            {
                life2.GetComponent<Image>().enabled = true;
            }
            if (life1 != null)
            {
                life1.GetComponent<Image>().enabled = true;
            }
            gameOverTxt.text = "";
            lifeNumber = 3;
            startLoaded = false;
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

    public void SetLollyCount(int number)
    {
        lollyCount = number;
    }

    public int GetLollyCount()
    {
        return lollyCount;
    }
}
