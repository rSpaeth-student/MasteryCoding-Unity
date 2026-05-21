using UnityEngine;

[CreateAssetMenu()]
public class Creature_SO : ScriptableObject
{
    [SerializeField] public int attack;
    [SerializeField] public int health;
    [SerializeField] public Sprite image;
}
