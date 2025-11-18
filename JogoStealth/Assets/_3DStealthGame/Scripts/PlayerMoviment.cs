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

    void FixedUpdate ()
    {
        var pos = MoveAction.ReadValue<Vector2>();
        
        float horizontal = pos.x;
        float vertical = pos.y;

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
        
        m_Rigidbody.MoveRotation (m_Rotation);
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * walkSpeed * Time.deltaTime);
        
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
    
        