using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraysPartTwo : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        string[] groceries = {"Lemons", "Aluminum Foil", "Ice Cream"};
        string[] groceriesTwo = groceries;
        
        groceries[1] = "Ice Cream";

        print(groceriesTwo[1]);

        int num = 0;
        int numTwo = num;

        num++;
        print(numTwo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
