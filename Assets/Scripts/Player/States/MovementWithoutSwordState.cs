using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWithoutSwordState : State
{
    public void OnStateEntered(PlayerStateManager stateManager)
    {
        
    }
    public void Tick(PlayerStateManager stateManager, float deltaTime)
    {
        stateManager.PlayerMovementHandler.movePlayer(this);
    }
    public void OnStateExited(PlayerStateManager stateManager)
    {
       
    }

    

   
}
