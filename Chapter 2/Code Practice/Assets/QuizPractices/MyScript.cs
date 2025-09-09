using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
   public int x = 2;
    void Start()
    {
        x = Exponent(MakeOdd(x), 2);
        print(x);
    }

    public int MakeOdd(int value)
    {
        if ((value % 2) == 0)
        {
             value += 1;
        }

        return value;
    }

    public int Exponent(int value, int exponent)
    {
        int temp = value;
        for (int i = 1; i < exponent; i++)
        {
             value *= temp;
        }

        return value;
    }
}
