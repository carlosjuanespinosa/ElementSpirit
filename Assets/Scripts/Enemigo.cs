using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private float TEMPS_SPAWN = 2;
    [SerializeField] private float VELOCITY_MAGNITUDE = 45;
    [SerializeField] StatsPlayers StatsEnemigos;
    Rigidbody rb;
    Collider cd;
    float temp = 5;
    Vector3 resp = new Vector3();
   
    // Desactivado al comiendo de la ejecución por defecto
    
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<Collider>();
        resp = transform.position;
        
    }
    public void OnParticleCollision(GameObject other)
    {
        Golpes(+1);

        Vector3 colisionDirection = transform.position - other.transform.position;
        Fuerza(colisionDirection.normalized);
    }
    private void FixedUpdate()
    {
        if(rb.velocity.magnitude > VELOCITY_MAGNITUDE)
        {
            Despawn();
        } 

        if(rb.isKinematic == true && Time.time > temp)
        {
            rb.isKinematic = false;
            cd.enabled = true;
        }
    }

    public void Golpes (float amount)
    {
        StatsEnemigos.DamagePlayer(amount);
    }

    private void Fuerza(Vector3 forceDirection)
    {
       rb.AddForce( forceDirection * StatsEnemigos.daño, ForceMode.Impulse );
        
    }

    public void Despawn()
    {
        rb.isKinematic=true;
        cd.enabled = false;
        transform.position = resp;
        StatsEnemigos.Respawn();
        temp = Time.time + TEMPS_SPAWN;
    }
}
