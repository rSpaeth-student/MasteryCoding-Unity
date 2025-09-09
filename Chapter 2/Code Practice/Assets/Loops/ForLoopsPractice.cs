using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoopsPractice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CountToTen();
        Countdown(10);
        ConstructAGrid(5, 10);
        
    }
     void CountToTen()
    {
        // Use a for loop to count from 1 to 10, including 1 and 10. Print each index value.
        for (int i = 1; i <= 10; i++)
        {
            print("i: " + i);
        }
    }
    void Countdown(int start)
    {
        // Use a for loop to count from start down to 0. Print each index value.
        for (int i = start; i >= 0; i--)
        {
            print("start: " + i);
        }
    }
    
    void ConstructAGrid(int x, int y)
    {
        // Create a nested for loop, with an outer loop incrementing from -x to x 
        // and an inner loop incrementing from -y to y.
        // In each iteration of the inner for loop, print the 
        // following: "x: [value of x], y: [value of y]"
        for(int i = x * -1; i <= x; i++)
        {

            for(int j = y * -1; j <= y; j++)
            {
                print("x: " + i + ", y: " + j);
            }
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
