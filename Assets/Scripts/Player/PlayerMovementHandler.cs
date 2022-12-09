using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
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
    // Start is called before the first frame update
    void Awake()
    {
        PlayerStateManager=GetComponent<PlayerStateManager>();
        CharacterController=GetComponent<CharacterController>();
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
         if (direction != Vector3.zero)
        {
            CharacterController.Move(direction * Time.deltaTime*Speed);
        }
    }
    
   
}
