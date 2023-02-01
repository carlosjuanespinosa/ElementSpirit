using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTeclas : MonoBehaviour
{
    // Start is called before the first frame update
    private InputJugador inputJug;
    private Movimiento movimiento;

    private void OnEnable()
    {
        movimiento = GetComponent<Movimiento>();
        inputJug = new InputJugador();
        inputJug.Enable();

        inputJug.Jugador.Caminar.performed += Caminar;
        inputJug.Jugador.Caminar.canceled += Caminar;
        inputJug.Jugador.Saltar.performed += Saltar;
        inputJug.Jugador.Saltar.canceled += Saltar;

    }

       private void Caminar (InputAction.CallbackContext ctx)
    {
        Vector2 moveDirection = ctx.ReadValue<Vector2>();
        movimiento.SetMovementVector(new Vector3(moveDirection.x, 0, moveDirection.y));
    }

    private void Saltar (InputAction.CallbackContext ctx)
    {
        movimiento.Jump();
    }
    private void OnDisable()
    {
        inputJug.Jugador.Caminar.performed -= Caminar;
        inputJug.Jugador.Caminar.canceled -= Caminar;
        inputJug.Jugador.Saltar.performed -= Saltar;
        inputJug.Jugador.Saltar.canceled -= Saltar;
        inputJug.Disable();
    }
}
