using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizPractice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float damage = 5.0f;
        float health = 3.0f;
        int lives = 3;

        health -= damage;

        if(health <= 0.0f && lives <= 1)
        {
            print("Out of lives.");
            lives--;
        }
        else if (health <= 0.0f && lives == 2)
        {
            print("Only one life left.");
            lives--;
        }
        else
        {
            print(--lives + " lives left.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
