using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float movementSpeed = 6f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 direction = (transform.forward * vertical + transform.right * horizontal).normalized;

            velocity = direction * movementSpeed;
        }

        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }
}
