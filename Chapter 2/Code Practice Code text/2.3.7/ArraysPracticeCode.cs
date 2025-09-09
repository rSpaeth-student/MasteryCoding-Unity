using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraysPractice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LinearSearch(numbers, 30);
        ConcatenationLoop();
        RandomArray(5);
        CopyArrayContents(numbers);
    }
    // Declare an array of integers called numbers with compile time values: 10, 20, 30, 40, 50
    int[] numbers = {10, 20, 30, 40, 50};

    // Declare an array of strings with size 5 and no elements.
    string[] strings = new string[5];

    void LinearSearch(int[] array, int value)
    {
        // Search through numbers until finding value. Once value is found print the index where it was found.
        bool foundIt = false;
        for(int x = 0; x < array.Length; x++)
        {
            if(value == array[x])
			{
				print("Index is: " + x);
				foundIt = true;
			}
		}
		if(!foundIt)
        print("Value not found: " + value);
        
    }

    void ConcatenationLoop()
    {
        // Iterate through the words array, creating a single long string with spaces between each word.
        // Hint: In the body of a for loop, add the current value of words at index to a string, then add a space using += " ";
        string[] words = {"The", "quick", "brown", "fox", " jumps", "over", "the", "lazy", "dog"};

        for(int x = 0; x < words.Length; x++)
        {
            print(words[x] + " ");
        }
    }

    void RandomArray(int size)
    {
        // Declare and initialize a new array of integers with with length [size].
        // Iterate through the array setting the value at each index to a random number between 1 and 10.
        // Hint: to get a random number between 1 and 10, use Random.Range(1, 11); 

        int[] array = new int[size];

        for(int i = array.Length - 1; i >= 0; i--)
        {
            array[i] = Random.Range(1, 11); 
        }
        for(int i = array.Length - 1; i >= 0; i--)
        {
            print(array[i]);
            
        }
    }

    void CopyArrayContents(int[] arrayOne)
    {
        // Declare a new array of integers called arrayTwo with the same length as arrayOne.
        // Iterate through arrayOne copying the value at each index into arrayTwo.

        int[] arrayTwo = new int[arrayOne.Length];

        for(int i = 0; i < arrayOne.Length; i++)
        {
            arrayTwo[i] = arrayOne[i];
        }
        for(int i = arrayTwo.Length - 1; i >= 0; i--)
        {
            print(arrayTwo[i]);
            
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
