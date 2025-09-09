using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditionals : MonoBehaviour
{
    public int x = 0;
    public int y = 100;
    public bool doSomething = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(x != y && doSomething)
        {
            x++;
            y--;
        }
       
        
        if(x == y)
        {
            print("x is equal to y");
        }
    }
}
