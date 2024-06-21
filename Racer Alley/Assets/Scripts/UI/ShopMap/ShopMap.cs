using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMap : MonoBehaviour
{
    [SerializeField] private GameObject _levelBuyPanel;

    [SerializeField] private Text _priceText;

    private int _levelIndex;

    private bool _isSecondMapChoosed;
    private bool _isThirdMapChoosed;

    private void Update()
    {
        if(_isSecondMapChoosed)
        {
            _priceText.text = "Open for 300";
        }
        if(_isThirdMapChoosed)
        {
            _priceText.text = "Open for 400";
        }
    }
    public void ChooseTheMap(int levelIndex)
    {
        _levelIndex = levelIndex;

        switch(_levelIndex)
        {
            case 2: LevelLoad(levelIndex); break;
            case 3: CheckTheMap(levelIndex, "SecondMap"); BoolController(true, false); break;
            case 4: CheckTheMap(levelIndex, "ThirdMap"); BoolController(false, true); break;
        }
    }
    private void LevelLoad(int mapIndex)
    {
        SceneManager.LoadScene(mapIndex);
    }
    private void CheckTheMap(int mapIndex, string mapKey)
    {
        if(PlayerPrefs.HasKey(mapKey))
        {
            LevelLoad(mapIndex);
        }
        else
        {
            _levelBuyPanel.SetActive(true);
        }
    }
    private void BoolController(bool first, bool second)
    {
        _isSecondMapChoosed = first;
        _isThirdMapChoosed = second;
    }
    public void BuyMap()
    {
        if (_isSecondMapChoosed)
        {
            if(UIMenuManager.Instance.Coins >= 300)
            {
                //minus coins
                string mapName = "SecondMap";
                PlayerPrefs.SetString("SecondMap", mapName);
                LevelLoad(3);
                UIMenuManager.Instance.CoinMinus(300);
            }
            
        }
        if (_isThirdMapChoosed)
        {
            if(UIMenuManager.Instance.Coins >= 400)
            {
                //minus coins
                string mapName = "ThirdMap";
                PlayerPrefs.SetString("ThirdMap", mapName);
                LevelLoad(4);
                UIMenuManager.Instance.CoinMinus(400);
            }
           
        }
    }
}
