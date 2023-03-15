using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private float TEMPS_SPAWN = 2;
    [SerializeField] private float VELOCITY_MAGNITUDE = 45;
    [SerializeField] StatsPlayers StatsJugadores;
    Rigidbody rb;
    Collider cd;
    LayerMask lm;
    float temp = 5;
    Vector3 resp = new Vector3();

    // Desactivado al comiendo de la ejecución por defecto

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<Collider>();
        lm = GetComponent<LayerMask>();
        resp = transform.position;

    }
    public void OnParticleCollision(GameObject other)
    {
        if(other.layer != lm)
        {
            Golpes(+1);

            Vector3 colisionDirection = transform.position - other.transform.position;
            Fuerza(colisionDirection.normalized);
        }
        
    }
    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > VELOCITY_MAGNITUDE)
        {
            Despawn();
        }

        if (rb.isKinematic == true && Time.time > temp)
        {
            rb.isKinematic = false;
            cd.enabled = true;
        }
    }

    public void Golpes(float amount)
    {
        StatsJugadores.DamagePlayer(amount);
    }

    private void Fuerza(Vector3 forceDirection)
    {
        rb.AddForce(forceDirection * StatsJugadores.daño, ForceMode.Impulse);

    }

    private void Despawn()
    {
        rb.isKinematic = true;
        cd.enabled = false;
        transform.position = resp;
        StatsJugadores.Respawn();
        temp = Time.time + TEMPS_SPAWN;
    }
}
