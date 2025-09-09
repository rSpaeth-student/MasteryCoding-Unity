using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //adds rigidbody to object when you add this script to object.
public class Crown : MonoBehaviour
{
   void OnCollisionEnter(Collision collision)
   {

    if (collision.gameObject.CompareTag("Ground"))
    {
        Score score = FindObjectOfType<Score>();
        if(score)
        {
            Debug.Log("You win!");
            score.EndLevel();
        }
    }
   }
}
