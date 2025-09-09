using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileLoops : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = 0;
        int z = 0;
        while(x < 10)
        {
            x++;
            print("x: " + x);

            int y = 0;
            while(y < 10)
            {
                y++;
                z++;
                print("y: " + y);
            }
        }

        print("z: " + z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
