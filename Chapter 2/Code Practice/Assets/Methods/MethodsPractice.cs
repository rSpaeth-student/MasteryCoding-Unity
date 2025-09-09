using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodsPractice : MonoBehaviour
{

    public int a = 1;
    public int b = 2;
    
    public int[] array = {1,2,3,4,5};

    // Start is called before the first frame update
    void Start()
    {
        // Call each method here using the public variables where applicable.
        Welcome();
        int Sum = Add(3, 7);
        print(Sum);
        ArraySum(array);
    }

    // Declare a method called Welcome which prints out a simple welcome message.
    void Welcome()
    {
        print("Welcome!");
    }

    // Declare a method called Add which returns the sum of two int parameters.
    int Add(int a, int b)
    {
        return(a + b);
    }

    // Declare a method called ArraySum which takes in an array of integers as a parameter and 
    // iterates through the array to return the sum of its elements
    void ArraySum(int[] array)
    {
        int Sum = 0;

        for(int i = 0; i < array.Length; i++)
        {
            Sum += array[i];
        }
        print(Sum);
    }
}
