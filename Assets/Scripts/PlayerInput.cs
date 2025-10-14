using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement tPlayerMovement;
    private MainInputActions tMainInput;

    void Start()
    {
        tPlayerMovement = GetComponent<PlayerMovement>();

        tMainInput = new MainInputActions();
        tMainInput.Enable();
        tMainInput.Player.Enable();

        tMainInput.Player.Move.performed += OnMove;
        tMainInput.Player.Jump.performed += OnJump;
        tMainInput.Player.Attack.performed += OnAttacking;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jumping");
        tPlayerMovement.ApplyJump();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        float val = ctx.ReadValue<float>();

        Debug.Log(val);
        tPlayerMovement.SetXInput(val);
    }

    private void OnAttacking(InputAction.CallbackContext context)
    {
        Debug.Log("Attacking");
        tPlayerMovement.ApplyAttacking();
    }
}
