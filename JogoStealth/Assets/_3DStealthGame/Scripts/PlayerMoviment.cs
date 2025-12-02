using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public InputActionAsset inputActions;
    public InputAction MoveAction;

    public float walkSpeed = 1.0f;
    public float turnSpeed = 20f;

    private Animator anim;

    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        inputActions.Enable();
        MoveAction = inputActions.FindActionMap("Player").FindAction("Move");
    }

    void Update ()
    {
        Vector2 input = MoveAction.ReadValue<Vector2>();
        Vector3 mov = new Vector3(input.x, 0, input.y);

        if(mov.sqrMagnitude > 0)
        {
        float angle = Mathf.Atan2(mov.x, mov.z) * Mathf.Rad2Deg;
        float targetAngle = Mathf.LerpAngle(transform.eulerAngles.y, angle, turnSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        transform.Translate(mov * walkSpeed * Time.deltaTime, Space.World); 
        }
        
        if (mov != Vector3.zero)
        {
         anim.SetBool("Walking", true);     
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }
}
    
        