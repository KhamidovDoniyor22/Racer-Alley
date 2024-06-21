using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSideMovementCheck : MonoBehaviour
{
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        SideChecker();
    }
    private void SideChecker()
    {
        if (_transform.position.x >= 1.6)
        {
            gameObject.transform.position = new Vector2(1.6f, transform.position.y);
        }
        else if (_transform.position.x <= -1.6)
        {
            gameObject.transform.position = new Vector2(-1.6f, transform.position.y);
        }

        if (_transform.position.y >= 1.6)
        {
            gameObject.transform.position = new Vector2(transform.position.x, 1.6f);
        }
        else if (_transform.position.y <= -3.9)
        {
            gameObject.transform.position = new Vector2(transform.position.x, -3.9f);
        }
    }
}
