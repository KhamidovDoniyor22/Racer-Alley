using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampRotationChecker : MonoBehaviour
{
    [SerializeField] private int _firstAngle;
    [SerializeField] private int _secondAngle;
    private void Start()
    {
        if(transform.position.x > 0)
        {
            RotateForCoordinateY(_firstAngle);
        }
        else if(transform.position.x < 0)
        {
            RotateForCoordinateY(_secondAngle);
        }
    }
    private void RotateForCoordinateY(float rotationAngle)
    {
        Vector3 currentEulerAngles = transform.eulerAngles;
        currentEulerAngles.y = rotationAngle;
        transform.eulerAngles = currentEulerAngles;
    }
}
