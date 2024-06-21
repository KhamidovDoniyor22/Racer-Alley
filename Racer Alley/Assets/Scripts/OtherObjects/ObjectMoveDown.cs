using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveDown : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    private void Update()
    {
        Move(_speed);
    }
    public void Move(float speed)
    {
        Vector2 newPosition = transform.position;
        newPosition.y -= speed * Time.deltaTime;

        transform.position = newPosition;
    }
}
