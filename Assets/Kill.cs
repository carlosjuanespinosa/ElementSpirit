using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private Enemigo enemi;
    private Jugador jugador;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemigo>())
        {
            enemi.Despawn();
        }
        if (other.gameObject.GetComponent<Jugador>())
        {
            Debug.Log(other.gameObject.name);
            other.GetComponent<Jugador>().Despawn();

        }
    }
}
