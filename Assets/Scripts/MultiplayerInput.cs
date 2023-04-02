
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerInput : MonoBehaviour
{
    
    private Movimiento movimiento;
  

    private InputActionAsset inputAsset;
    private InputActionMap jugador;
    
    private void OnEnable()
    {
        movimiento = GetComponent<Movimiento>();
        

        inputAsset = GetComponent<PlayerInput>().actions;
        jugador = inputAsset.FindActionMap("Jugador");

        jugador.Enable();

        jugador.FindAction("Caminar").performed += Caminar;
        jugador.FindAction("Caminar").canceled += Caminar;
        jugador.FindAction("AtaqueDist").performed += AtqDist;
        jugador.FindAction("AtaqueDistCar").performed += AtqDistCarg;
        jugador.FindAction("AtaqueMele").performed += AtqMele;
        jugador.FindAction("Defensa").performed += Defens;
        jugador.FindAction("Pausa").performed += Pause;
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
    private void Pause(InputAction.CallbackContext ctx)
    {
        movimiento.Pausa();
    }
    private void OnDisable()
    {
        jugador.FindAction("Caminar").performed -= Caminar;
        jugador.FindAction("Caminar").canceled -= Caminar;
        jugador.FindAction("Caminar").performed -= AtqDist;
        jugador.FindAction("AtaqueDistCar").performed -= AtqDistCarg;
        jugador.FindAction("AtaqueMele").performed -= AtqMele;
        jugador.FindAction("Defensa").performed -= Defens;
        jugador.FindAction("Pausa").performed -= Pause;

        jugador.Disable();
    }

}

