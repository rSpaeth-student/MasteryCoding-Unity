using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string playerStatus = "Idle";
        float health = 3.0f;
        float damage = 0.0f;
        float maxHealth = 5.0f;
        float velocity = 0.0f;

        if(playerStatus == "Idle")
        {
            if (health < maxHealth || damage > 0.0f)
            {
                playerStatus = "Damaged";
            }
        }
        else if (playerStatus != "Idle")
        {
            if (velocity == 0.0f)
            {
                playerStatus = "Idle";
            }
            else 
            {
                playerStatus = "Moving";
            }
        }
        print(playerStatus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
