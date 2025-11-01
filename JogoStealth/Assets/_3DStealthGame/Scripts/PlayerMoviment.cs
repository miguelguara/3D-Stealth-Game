using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;

    public float walkSpeed = 1.0f;
    public float turnSpeed = 20f;

    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    private Animator anim;

    void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        MoveAction.Enable();
    }

    void FixedUpdate ()
    {
        var pos = MoveAction.ReadValue<Vector2>();
        
        float horizontal = pos.x;
        float vertical = pos.y;
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        Vector3 dir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

        if(m_Movement != Vector3.zero)
        {
             m_Rigidbody.linearVelocity = dir * walkSpeed;
             transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        else
        {
            m_Rigidbody.linearVelocity = Vector3.zero;
        }
        if (m_Movement != Vector3.zero)
        {
         anim.SetBool("Walking", true);     
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        
       
    }
}