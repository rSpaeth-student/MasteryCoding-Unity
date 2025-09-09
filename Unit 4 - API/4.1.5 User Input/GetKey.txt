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
            print("Pressed Space Bar!");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            print("Spacebar held down");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            print("Unpressed space bar");
        }

        transform.position += Vector3.forward * moveSpeed * horizontalInput * Time.deltaTime;
    }
}
