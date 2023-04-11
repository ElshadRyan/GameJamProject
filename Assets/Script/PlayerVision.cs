using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private PlayerMove playerMove;

    private void Update()
    {
        Collide();
    }

    private void Collide()
    {
        bool canMove = !Physics.BoxCast(playerTransform.transform.position, transform.localScale, Vector3.forward);

        if (!CanMove)
        {
            Vector3 MoveDirectionX = new Vector3(MoveDirection.x, 0, 0).normalized;
            CanMove = MoveDirection.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PlayerHeight, PlayerRadius, MoveDirectionX, MoveDistance);

            if (CanMove)
            {
                MoveDirection = MoveDirectionX;
            }
            else
            {
                Vector3 MoveDirectionZ = new Vector3(0, 0, MoveDirection.z).normalized;
                CanMove = MoveDirection.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PlayerHeight, PlayerRadius, MoveDirectionZ, MoveDistance);

                if (CanMove)
                {
                    MoveDirection = MoveDirectionZ;
                }
            }
        }
    }
}
