using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _soundSource;

    [Header("Sounds")]
    [SerializeField] private AudioClip _coinCollectSound;
    [SerializeField] private AudioClip _buttonPressedSound;
    [SerializeField] private AudioClip _collisionSound;

    private void Start()
    {
        Instance = this;
    }
    public void CoinSound()
    {
        _soundSource.PlayOneShot(_coinCollectSound);
    }
    public void ButtonPressSound()
    {
        _soundSource.PlayOneShot(_buttonPressedSound);
    }
    public void CollionSound()
    {
        _soundSource.PlayOneShot(_buttonPressedSound);
    }
}
