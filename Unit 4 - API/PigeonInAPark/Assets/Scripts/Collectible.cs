using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject collectFXprefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (collectFXprefab)
            {
                Instantiate(collectFXprefab, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
    }
}
