using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private float TEMPS_SPAWN = 2;
    private float UPWARDMODIFIER = 10;
    
    
    
    [SerializeField] private float VELOCITY_MAGNITUDE = 45;
    [SerializeField] public float meleRange = 2F;
    [SerializeField] StatsPlayers StatsJugador;
    [SerializeField] StatsPlayers StatsJugador2;
    [SerializeField] private int LAYERJUG1;
    [SerializeField] private int LAYERJUG2; 
    [SerializeField] private float explForce = 1500;
    [SerializeField] StatsPlayers StatsEnemigo;
    [SerializeField] private Enemigo enemi;
    [SerializeField] private Jugador jugador2;
    [SerializeField] private float gravityMultiplier = 1.5f;

    [SerializeField] public List<ParticleSystem> particle;
    


    int LayerContrarios;
    Rigidbody rb;
    Collider cd;
    int lm;
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
        LayersCollidesWith();
        if(gameObject.layer== LAYERJUG1)
        {
            LayerContrarios = LAYERJUG2;
        }
        if (gameObject.layer == LAYERJUG2)
        {
            LayerContrarios = LAYERJUG1;
        }


    }
    private void LayersCollidesWith()
    {
        if (gameObject.layer == LAYERJUG1)
        {
          
            foreach (ParticleSystem particle in particle)
            {
                var collision = particle.collision;
                // Agregar la LayerMask a la lista de colisiones
                collision.collidesWith |= 1 << LayerMask.NameToLayer("Player2"); 
            }

        }
        if (gameObject.layer == LAYERJUG2)
        {
            
            foreach (ParticleSystem particle in particle)
            {
                var collision = particle.collision;
                collision.collidesWith |= 1 << LayerMask.NameToLayer("Player1");

            }
        }
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

        if (rb.isKinematic && Time.time > temp)
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
        if (gameObject.layer == LAYERJUG1)
        {
            StatsJugador.DamagePlayer(amount);
        }
        if (gameObject.layer == LAYERJUG2)
        {
            StatsJugador2.DamagePlayer(amount);
        }
    }

    private void Fuerza(Vector3 forceDirection)
    {
        rb.AddForce(forceDirection * StatsJugador.daño, ForceMode.Impulse);

    }

    public void DañoMele()
    {
        
        
         
        Collider[] golpe = Physics.OverlapSphere(transform.position, meleRange, LayerContrarios);
        Debug.Log("Layer Contrario" + LayerContrarios);
        Debug.Log(transform.position);
        //Ambos players LLegan hasta aqui
        
        foreach (Collider col in golpe)
        {
            Debug.Log("hay colision con colider");
            // Solo LLega el jugador 2
            
            if (col.gameObject != gameObject && col.gameObject.TryGetComponent(out Rigidbody rg))
            {
                Debug.Log(FuerzaAtaque());
                rg.AddExplosionForce(FuerzaAtaque(), transform.position, meleRange, UPWARDMODIFIER);
                Debug.Log(col.gameObject.layer + "");
                
               if (col.gameObject.layer == 6)
                    enemi.Golpes(DAMAGEMELE);

                if (col.gameObject.layer == LAYERJUG1|| col.gameObject.layer == LAYERJUG2)
                {
                    Debug.Log("Layer if Detectado");
                    jugador2.Golpes(DAMAGEMELE, gameObject);
                }


            }
            else
            {
                Debug.Log("No Hay RigidBody");
                //Aqui solo llega el player 2 | No detecta l rigidbody del player 1. Pero el player no entra en este if
            }
        }
    }

    public void Despawn()
    {
        rb.isKinematic = true;
        cd.enabled = false;
        transform.position = resp;
        if(gameObject.layer == LAYERJUG1)
        {
            StatsJugador.Respawn();
        }
        if(gameObject.layer == LAYERJUG2)
        {
            StatsJugador2.Respawn();
        }
        temp = Time.time + TEMPS_SPAWN;
        muerte = true;
        Debug.Log(lastOponentHit);
    }

    private float FuerzaAtaque()
    {
         if (gameObject.layer == LAYERJUG1)
         {
                return explForce * (1 + StatsJugador2.daño / 100);
         }
         if(gameObject.layer == LAYERJUG2)
         {
                return explForce * (1 + StatsJugador.daño / 100);
         }        
        else
        {
            return explForce * (1 + StatsEnemigo.daño / 100);
        }
        

    }
    
}
