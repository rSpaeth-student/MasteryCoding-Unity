using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //adds rigidbody to object when you add this script to object.
public class Projectile : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forceAmount = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Vector3 forceDirection = transform.forward;

        rigidbody.AddForce(forceDirection * forceAmount, ForceMode.VelocityChange);

    }

    void OnCollisionEnter(Collision other)
    {
        print("Collides with " + other.gameObject.name);
        if(other.gameObject.CompareTag("Castle"))
        {
            Destroy(other.gameObject); //makes the cubes just disappear when hit
        }
    }
}
