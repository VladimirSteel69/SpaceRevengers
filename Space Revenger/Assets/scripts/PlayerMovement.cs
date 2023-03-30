using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 300f;
    
    float movement = 0f;

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, -movement * speed * Time.deltaTime);
    }

    
    
}
