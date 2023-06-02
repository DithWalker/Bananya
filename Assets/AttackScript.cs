using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public int damageAmount = 20;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
             // animator.SetBool("attack", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            // animator.SetBool("attack", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
            
        }
    }
}
