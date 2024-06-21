using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] otherPanels;
    [SerializeField] private GameObject _firstPanel;

    private void Start()
    {
        if(PlayerPrefs.HasKey("FirstOpen"))
        {
            _firstPanel.SetActive(false);
        }
        else
        {
            OpenPanel();
        }
    }
    private void OpenPanel()
    {
        for(int i = 0; i < otherPanels.Length; i++)
        {
            otherPanels[i].SetActive(false);
            _firstPanel.SetActive(true);
        }
    }
    public void HidePanel()
    {
        string firstOpen = "FirstOpen";
        PlayerPrefs.SetString("FirstOpen", firstOpen);
        _firstPanel.SetActive(false);
        otherPanels[0].SetActive(true);
    }
}
