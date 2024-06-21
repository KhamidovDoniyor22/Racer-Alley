using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScripts : MonoBehaviour
{
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;

    private int _soundVolume;
    private int _musicVolume;

    private bool _isSound;
    private bool _isMusic;

    [SerializeField] private Text _soundText;
    [SerializeField] private Text _musicText;

    [SerializeField] private Image _soundImage;
    [SerializeField] private Image _musicImage;

    [SerializeField] private Sprite[] _soundSprite;
    [SerializeField] private Sprite[] _musicSprite;

    private const string _on = "On";
    private const string _off = "Off";

    private void Awake()
    {
        SoundMusicSaveChecks();
    }
    private void Start()
    {
        VolumeChecker();
    }
    public void SoundButton()
    {
        _isSound = !_isSound;
        SoundCheck();
       
    }
    private void SoundCheck()
    {
        if (_isSound)
        {
            _soundVolume = 1;
            PlayerPrefs.SetInt("Sound", _soundVolume);
            _soundSource.volume = _soundVolume;
            _soundImage.sprite = _soundSprite[_soundVolume];
            _soundText.text = _on;
        }
        else
        {
            _soundVolume = 0;
            PlayerPrefs.SetInt("Sound", _soundVolume);
            _soundSource.volume = _soundVolume;
            _soundImage.sprite = _soundSprite[_soundVolume];
            _soundText.text = _off;
        }
    }
    public void MusicButton()
    {
        _isMusic = !_isMusic;
        MusicCheck();
    }
    private void MusicCheck()
    {
        if (_isMusic)
        {
            _musicVolume = 1;
            PlayerPrefs.SetInt("Music", _musicVolume);
            _musicSource.volume = _musicVolume;
            _musicImage.sprite = _musicSprite[_musicVolume];
            _musicText.text = _on;
        }
        else
        {
            _musicVolume = 0;
            PlayerPrefs.SetInt("Music", _musicVolume);
            _musicSource.volume = _musicVolume;
            _musicImage.sprite = _musicSprite[_musicVolume];
            _musicText.text = _off;
        }
    }
    private void SoundMusicSaveChecks()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            _soundVolume = PlayerPrefs.GetInt("Sound", _soundVolume);
            _soundSource.volume = _soundVolume;
        }
        else
        {
            _soundVolume = 1;
            _isSound = true;
            PlayerPrefs.SetInt("Sound", _soundVolume);
        }

        if (PlayerPrefs.HasKey("Music"))
        {
            _musicVolume = PlayerPrefs.GetInt("Music", _musicVolume);
            _musicSource.volume = _musicVolume;
        }
        else
        {
            _musicVolume = 1;
            _isMusic = true;
            PlayerPrefs.SetInt("Music", _musicVolume);
        }
    }
    private void VolumeChecker() 
    { 
        // Sound Volume Checker
        if(_soundVolume == 1)
        {
           
            _soundImage.sprite = _soundSprite[_soundVolume];
            _soundText.text = _on;
            _isSound = true;
        }
        if(_soundVolume == 0)
        {
           
            _soundImage.sprite = _soundSprite[_soundVolume];
            _soundText.text = _off;
            _isSound = false;
        }
        // Music Volume Checker
        if (_musicVolume == 1)
        {
           
            _musicImage.sprite = _musicSprite[_musicVolume];
            _musicText.text = _on;
            _isMusic = true;
        }
        if (_musicVolume == 0)
        {
            
            _musicImage.sprite = _musicSprite[_musicVolume];
            _musicText.text = _off;
            _isMusic = false;   
        }
    }

    //Privacy Policy
    public void PrivacyPolicyOpenBtn()
    {
        Application.OpenURL("https://docs.google.com/document/d/1_vA9kAX_fjOpYPPR8pFbayDcT95BKnKMCJTm-dyKlJQ/edit?usp=sharing");
    }
    //TermsOfUse
    public void TermsOfUseBtn()
    {
        Application.OpenURL("https://docs.google.com/document/d/1tI4uMGNWULENdvkjgRW1Rdzvq4OB9pLHZlBtIjSD8hE/edit?usp=sharing");
    }
    //SupportForm
    public void SupportFormBtn()
    {
        Application.OpenURL("https://sites.google.com/view/racer-alley/support-form");
    }
}
