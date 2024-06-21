using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameManager : MonoBehaviour
{
    public static UIGameManager Instance;

    [Header("Start Panel Settings")]
    public bool IsGameStarted = false;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private Text _startText;
    private int _startTimer = 3;

    [Space]
    [Header("Score Settings")]
    [SerializeField] private Text _scoreText;
    private int _score;
    private int _recordScore;

    [Space]
    [Header("Health Setiings")]
    [SerializeField] private Image[] _heart;
    private int _healthRate = 3;

    [Space]
    [Header("Time Setiings")]
    [SerializeField] private Text _timerText;
    private int _timer;
    private int _recordTime;

    [Space]
    [Header("Coin Setiings")]
    [SerializeField] private Text _coinText;
    private int _coinNumber;

    [Space]
    [Header("Lose Setiings")]
    [SerializeField] private GameObject _losePanel;

    [Space]
    [Header("Settings")]
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private Text _scoreLoseText;
    [SerializeField] private Text _timerLoseText;
    [SerializeField] private Text _coinLoseText;
    [SerializeField] private GameObject _pausePanel;

    private bool isGameOver = false;
    private bool _isPaused = false;

    private bool isGame = false;


    private void Awake()
    {
        if(gameObject != null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SavesChecker();
        StartSystem();
    }
    private void FixedUpdate()
    {
        if(IsGameStarted && !isGame)
        {
            Score();
            Timer();
            isGame = true;      
        }
        if(!isGameOver)
        {
            LoseChecker();
        }  

    }
    #region StartPanel
    private void StartSystem()
    {
        StartCoroutine(IStartSystem());
    }
    private IEnumerator IStartSystem()
    {
        while(!IsGameStarted)
        {
            yield return new WaitForSeconds(1f);
            _startTimer -= 1;
            _startText.text = _startTimer.ToString();

            if(_startTimer - 1 == 0)
            {
                yield return new WaitForSeconds(1f);
                _startText.text = "Start";
                _startPanel.SetActive(false);
                IsGameStarted = true;
            }
        }
    }
    #endregion

    #region ScoreSystem
    public void Score()
    {
        StartCoroutine(IScore()); 
    }
    private IEnumerator IScore()
    {
        while(true)
        {
            _score += 1;
            _scoreText.text = "Score: " + _score.ToString();
            yield return new WaitForSeconds(0.5f);
        }
    }
    #endregion

    #region HealthRegion
    public void HealthLose()
    {
        _healthRate -= 1;

        for (int j = 0; j < 3; j++)
        {

            _heart[j].gameObject.SetActive(false);
        }
        for (int i = 0; i < _healthRate; i++)
        {
            
            _heart[i].gameObject.SetActive(true);
        }
    }
    #endregion

    #region LoseChecker
    private void LoseChecker()
    {
        if(_healthRate <= 0)
        {
            _losePanel.SetActive(true);
            _scoreLoseText.text = _score.ToString();
            _coinLoseText.text = _coinNumber.ToString();
            int minutes = Mathf.FloorToInt(_timer / 60);
            int seconds = Mathf.FloorToInt(_timer % 60);
            _timerLoseText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            SaveSystem();
            isGameOver = true;
            Time.timeScale = 0;
        }
    }
    #endregion

    #region Timer
    public void Timer()
    {
        StartCoroutine(ITimer());
    }
    private IEnumerator ITimer()
    {
        while(true)
        {
            _timer += 1;
            TimerSystem();
            yield return new WaitForSeconds(1f);
        }
    }
    private void TimerSystem()
    {
        int minutes = Mathf.FloorToInt(_timer / 60);
        int seconds = Mathf.FloorToInt(_timer % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    #endregion

    #region CoinSystem
    public void CoinPlus()
    {
        _coinNumber += 1;
        _coinText.text = _coinNumber.ToString();
        PlayerPrefs.SetInt("GameCoin", _coinNumber);
    }
    #endregion

    #region PauseSystem
    public void PauseGame(int timeScale)
    {
        Time.timeScale = timeScale;
        _pausePanel.SetActive(true);

        //if(isGameOver)
        //{
        //    _losePanel.SetActive(!_isPaused);
        //    Time.timeScale = 0;
        //}
    }
    #endregion

    public void RestartLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1;
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    private void SavesChecker()
    {
        if(PlayerPrefs.HasKey("BestScore"))
        {
            _recordScore = PlayerPrefs.GetInt("BestScore", _recordScore);
        }
        else
        {
            _recordScore = 0;
            PlayerPrefs.SetInt("BestScore", _recordScore);
        }

        if (PlayerPrefs.HasKey("BestTime"))
        {
            _recordTime = PlayerPrefs.GetInt("BestTime");
        }
        else
        {
            _recordTime = 0;
            PlayerPrefs.SetInt("BestTime", _recordTime);
        }
    }
    private void  SaveSystem()
    {
        if(_score > _recordScore)
        {
            _recordScore = _score;
            PlayerPrefs.SetInt("BestScore", _recordScore);
        }
        if(_timer > _recordTime)
        {
            _recordTime = _timer;
            PlayerPrefs.SetInt("BestTime", _recordTime);
        }
    }
}
