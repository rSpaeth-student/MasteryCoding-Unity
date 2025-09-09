using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalPractice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Should print false since 25 isn't greater than or equal to 200.
        GreaterThanOrEqualTo(25, 200);

        // Should print true since 4 is even.
        IsEven(4);

        //Should print A.
        GetLetterGrade(91);
        //Should print C.
        GetLetterGrade(75);
       
    }

    void GreaterThanOrEqualTo(int numOne, int numTwo)
    {
        if(numOne > numTwo)
        {
            print("First number is greater than the second.");
        }
        else if(numOne < numTwo)
        {
            print("Second number is greater than the first.");
        }
        else 
        {
            print("They are equal.");
        }
    }
    void IsEven(int num)
    {
        if(num % 2 == 0)
        {
            print("number is even.");
        }
        else 
        {
            print("Number is odd.");
        }
    }

    void GetLetterGrade(float percentage)
    {
        if (percentage >= 90)

        {
            print("A");
        }
        else if (percentage >= 80)
        {
            print("B");
        }
        else if(percentage >= 70)
        {
            print("C");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
