using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    private int lastCarChosedIndex;

    [SerializeField] private GameObject[] _carToSpawn;
    [SerializeField] private Transform _pointToSpawn;

    private void Awake()
    {
        lastCarChosedIndex = PlayerPrefs.GetInt("LastChosedCar", lastCarChosedIndex);
    }
    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        Instantiate(_carToSpawn[lastCarChosedIndex], _pointToSpawn.transform.position, Quaternion.identity);
    }
}
