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
    [SerializeField] private float explForce = 1500;
    [SerializeField] StatsPlayers StatsEnemigo;
    [SerializeField] private Enemigo enemi;
    [SerializeField] private Jugador jugador2;
    [SerializeField] private float gravityMultiplier = 2;



    Rigidbody rb;
    Collider cd;
    LayerMask lm;
    float temp = 5;
    private bool muerte;
    public GameObject lastOponentHit;

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
            Golpes(+1, other);

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

        // Simplement afegim una força adicional en la direcció del sistema de físiques
        // de Unity multiplicat per cert nombre
        rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
    }

    public void Golpes(float amount, GameObject whomInflictsDamage)
    {
        lastOponentHit = whomInflictsDamage;
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
                    jugador2.Golpes(DAMAGEMELE, gameObject);
              
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
        Debug.Log(lastOponentHit);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name);
        }
    }
    private float FuerzaAtaque()
    {
        return explForce * (1 + StatsEnemigo.daño / 100);

    }
    
}
