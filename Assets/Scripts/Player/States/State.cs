using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State 
{
    public void OnStateEntered(PlayerStateManager stateManager);
    public void Tick(PlayerStateManager stateManager,float deltaTime);
    public void OnStateExited(PlayerStateManager stateManager);
}
