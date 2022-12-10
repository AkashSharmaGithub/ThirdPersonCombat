using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(PlayerStateManager),typeof(CharacterController))]
public class PlayerMovementHandler : MonoBehaviour
{
    public PlayerStateManager PlayerStateManager{ get; private set; }
    public CharacterController CharacterController{ get; private set; }
    [field:SerializeField,Category("Player Speeds")]
    public float speedWithoutSword { get; private set; }
    [field:SerializeField,Category("Player Speeds")]
    public float speedWithSword { get; private set; }
    
    public float Speed { get; private set; }

    public Camera Camera { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        PlayerStateManager=GetComponent<PlayerStateManager>();
        CharacterController=GetComponent<CharacterController>();
        Camera = Camera.main;
    }
    public void movePlayer(State currentState)
    {
        if(currentState== PlayerStateManager.state_MovementWithoutSword)
        {
            Speed=speedWithoutSword;
        }
        else if(currentState == PlayerStateManager.state_MovementWithoutSword)
        {
            Speed = speedWithSword;
        }
        Vector3 direction = PlayerStateManager.InputHandler.Direction;
        direction=  direction.x* getNormalizedRightDirectionOfCamera()+direction.z*getNormalizedForwardDirectionOfCamera();
         if (direction != Vector3.zero)
        {

            CharacterController.Move(direction * Time.deltaTime*Speed);
           
            transform.rotation = Quaternion.LookRotation(direction*Time.deltaTime);
            
        }

    }
    private Vector3 getNormalizedForwardDirectionOfCamera()
    {
        Vector3 direction = Camera.transform.forward;
        direction.y = 0;
        return direction.normalized;
    }
    private Vector3 getNormalizedRightDirectionOfCamera()
    {
        Vector3 direction = Camera.transform.right;
        direction.y = 0;
        return direction.normalized;
    }


}
