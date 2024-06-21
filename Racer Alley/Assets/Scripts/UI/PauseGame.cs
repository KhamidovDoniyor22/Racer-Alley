using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _pausePanel;
    private bool _isSetting;
    public void RestartLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void SettingButton()
    {
        _settingPanel.SetActive(true);
    }
    public void PlayButton()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
