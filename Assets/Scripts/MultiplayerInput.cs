
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerInput : MonoBehaviour
{
    
    private Movimiento movimiento;

    private InputActionAsset inputAsset;
    private InputActionMap spirit;
    
    private void OnEnable()
    {
        movimiento = GetComponent<Movimiento>();

        inputAsset = GetComponent<PlayerInput>().actions;
        spirit = inputAsset.FindActionMap("Player");

        spirit.Enable();

        spirit.FindAction("Caminar").performed += Caminar;
        spirit.FindAction("Caminar").canceled += Caminar;
        spirit.FindAction("AtaqueDist").performed += AtqDist;
        spirit.FindAction("AtaqueDistCar").performed += AtqDistCarg;
        spirit.FindAction("AtaqueMele").performed += AtqMele;
        spirit.FindAction("Defensa").performed += Defens;

    }

    private void Caminar(InputAction.CallbackContext ctx)
    {
        Vector2 moveDirection = ctx.ReadValue<Vector2>();
        movimiento.SetMovementVector(new Vector3(moveDirection.x, 0, moveDirection.y));
    }

    private void AtqDist(InputAction.CallbackContext ctx)
    {
        movimiento.DistAt();
    }

    private void AtqDistCarg(InputAction.CallbackContext ctx)
    {
        movimiento.DistAtCar();
    }

    private void AtqMele(InputAction.CallbackContext ctx)
    {
        movimiento.CaC();
    }
    private void Defens(InputAction.CallbackContext ctx)
    {
        movimiento.Defensa();
    }
    private void OnDisable()
    {
        spirit.FindAction("Caminar").performed -= Caminar;
        spirit.FindAction("Caminar").canceled -= Caminar;
        spirit.FindAction("Caminar").performed -= AtqDist;
        spirit.FindAction("AtaqueDistCar").performed -= AtqDistCarg;
        spirit.FindAction("AtaqueMele").performed -= AtqMele;
        spirit.FindAction("Defensa").performed -= Defens;

        spirit.Disable();
    }

}

