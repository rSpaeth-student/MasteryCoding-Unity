using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Player player;
    private Vector3 direction;
    private float speed = 20f;
    public float duration = 5f;

    public void Setup(Vector3 dir, Player player, float duration)
    {
        this.player = player;
        direction = dir.normalized;
        this.duration = duration;
        Destroy(gameObject, duration); // 
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Monster>(out Monster monster))
        {
            player.GetMonsters().Add(monster); //passing the reference
            player.DisplayMonsters();
            monster.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    
}
