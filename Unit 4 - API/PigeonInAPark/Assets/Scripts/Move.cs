using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rigidbody;

    public float moveSpeed = 1.0f;

    public float jumpForce = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = Vector3.forward * moveSpeed * horizontalInput * Time.deltaTime;
        rigidbody.AddForce(moveDirection, ForceMode.Acceleration);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpDirection = Vector3.up * jumpForce;
            rigidbody.AddForce(jumpDirection, ForceMode.VelocityChange);
        }

        Vector3 velocity = rigidbody.velocity;
        velocity.y = 0.0f;
        if(velocity.magnitude > 0.0f) //doesn't let pigeon be stuttering and pointing down.
        {
            transform.rotation = Quaternion.LookRotation(velocity);
        }
        
    }
}
