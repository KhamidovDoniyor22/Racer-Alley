using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour, IMovable
{
    private float _inputHorizontal;
    private float _inputVertical;

    [SerializeField] private float _speed;

    [SerializeField] private Joystick _joystick;

    private void Start()
    {
        _joystick = FindObjectOfType<Joystick>();
    }
    private void FixedUpdate()
    {
        Move(_speed);     
    }
    public void Move(float speed)
    {
        _inputHorizontal = _joystick.Horizontal;
        _inputVertical = _joystick.Vertical;

        Vector2 movement = new Vector2(_inputHorizontal, _inputVertical);

        transform.Translate(movement * _speed * Time.deltaTime);
    }
}
