using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorConcepts : MonoBehaviour
{
     void Start()
    {
        Vector3 testA = new Vector3(2.5f, 5.0f, 3.3f);
        Vector3 testB = new Vector3(5.0f, 10.0f, 15.0f);

        // The $ character before a string indicates that each section bracketed by {} brackets is a block of code.
        // This allows you to call code / insert variables into a string without adding strings together
        print($"SumX: {SumX(new Vector3(1,0,0), new Vector3(0,1,0))}");
        print($"OneToMagnitude(7): {OneToMagnitude(7)}");
        print($"NormalizeVector(Vector3(2.5, 5.0, 3.3)): {NormalizeVector(testA)}");
        print($"VectorMagnitude(Vector3(2.5, 5.0, 3.3)): {VectorMagnitude(testA)}");
        print($"DirectionFromAToBo(testA, testB): {DirectionFromAToB(testA,testB)}");
    }

    // Return the sum of the x value of a and the x value of b.
    float SumX(Vector3 a, Vector3 b)
    {
        return a.x + b.x;
    }

    // Return a new Vector3 with the x, y, and z values equal to the magnitude parameter.
    Vector3 OneToMagnitude(float magnitude)
    {
        return Vector3.one * magnitude;
    }

    // Return the unit vector of the parameter v.
    Vector3 NormalizeVector(Vector3 v)
    {
        return v.normalized;
    }

    // Return the magnitude of the parameter v.
    float VectorMagnitude(Vector3 v)
    {
        return v.magnitude;
    }

    // Return a normalized vector3 representing the direction from point A to point B.
    Vector3 DirectionFromAToB(Vector3 A, Vector3 B)
    {
        return (B-A).normalized;
    }
}
