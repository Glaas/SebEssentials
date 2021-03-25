using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class IsometricController : MonoBehaviour
{
    public float walkSpeed = 4f;
    public Vector3 forward, right;
    CharacterController characterController;
    private Camera _camera;


    void Start()
    {
        _camera = Camera.main;
        characterController = GetComponent<CharacterController>();
        RecalculateCameraAxis();
    }

    void Update()
    {
        RecalculateCameraAxis();
        
        // Movement
        if (Input.anyKey)
        {
            Move();
        }
    }

    private void RecalculateCameraAxis()
    {
        forward = _camera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        
        // -45 degrees from the world x axis
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Move()
    {
        // Movement speed
        Vector3 rightMovement = right * walkSpeed * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * walkSpeed * Input.GetAxis("Vertical");

        // Calculate what is forward
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        // Set new position
        Vector3 newPosition = transform.position;
        newPosition += rightMovement;
        newPosition += upMovement;

        // Smoothly move the new position
        transform.forward = heading;
        //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed *= 10;
        }

        characterController.Move(heading * walkSpeed);
    }
}