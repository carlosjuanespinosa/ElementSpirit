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
    [SerializeField] public float meleRange = 2F;
    [SerializeField] private GameObject escudo;
    [SerializeField] private ParticleSystem delante;
    [SerializeField] private ParticleSystem derecha;
    [SerializeField] private ParticleSystem izquierda;
    [SerializeField] private ParticleSystem detras;
    //[SerializeField] private ParticleSystem delante2;
   // [SerializeField] private ParticleSystem derecha2;
    //[SerializeField] private ParticleSystem izquierda2;
    //[SerializeField] private ParticleSystem detras2;
   [SerializeField] private ParticleSystem mele;
    [SerializeField] private float rotar = 100;


    // [SerializeField] private Animator animator;
    private MenuPause menuPausa;
    private Vector3 movementVector = new Vector3();
    private bool defensa = false;
    private float temp= 5;
    private Rigidbody rb;
    private Jugador jugador;
    
    
    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        escudo.SetActive(false);
       jugador= GetComponent<Jugador>();
        
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

    public void Pausa()
    {
        menuPausa.Pausamenu();
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
            //delante2.Stop();
            //derecha2.Stop();
            //detras2.Stop();
            //izquierda2.Stop();
        }
       

    }
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

        //if (gameObject.layer == 7)
        //{
            derecha.Play();
            delante.Play();
            izquierda.Play();
            detras.Play();
            temp = Time.time + CARGA_DISTANCIA;
       // }
        /*if (gameObject.layer == 8)
        {
            derecha2.Play();
            delante2.Play();
            izquierda2.Play();
            detras2.Play();
            temp = Time.time + CARGA_DISTANCIA;
        }*/
    }

    private void AtaqueDist()
    {
        //Debug.Log(gameObject.layer);
        //Debug.Log(gameObject.name);
        //if (gameObject.layer == 7)
        //{
            delante.Play();
            temp = Time.time + CARGA_DISTANCIA;
          //  Debug.Log(gameObject.name+"1");
        //}
        /*if (gameObject.layer == 8)
        {
            delante2.Play();
            temp = Time.time + CARGA_DISTANCIA;
            Debug.Log(gameObject.name + "2");
        }*/
    }

    private void MeleAtaque()
    {
        if (delante.isStopped && mele.isStopped && !defensa)
        {
            jugador.Da�oMele();
            mele.Play();
            temp = Time.time + CARGA_MELE;
            
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
  

  
}

