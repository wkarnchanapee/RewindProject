using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour {

    [SerializeField] float moveSpd;
    [SerializeField] float jumpSpd;
    float h, v;
    //bool isGrounded = false;
    Vector3 moveDirection;
    CharacterController charCtrl;
    [SerializeField] float gravity = 8f;
    [SerializeField] BooleanVariable isPaused;

    private void Awake()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (isPaused.Value == false)
        {
            // Get Input
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            // Check Gravity
            if (charCtrl.isGrounded == true)
            {
                moveDirection = new Vector3(h, 0, v);
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpd;

                }
            }
            else
            {
                // Check if something is above the player, and if true reset up velocity.
                if (charCtrl.collisionFlags == CollisionFlags.Above)
                {
                    moveDirection.y = 0f;
                }
                moveDirection.x = h;
                moveDirection.z = v;
                moveDirection.y -= gravity * Time.deltaTime;
            }

            //  Apply movement

            moveDirection.x *= moveSpd;
            moveDirection.z *= moveSpd;
            moveDirection = transform.TransformDirection(moveDirection);
            charCtrl.Move(moveDirection * Time.deltaTime);
        }
        
    }
}
