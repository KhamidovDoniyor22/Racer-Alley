using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawn : MonoBehaviour
{
    [Header("Object For Spawn")]
    [SerializeField] private GameObject[] _objectCollection;
    [SerializeField] private GameObject[] _levelEnvObject;

    [Space]
    [Header("Points For Spawn")]
    [SerializeField] private Transform[] _objectCollectionPoint;
    [SerializeField] private Transform[] _levelEnvObjectPoint;

    private float delay;

    private bool _isGameStarted = false;

    private void Update()
    {
        if(UIGameManager.Instance.IsGameStarted && !_isGameStarted)
        {
            //SpawnForInGameObjects
            StartCoroutine(SpawnSystem(_objectCollection, _objectCollectionPoint, 1, 4));

            //SpawnEnvObjects
            StartCoroutine(SpawnSystem(_levelEnvObject, _levelEnvObjectPoint, 1, 3));
            _isGameStarted = true
;        }
    }
    private IEnumerator SpawnSystem(GameObject[] objectCollection, Transform[] spawnPoint, int num1, int num2)
    {
        while (UIGameManager.Instance.IsGameStarted)
        {
            int randomNumberForObj = Random.Range(0, objectCollection.Length);
            int randomNumberForPoint = Random.Range(0, spawnPoint.Length);

            yield return new WaitForSeconds(delay);
            Instantiate(objectCollection[randomNumberForObj], spawnPoint[randomNumberForPoint].transform.position, Quaternion.identity);

            //delay = Random.Range(1, 4f);
            RandomNum(num1, num2);
        }
    }
    private void RandomNum(int num1, int num2)
    {
        delay = Random.Range(num1, num2);
    }
}
