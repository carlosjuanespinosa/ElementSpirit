using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private float TEMPS_SPAWN = 2;
    
    [SerializeField] private float VELOCITY_MAGNITUDE = 45;
    [SerializeField] public float meleRange = 2F;
    [SerializeField] StatsPlayers StatsJugador;
    [SerializeField] LayerMask LayerContrarios;
    [SerializeField] private float explForce = 2500;
    [SerializeField] StatsPlayers StatsEnemigo;
    [SerializeField] private Enemigo enemi;
    [SerializeField] private Jugador jugador2;
    

    Rigidbody rb;
    Collider cd;
    LayerMask lm;
    float temp = 5;
    private bool muerte;
    

    Vector3 resp = new Vector3();

    [SerializeField] private float DAMAGEMELE = 15;
    // Desactivado al comiendo de la ejecución por defecto

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<Collider>();
        lm = gameObject.layer;
        resp = transform.position;
        muerte = false;
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
    private void Update()
    {
        if (muerte && Time.time > temp)
        {
            muerte = false;
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
        StatsJugador.DamagePlayer(amount);
    }

    private void Fuerza(Vector3 forceDirection)
    {
        rb.AddForce(forceDirection * StatsJugador.daño, ForceMode.Impulse);

    }

    public void DañoMele()
    {
        Collider[] golpe = Physics.OverlapSphere(transform.position, meleRange, LayerContrarios);

        foreach (Collider col in golpe)
        {
            
            if (col.gameObject != gameObject && col.TryGetComponent(out Rigidbody rg))
            {

                rg.AddExplosionForce(FuerzaAtaque(), transform.position, meleRange, 10);
                Debug.Log(col.gameObject.layer);
                
               if (col.gameObject.layer == 6)
                    enemi.Golpes(DAMAGEMELE);

                if (col.gameObject.layer == 7 || col.gameObject.layer == 8)
                    jugador2.Golpes(DAMAGEMELE);
              
            }
        }
    }

    public void Despawn()
    {
        rb.isKinematic = true;
        cd.enabled = false;
        transform.position = resp;
        StatsJugador.Respawn();
        temp = Time.time + TEMPS_SPAWN;
        muerte = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Jugador>().muerte)
        {
            Debug.Log(StatsJugador.kills);
            StatsJugador.ContKills(+1);
        }
    }
    private float FuerzaAtaque()
    {
        return explForce * (1 + StatsEnemigo.daño / 100);

    }
}
