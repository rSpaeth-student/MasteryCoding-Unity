using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoops : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 0;
        for (int i = 10; i > 0; i--)
        {
            print("i: " + i);
            for(int j = 0; j < 10; j++)
            {
                a += j;
                
            }
            print(a);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
