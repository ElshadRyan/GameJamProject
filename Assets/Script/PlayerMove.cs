using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform playerTransform;
    private float moveSpeed = 1;





    private void Update()
    {
        PlayerMovement();
    }

    
    public void PlayerMovement()
    {
        float maxDistance = 2f;
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKeyDown(KeyCode.W))
        {
            inputVector.x = +moveSpeed;
            transform.LookAt(transform.position + new Vector3(0, 0, 1));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            inputVector.y = -moveSpeed;
            transform.LookAt(transform.position + new Vector3(-1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inputVector.x = -moveSpeed;
            transform.LookAt(transform.position + new Vector3(0, 0, -1));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            inputVector.y = +moveSpeed;
            transform.LookAt(transform.position + new Vector3(1, 0, 0));
        }
        
        Vector3 moveDirection = new Vector3(inputVector.y, 0f, inputVector.x);
        bool canMove = !Physics.BoxCast(playerTransform.position, transform.localScale, moveDirection, Quaternion.identity, moveSpeed);


        if (!canMove)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0f, 0f);
            canMove = moveDirection.x != 0 && !Physics.BoxCast(playerTransform.position, transform.localScale, moveDirection, Quaternion.identity, moveSpeed);

            if (canMove)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0f, 0f, moveDirection.z);
                canMove = moveDirection.z != 0 && !Physics.BoxCast(playerTransform.position, transform.localScale, moveDirectionZ, Quaternion.identity, moveSpeed);

                if (canMove)
                {
                    moveDirection = moveDirectionZ; 
                }
            }
        }

        

        if (canMove)
        {
             Debug.Log("bisa Move");
             transform.position += moveDirection;
       }
        Debug.Log(canMove);

    }

}

    

