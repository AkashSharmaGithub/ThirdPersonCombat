using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
   public State CurrentState { get;private set; }
   public MovementWithoutSwordState state_MovementWithoutSword { get;private set; }
   public MovementWithSwordState state_MovementWithSword { get;private set; }
   public JumpState state_Jump { get;private set; }
    
    private void Awake()
    {
        state_MovementWithoutSword = new MovementWithoutSwordState();
        state_MovementWithSword = new MovementWithSwordState();
        state_Jump = new JumpState();
        CurrentState = state_MovementWithoutSword;
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
