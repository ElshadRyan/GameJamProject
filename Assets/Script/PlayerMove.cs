using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed;
    private float moveSpeed = 1;
    private bool inputMovementX = false;
    private bool inputMovementY = false;





    private void Update()
    {
        PlayerMovement();
    }

    
    private void PlayerMovement()
    {
        Vector2 inputVector = new Vector2(0, 0);
        inputMovementX = false;
        inputMovementY = false;

        if (Input.GetKeyDown(KeyCode.W))
        {
            inputVector.x = +1;
            inputMovementX = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            inputVector.y = 1;
            inputMovementY = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inputVector.x = -1;
            inputMovementX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            inputVector.y = -1;
            inputMovementY = true;
        }

        if (inputMovementX && inputMovementY)
        {
            inputVector = new Vector2(0, 0);
        }
        
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection;
        transform.forward = moveDirection;
        
        
        
    }

}

    

