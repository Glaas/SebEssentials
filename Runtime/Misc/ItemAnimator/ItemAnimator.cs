using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimator : MonoBehaviour
{
    public enum RotationDirection
    {
        CLOCKWISE,
        ANTICLOCKWISE
    }

    //Public, to show in inspector
    public bool isFloating, isRotating;
    public float intensity = 1, speed = 1;
    public float rotateSpeed = 2;
    public RotationDirection rotationDirection;

    //Private, just for the script to use
    private Vector3 startpos;
    
    private void Start()
    {
        startpos = transform.localPosition;
    }

    private void Update()
    {
        if (isFloating)
        {
            float time = Time.time;
            float newPos = Mathf.Sin(time * speed) * intensity;
            print("time = " + time);
            print("newpos = " + newPos);
            


            transform.localPosition = new Vector3(transform.localPosition.x,  startpos.y + newPos, transform.localPosition.z);
        }

        if (!isRotating) return;
        switch (rotationDirection)
        {
            case RotationDirection.CLOCKWISE:
                transform.Rotate(Vector3.up * (rotateSpeed * 100 * Time.deltaTime));
                break;
            case RotationDirection.ANTICLOCKWISE:
                transform.Rotate(Vector3.up * (-rotateSpeed * 100 * Time.deltaTime));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}