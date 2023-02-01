using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 10f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private float gravityMultiplier = 2f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private float rotar = 400;
    // [SerializeField] private Animator animator;

    private Vector3 movementVector = new Vector3();
    private float gravityApplied;
    private int remainingJumps;
    private Vector3 jumpVelocity;
    public Transform target;
    private void Start()
    {
        gravityApplied = Physics.gravity.y * gravityMultiplier;
        remainingJumps = maxJumps;
    }
    public void SetMovementVector(Vector3 _movementVector)
    {
        movementVector = _movementVector;
    }

    private void Update()
    {
        Move();
        ApplyGravity();
        Rotar();

    }

    private void Rotar()
    {
        Vector3 relativePos = target.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
        
    }
    private void Move()
    {
       // animator.SetFloat("z_move", movementVector.z);
        //animator.SetFloat("x_move", movementVector.x);
        //animator.SetBool("isMoving", movementVector.magnitude > 0);
        Debug.Log(movementVector);
       
        cc.Move(movementVector * speed * Time.deltaTime);


    }

    public void Jump()
    {
        //animator.Set
        if (cc.isGrounded || (!cc.isGrounded && remainingJumps > 0))
        {
            jumpVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityApplied);
            remainingJumps--;
        }
    }
    private void ApplyGravity()
    {
        cc.Move(jumpVelocity * Time.deltaTime);
        if (cc.isGrounded && jumpVelocity.y < 0f)
        {
            remainingJumps = maxJumps;
            jumpVelocity.y = -2f;
        }
        else
        {
            jumpVelocity.y += gravityApplied * Time.deltaTime;
        }
    }
}

