using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState{
    Intro,

    Playing,

    Dead
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State = GameState.Intro;

    public float PlayStartTime;

    public int Lives = 3;


    [Header("References")]
    public GameObject IntroUI;
    public GameObject DeadUI;
    public GameObject EnemySpawner;
    public GameObject FoodSpawner;
    public GameObject GoldenSpawner;

    public Player PlayerScript;

    public TMP_Text scoreText;
    
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IntroUI.SetActive(true);
    }

    float CalculateScore()
    {
        return Time.time - PlayStartTime;
    }

    void SaveHighScore()
    {
        int score = Mathf.FloorToInt(CalculateScore());
        int currentHighScore = PlayerPrefs.GetInt("highScore");
        if(score > currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }

    int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update()
    {
        if(State == GameState.Playing)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(CalculateScore());
        }
        else if(State == GameState.Dead)
        {
            scoreText.text = "High Score: " + GetHighScore();
        }
        if(State == GameState.Intro && Input.GetKeyDown(KeyCode.Space))
        {
            State = GameState.Playing;
            IntroUI.SetActive(false);
            EnemySpawner.SetActive(true);
            FoodSpawner.SetActive(true);
            GoldenSpawner.SetActive(true);
            PlayStartTime = Time.time;
        }
        if(State == GameState.Playing && Lives == 0)
        {
            PlayerScript.KillPlayer();
            SaveHighScore();
            EnemySpawner.SetActive(false);
            FoodSpawner.SetActive(false);
            GoldenSpawner.SetActive(false);
            DeadUI.SetActive(true);
            State = GameState.Dead;
        }
        if(State == GameState.Dead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("main");
        }
    }
}
