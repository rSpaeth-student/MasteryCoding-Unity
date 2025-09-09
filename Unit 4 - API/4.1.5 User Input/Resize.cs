using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale = Vector3.one;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.localScale = Vector3.one;
        }
        
        transform.position += Vector3.forward * moveSpeed * horizontalInput * Time.deltaTime;
    }
}
