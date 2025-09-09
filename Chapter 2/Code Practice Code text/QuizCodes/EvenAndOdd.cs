using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizPracticeTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        // Comment goes here
        for (int i = 0; i < numbers.Length; i++)
        {
            if ((i % 2) == 1)
            {
                print("odd");
            }
            else
            {
                print("even");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}