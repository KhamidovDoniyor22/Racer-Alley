using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour
{
    public static UIMenuManager Instance;

    private int _recordScore;
    private int _recordTime;
    private int _coinsFromGame;
    [HideInInspector]
    public int Coins;

    [Header("Texts")]
    [SerializeField] private Text _recordScoreText;
    [SerializeField] private Text _recordTimeText;
    [SerializeField] private Text[] _coinsText;

    [Header("MenuPanels")]
    [SerializeField] private GameObject[] _panels;

    private void Awake()
    {
        if(Instance == null)
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
        SaveCheck();
    }
    private void SaveCheck()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            Coins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            Coins = 0;
            PlayerPrefs.SetInt("Coins", Coins);
        }
        if (PlayerPrefs.HasKey("BestScore"))
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

        if (PlayerPrefs.HasKey("GameCoin"))
        {
            _coinsFromGame = PlayerPrefs.GetInt("GameCoin");
            Coins += _coinsFromGame;
            PlayerPrefs.SetInt("Coins", Coins);
            PlayerPrefs.DeleteKey("GameCoin");
        }
        else
        {
            _coinsFromGame = 0;
            PlayerPrefs.SetInt("GameCoin", _coinsFromGame);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        _recordScoreText.text = _recordScore.ToString();

        int minutes = Mathf.FloorToInt(_recordTime / 60);
        int seconds = Mathf.FloorToInt(_recordTime % 60);
        _recordTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        for (int i = 0; i < _coinsText.Length; i++)
        {
            _coinsText[i].text = Coins.ToString();
        }
    }

    public void OpenPanel(int panelIndex)
    {
        AudioManager.Instance.ButtonPressSound();
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
        _panels[panelIndex].SetActive(true);
    }
    public void ClosePanels()
    {
        AudioManager.Instance.ButtonPressSound();
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
        _panels[0].SetActive(true);
    }
    public void CoinPlus(int coin)
    {
        Coins += coin;
        PlayerPrefs.SetInt("Coins", Coins);
        UpdateUI();
    }
    public void CoinMinus(int coin)
    {
        Coins -= coin;
        PlayerPrefs.SetInt("Coins", Coins);
        UpdateUI();
    }
}
