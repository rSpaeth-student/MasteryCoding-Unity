using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Variables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int num;
        int numTwo;

        num = 2 + 10 * 5;
        print(num);
        numTwo = (2 + 10) * 5;
        print(numTwo);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
