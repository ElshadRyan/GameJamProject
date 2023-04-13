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
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector2 inputVector = new Vector2(0, 0);
        bool collider = collision.gameObject.tag == "Collision";
        Vector3 moveDirection = new Vector3(inputVector.y, 0f, inputVector.x);
        bool canMove = !Physics.BoxCast(playerTransform.position, transform.localScale, moveDirection, Quaternion.identity, moveSpeed);


        if (!canMove && collider)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0f, 0f);
            canMove = moveDirection.x != 0 && !Physics.BoxCast(playerTransform.position, transform.localScale, moveDirection, Quaternion.identity, moveSpeed);

            if (canMove && collider)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0f, 0f, moveDirection.z);
                canMove = moveDirection.z != 0 && !Physics.BoxCast(playerTransform.position, transform.localScale, moveDirectionZ, Quaternion.identity, moveSpeed);

                if (canMove && collider)
                {
                    moveDirection = moveDirectionZ;
                }
            }
        }



        if (canMove && collider)
        {
            transform.position += moveDirection;
        }
    }

}

    

