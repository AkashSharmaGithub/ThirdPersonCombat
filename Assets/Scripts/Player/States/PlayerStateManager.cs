using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InputHandler), typeof(PlayerMovementHandler))]
public class PlayerStateManager : MonoBehaviour
{

   public State CurrentState { get;private set; }
   public MovementWithoutSwordState state_MovementWithoutSword { get;private set; }
   public MovementWithSwordState state_MovementWithSword { get;private set; }
   public JumpState state_Jump { get;private set; }
   public InputHandler InputHandler { get;private set; }
   public PlayerMovementHandler PlayerMovementHandler { get;private set; }
    public PlayerAnimationManager PlayerAnimationManager { get;private set; }
    private void Awake()
    {
        state_MovementWithoutSword = new MovementWithoutSwordState();
        state_MovementWithSword = new MovementWithSwordState();
        state_Jump = new JumpState();
        CurrentState = state_MovementWithoutSword;

        
    }
    private void Start()
    {
        InputHandler = GetComponent<InputHandler>();
        PlayerMovementHandler = GetComponent<PlayerMovementHandler>();
        PlayerAnimationManager = GetComponent<PlayerAnimationManager>();
        CurrentState.OnStateEntered(this);
        
    }
    private void Update()
    {
        CurrentState.Tick(this, Time.deltaTime);
    }
    public void changeState(State state)
    {
        if(CurrentState==state)
        {
            return;
        }
        CurrentState = state;
        CurrentState.OnStateEntered(this);
    }
}
