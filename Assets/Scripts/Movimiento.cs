using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float CARGA_DISTANCIA = 10;
    [SerializeField] private float CARGA_MELE = 2;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxRange = 15;
    [SerializeField] private float meleRange = 2F;
    [SerializeField] private GameObject escudo;
    [SerializeField] private ParticleSystem delante;
    [SerializeField] private ParticleSystem derecha;
    [SerializeField] private ParticleSystem izquierda;
    [SerializeField] private ParticleSystem detras;
    [SerializeField] private ParticleSystem mele;
    [SerializeField] private LayerMask layerVision;
    [SerializeField] private float rotar = 100;
    [SerializeField] private float explForce =2500;
    [SerializeField] StatsPlayers StatsEnemigo;
    [SerializeField] private Enemigo enemi;
    [SerializeField] private float DAMAGEMELE = 15;
        // [SerializeField] private Animator animator;

    private Vector3 movementVector = new Vector3();
    private bool defensa = false;
    private float temp= 5;
    private Rigidbody rb;
    
    

    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        escudo.SetActive(false);
        
    }
    public void SetMovementVector(Vector3 _movementVector)
    {
        
        movementVector = _movementVector;
    }
   
    public void DistAt()
    {
        if(delante.isStopped && mele.isStopped && !defensa)
            {
            AtaqueDist();
        }
    }

    public void CaC()
    {
        MeleAtaque();
    }
    public void DistAtCar()
    {
        if (delante.isStopped && mele.isStopped && !defensa)
        {
            AtaqueDistCarg();
        }
    }
    public void Defensa()
    {
        Escudo();
    }

    private void Update()
    {
        Move();
        if (Time.time > temp)
        {
            delante.Stop();
            derecha.Stop();
            detras.Stop();
            izquierda.Stop();
            mele.Stop();
            
        }
       
    }

    /*private void Rotar()
    {
        Vector3 relativePos = target.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
        
    }*/
    private void Move()
    {
        // animator.SetFloat("z_move", movementVector.z);
        //animator.SetFloat("x_move", movementVector.x);
        //animator.SetBool("isMoving", movementVector.magnitude > 0);
        if (movementVector.magnitude > 0)
        {
            Quaternion rotacioMoviment = Quaternion.LookRotation(movementVector, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.localRotation, rotacioMoviment, rotar);
        }

       

        if (delante.isStopped && mele.isStopped && !defensa)
        {
         
            rb.velocity = new Vector3(movementVector.x * speed, rb.velocity.y , movementVector.z * speed);

        }   

    }

    
    private void AtaqueDistCarg()
    {
        derecha.Play();
        delante.Play();
        izquierda.Play();
        detras.Play();
        temp = Time.time + CARGA_DISTANCIA;
    }

    private void AtaqueDist()
    {
        delante.Play();
        temp = Time.time + CARGA_DISTANCIA;
    }

    private void MeleAtaque()
    {
        if (delante.isStopped && mele.isStopped && !defensa)
        {
            Collider[] golpe = Physics.OverlapSphere(transform.position, meleRange, layerVision);
            mele.Play();
            temp = Time.time + CARGA_MELE;
            foreach (Collider col in golpe)
            {
                if (col.TryGetComponent(out Rigidbody rg)) {
                    
                    rg.AddExplosionForce(FuerzaAtaque(), transform.position, meleRange, 10);
                    enemi.Golpes(+DAMAGEMELE);
                }
            }
        } 
    }

    private void Escudo()
    {
        if (!defensa && delante.isStopped && mele.isStopped)
        {
            escudo.SetActive(true);
            defensa = true;
        }
        else
        {
            escudo.SetActive(false);
            defensa = false;
        }   
    }
  
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxRange);
        Gizmos.DrawWireSphere(transform.position, meleRange);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        

    }
    private float FuerzaAtaque()
    {
      return explForce * (1 + StatsEnemigo.daño / 100);
       
    }
}

