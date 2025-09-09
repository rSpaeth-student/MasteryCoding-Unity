using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] groceries = {"Lemons", "Aluminum Foil", "Ice Cream"};
        
        for(int i = 0; i < groceries.Length; i++)
        {
            print(groceries[i]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
