using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour
{
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _selectButton;

    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private Text _loadingText;

    private const string blueCarKey = "blue_car";
 
    private void Start()
    {
        if(PlayerPrefs.HasKey(blueCarKey))
        {
            _buyButton.SetActive(false);
            _selectButton.SetActive(true);
        }
    }
    public void OnPurchaseComplete(Product product)
    {
        switch(product.definition.id)
        {
            case blueCarKey:
                BuyBlueCar();
                break;
        }
    }
    private void BuyBlueCar()
    {
        PlayerPrefs.SetInt(blueCarKey, 1);
        Debug.Log(blueCarKey);
        _buyButton.SetActive(false);
        _selectButton.SetActive(true);
    }
    public void OpenLoader()
    {
        _loadingPanel.SetActive(true);
        _loadingText.text = "Loading...";
    }

    public void CloseLoaderCompleted()
    {
        _loadingText.text = "Completed";
        Invoke(nameof(CloseInvoked), 2f);
    }
    public void CloseLoaderFailed()
    {
        _loadingText.text = "Failed";
        Invoke(nameof(CloseInvoked), 2f);
    }

    private void CloseInvoked()
    {
        _loadingPanel.SetActive(false);
    }
  
}
