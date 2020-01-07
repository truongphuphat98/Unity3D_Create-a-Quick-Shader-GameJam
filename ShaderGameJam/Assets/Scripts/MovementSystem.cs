using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody rb;
    public InputSystem input;

    void Update()
    {
        InputToMovement();
    }
    

    void InputToMovement()
    {
        Vector3 dir = input.input_dir.normalized;
        rb.velocity = dir * moveSpeed;
    }
}
