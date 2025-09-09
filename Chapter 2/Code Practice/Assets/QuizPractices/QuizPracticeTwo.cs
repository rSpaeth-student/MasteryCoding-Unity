using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizPracticeTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] numbersOne = {0, 1, 2, 3};
        int[] numbersTwo = numbersOne;

        for (int i = 0; i < numbersOne.Length; i++)
        {
            numbersOne[i]++;
        }

        print(numbersTwo[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
