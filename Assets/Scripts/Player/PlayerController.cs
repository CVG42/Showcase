using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public float speed;
    private Vector3 direction;
    public bool isMoving;
    public bool isIdle;

   private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, vertical);
        movementAnimation(direction);
        if (Input.GetKey(KeyCode.R) && isMoving == true || Input.GetKey(KeyCode.R) && isIdle==true)
        {
            anim.SetBool("isHoeing", true);
        }
        else { anim.SetBool("isHoeing", false); }
    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void movementAnimation(Vector3 direction)
    {
        if (anim != null)
        {
            if (direction.magnitude > 0)
            {
                anim.SetBool("isMoving", true);
                anim.SetFloat("horizontal", direction.x);
                anim.SetFloat("vertical", direction.y);
                isMoving = true;
                isIdle = false;
            }
            else
            {
                anim.SetBool("isMoving", false);
                isIdle = true;
                isMoving = false;
            }
        }
    }
}
