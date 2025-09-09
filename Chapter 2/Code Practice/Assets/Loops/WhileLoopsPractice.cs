using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileLoopsPractice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CountToTen();
        CountToTwentyEven();
        CountToTwentyOdd();
        ALoopInALoop();
        
    }
    void CountToTen()
    {
        // Construct a while loop to count from 1 to 10 (including 1 and 10). 
        //Print each index to the console.
        int i = 1; 
        while(i <= 10)
        {
            print("CountToTen: " + i);
            i++;
        }
    }
    void CountToTwentyEven()
    {
        // Construct a while loop to count from 0 to 20 only printing even numbers.
        int i = 0;
        while(i <= 20)
        {
            i = i + 1;
            if(i % 2 == 0)
            {
                print("CountToTwentyEven: " + i);
            }
        }
    }
    void CountToTwentyOdd()
    {
        // Construct a while loop to count from 0 to 20 only printing odd numbers.
        int i = 0;
        while(i < 20)
        {
            i = i + 1;
            if(i % 2 != 0)
            {
                print("CountToTwentyOdd: " + i);
            }
        }
    }

    void ALoopInALoop()
    {
        // Using a nested while loop count from 1 to 100. Inner and outer loops should 
        // run 10 times each.
        int i = 0;
        while(i <= 90)
        {
            int j = 0;
            while(j < 10)
            {
            i++;
            j++;
            print("CountToHundred: " + i);
            }
            
        }
    }
    
}
