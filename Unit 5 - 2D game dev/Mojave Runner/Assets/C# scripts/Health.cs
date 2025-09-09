using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthAmount = 3;

    public void TakeDamage(int damageAmount)
    {
        healthAmount -= damageAmount;

        if (healthAmount <= 0)
        {
            GameManager.instance.Restart();
        }
    }

    public static void TryDamageTarget(GameObject target, int damageAmount)
    {
        Health targetHealth = target.GetComponent<Health>();

        if(targetHealth)
        {
            targetHealth.TakeDamage(damageAmount);
        }
    }
}
