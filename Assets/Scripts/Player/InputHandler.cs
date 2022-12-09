using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerStateManager))]

public class InputHandler : MonoBehaviour
{
    public Controller Controller { get; private set; }
    public PlayerStateManager PlayerStateManager { get; private set; }
    public Vector3 Direction { get; private set; }
    
    private void Awake()
    {
        PlayerStateManager = GetComponent<PlayerStateManager>();
        Controller = new Controller();
    }
    private void OnEnable()
    {
        Controller.Enable();
    }
    private void OnDisable()
    {
        Controller.PlayerMovement.Movement.started -= OnMovement;
        Controller.PlayerMovement.Movement.performed -= OnMovement;
        Controller.PlayerMovement.Movement.canceled -= OnMovement;
        Controller.Disable();
    }
    private void Start()
    {
        Controller.PlayerMovement.Movement.started += OnMovement;
        Controller.PlayerMovement.Movement.performed += OnMovement;
        Controller.PlayerMovement.Movement.canceled += OnMovement;
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            Direction = Vector3.zero;
            return;
        }
        Vector2 value = context.ReadValue<Vector2>();
        Debug.Log("Entered");
        Direction = new Vector3(value.x, 0, value.y);
    
    }
}
