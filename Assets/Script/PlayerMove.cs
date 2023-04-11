using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed;
    private float moveSpeed = 1;
    private bool Diagonal = true;





    private void Update()
    {
        PlayerMovement();
    }

    
    private void PlayerMovement()
    {
        Vector2 inputVector = new Vector2(0, 0);
        //Diagonal = true;


        if (Input.GetKeyDown(KeyCode.W) && Diagonal)
        {
            inputVector.x = +moveSpeed;
            Diagonal = false;
            transform.LookAt(transform.position + new Vector3(0, 0, 1));
        }
        if (Input.GetKeyDown(KeyCode.A) && Diagonal)
        {
            inputVector.y = +moveSpeed;
            Diagonal = false;
            transform.LookAt(transform.position + new Vector3(-1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.S) && Diagonal)
        {
            inputVector.x = -moveSpeed;     
            Diagonal = false;
            transform.LookAt(transform.position + new Vector3(0, 0, -1));
        }
        if (Input.GetKeyDown(KeyCode.D) && Diagonal)
        {
            inputVector.y = -moveSpeed;
            Diagonal = false;
            transform.LookAt(transform.position + new Vector3(1, 0, 0));
        }



        if (Input.GetKeyUp(KeyCode.W))
        {
            Diagonal = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Diagonal = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Diagonal = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Diagonal = true;
        }

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection;
        
       
    }

}

    

