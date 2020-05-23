﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public float speed = 3.0f;

    private Vector3 movement;

    private Animator anim;
    private Rigidbody modelRigidbody;

    private void Start()
    {
        anim = GetComponent<Animator>();
        modelRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = new Vector3(x, 0.0f, z).normalized * speed * Time.deltaTime;
        
        Move();
        
        Attack(); 
    }

    private void Move()
    {
        if (movement.magnitude < 0.01f)
        {
            anim.SetBool("isRun", false);
            return;
        }

        modelRigidbody.MovePosition(transform.position + movement);
        modelRigidbody.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        anim.SetBool("isRun", true);
    }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("isAttack", true);
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
    }
}