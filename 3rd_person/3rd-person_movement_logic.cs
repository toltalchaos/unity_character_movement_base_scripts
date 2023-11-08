using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_logic : MonoBehaviour
{
    [SerializeField] private int playerMoveSpeed = 5; //serializefield is for the editor to have a reference and private to lock off from other classes
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 input_vector = new Vector2(0,0);
        if(Input.GetKey(KeyCode.W)){
            input_vector.y = +1;
        }
        if(Input.GetKey(KeyCode.S)){
            input_vector.y = -1;
        }
        if(Input.GetKey(KeyCode.A)){
            input_vector.x = -1;
        }
        if(Input.GetKey(KeyCode.D)){
            input_vector.x = +1;
        }

        input_vector = input_vector.normalized;

        Vector3 movement_direction = new Vector3(input_vector.x, 0f, input_vector.y);
        transform.position += movement_direction * playerMoveSpeed * Time.deltaTime;
        // transform.forward = movement_direction; // this call to snap move the player in the direction
        //Slerp for smothing 
        transform.forward = Vector3.Slerp(
                    transform.forward,
                    movement_direction,
                    Time.deltaTime * (playerMoveSpeed* 2));
    }
}
