using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    [Header("Play/Select Buttons")]
    [SerializeField] private GameObject[] _buyButton;
    [SerializeField] private Image[] _selectButton;
    [SerializeField] private Text[] _selectedBtnText;

    [SerializeField] private Sprite _selectedCarSprite;
    [SerializeField] private Sprite _selectCarSprite;

    [Header("Car Attributes")]
    [SerializeField] private int[] carPrices;
    [SerializeField] private int[] currentCar;
    private int _lastSelectedCar;

    private const string _selectedString = "Selected";
    private const string _selectString = "Select";

    private void Start()
    {
        UpdatePurchases();
        SelectedCarCheck();
    }
    private void UpdatePurchases()
    {
        for(int i = 0; i < currentCar.Length; i++)
        {
            //If current car unlocked show the select button
            if (CarSaveManager.instance.carsUnlocked[currentCar[i]])
            {
                _buyButton[i].SetActive(false);
                _selectButton[i].gameObject.SetActive(true);
            }
        }
    }

    public void BuyCar(int selectedCar)
    {
        if(UIMenuManager.Instance.Coins >= carPrices[selectedCar])
        {
            currentCar[selectedCar] = selectedCar;

            CarSaveManager.instance.carsUnlocked[currentCar[selectedCar]] = true;
            CarSaveManager.instance.Save();
            Debug.Log(selectedCar + " Bought");
            _buyButton[currentCar[selectedCar]].SetActive(false);
            _selectButton[currentCar[selectedCar]].gameObject.SetActive(true);
            UIMenuManager.Instance.CoinMinus(carPrices[selectedCar]);

        }
       
    }
    public void SelectCar(int carIndex)
    {
        DisactiveSelectedButtons(carIndex);
        PlayerPrefs.SetInt("LastChosedCar", carIndex);
        _selectButton[carIndex].sprite = _selectedCarSprite;
        _selectedBtnText[carIndex].text = _selectedString;
    }
    private void SelectedCarCheck()
    {
        if(PlayerPrefs.HasKey("LastChosedCar"))
        {
            DisactiveSelectedButtons(_selectButton.Length);
            _lastSelectedCar = PlayerPrefs.GetInt("LastChosedCar", _lastSelectedCar);
            _selectButton[_lastSelectedCar].sprite = _selectedCarSprite;
            _selectedBtnText[_lastSelectedCar].text = _selectedString;
        }
        else
        {
            SelectCar(0);
        }
    }
    private void DisactiveSelectedButtons(int carIndex)
    {
        for (int i = 0; i < _selectButton.Length; i++)
        {
            _selectButton[i].sprite = _selectCarSprite;
            _selectedBtnText[i].text = _selectString;
        }
    }
}
