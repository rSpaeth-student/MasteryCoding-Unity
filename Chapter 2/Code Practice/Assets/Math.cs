using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = 0;
        int a = 1;

        if(a >= 0)
        {
            x += a++;
        }
        if(a > 1 && a != x)
        {
            x *= ++a;
        }
        else if (a <= 1 && a != x)
        {
            x -= a;
        }
        print(x);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
