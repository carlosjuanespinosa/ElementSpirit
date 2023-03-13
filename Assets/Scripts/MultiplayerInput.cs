using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerInput : MonoBehaviour
{
    
    private Movimiento movimiento;
    
    private void OnEnable()
    {
        movimiento = GetComponent<Movimiento>();
       
    }
}
