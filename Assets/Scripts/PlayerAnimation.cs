using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation2 : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb2;
    public LayerMask LayerMask;
    public bool grounded;
    public float ground = 0.3f;


    void Start()
    {
        this.rb2 = GetComponent<Rigidbody>();


    }

    private void Update()
    {
        Grounded();
        Jump();
        Move();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            this.rb2.AddForce(Vector3.up * 6, ForceMode.Impulse);
        }

    }

    private void Grounded()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, ground, LayerMask))
        {
            this.grounded = true;
        }
        else
        {
            this.grounded = false;
        }

        this.anim.SetBool("jump", !this.grounded);
    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();

        this.transform.position += movement * 0.02f;

        this.anim.SetFloat("vertical", verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);
    }
}