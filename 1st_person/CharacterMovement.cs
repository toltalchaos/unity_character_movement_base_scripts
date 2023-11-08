using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController movement_controller;
    public float player_speed = 15f;
    public float gravity = -9.81f;
    public float jump_height = 5f;
    public float ground_distance = 0.4f;
    public Transform ground_probe; //the transform object used to calculate the grounded nature
    public LayerMask groundMask; //layer that is tagged to the ground


    Vector3 velocity; //our vector object used to move our character with outside forces
    bool isGrounded;
    float horizontal_axis;
    float vertical_axis;

    // Start is called before the first frame update
    void Start()
    {
        movement_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       VerticalMovement();
       GroundMovement();
    }

    private void GroundMovement(){
        if(isGrounded){
            horizontal_axis = Input.GetAxis("Horizontal");
            vertical_axis = Input.GetAxis("Vertical");
        }
        Vector3 movement = 
            transform.right * horizontal_axis
            + transform.forward * vertical_axis;

        movement_controller.Move(player_speed * Time.deltaTime * movement);
    }

    private void VerticalMovement(){
        isGrounded = Physics.CheckSphere(ground_probe.position, ground_distance, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        else{
            velocity.y += gravity * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jump_height * -2 * gravity);
        }
        movement_controller.Move(velocity * Time.deltaTime);
    }
}
