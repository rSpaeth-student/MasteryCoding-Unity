using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionFX;
    public float force, radius, modifier;
    // Start is called before the first frame update
    void Start()
    {
        if (explosionFX != null)
        {
            Instantiate(explosionFX, transform.position, Quaternion.identity);
        }
        Invoke("DestroyExplosion", 0.1f);


    }

   void OnTriggerEnter(Collider other)
   {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if(rigidbody)
        {
            rigidbody.AddExplosionForce(force, transform.position, radius, modifier, ForceMode.VelocityChange);
        }
   }

   void DestroyExplosion()
   {
    Destroy(gameObject);
   }
}
