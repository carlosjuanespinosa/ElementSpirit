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
        inputJug.Jugador.AtaqueDist.performed += AtqDist;
        inputJug.Jugador.AtaqueDistCar.performed += AtqDistCarg;
        inputJug.Jugador.AtaqueMele.performed += AtqMele;
        inputJug.Jugador.Defensa.performed += Defens;

    }

       private void Caminar (InputAction.CallbackContext ctx)
    {
        Vector2 moveDirection = ctx.ReadValue<Vector2>();
        movimiento.SetMovementVector(new Vector3(moveDirection.x, 0, moveDirection.y));
    }

    private void AtqDist (InputAction.CallbackContext ctx)
    {
        movimiento.DistAt();
    } 

    private void AtqDistCarg (InputAction.CallbackContext ctx)
    {
        movimiento.DistAtCar();
    }
    
    private void AtqMele(InputAction.CallbackContext ctx)
    {
        movimiento.CaC();
    }private void Defens (InputAction.CallbackContext ctx)
    {
        movimiento.Defensa();
    }
    private void OnDisable()
    {
        inputJug.Jugador.Caminar.performed -= Caminar;
        inputJug.Jugador.Caminar.canceled -= Caminar;
        inputJug.Jugador.AtaqueDist.performed -= AtqDist;
        inputJug.Jugador.AtaqueDistCar.performed -= AtqDistCarg;
        inputJug.Jugador.AtaqueMele.performed -= AtqMele;
        inputJug.Jugador.Defensa.performed -= Defens;

        inputJug.Disable();
    }
}
