using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Vector3 input_dir { get; private set; }
    void Update()
    {
        input_dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
