using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Methods : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 1;
        int b = 2;
        
        print(Add(a, b));
    }

    public int Add(int a, int b)
    {
        return a + b;
    }
}
