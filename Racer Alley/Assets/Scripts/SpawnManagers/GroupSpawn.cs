using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSpawn : MonoBehaviour
{
    private float _delay = 3f;

    [SerializeField] private GameObject _crossWalkObject;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnSystem());
    }
    private IEnumerator SpawnSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Instantiate(_crossWalkObject, _spawnPoint.transform.position, Quaternion.identity);        
        }
    }
}
