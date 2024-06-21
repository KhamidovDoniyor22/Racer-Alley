using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] private Renderer _meshRenderer;

    [SerializeField] public float _speed;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if(UIGameManager.Instance.IsGameStarted)
        {
            _meshRenderer.material.mainTextureOffset += new Vector2(0, _speed * Time.deltaTime);
        }   
    }
}
