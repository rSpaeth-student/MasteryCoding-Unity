using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class Creature : BoardItem
{
    

    private Creature_SO creatureType;
    //the reason that these are private is because we're going to use public properties 
    //to allow access to them
    private int health;
    private int attack;

    // UI components
    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI attackDisplay;
    public Image creatureImage;

    public Creature_SO CreatureType
    {
        get => creatureType;
        set
        {
            creatureType = value;
            creatureImage.sprite = creatureType.image;
            Health = creatureType.health;
            Attack = creatureType.attack;
        }
    }

    // Properties
    public int Health
    {
        get => health;
        set
        {
            health = value;
            healthDisplay.text = health.ToString();
        }
    }

    public int Attack
    {
        get => attack;
        set
        {
            attack = value;
            attackDisplay.text = attack.ToString();
        }
    }
}
