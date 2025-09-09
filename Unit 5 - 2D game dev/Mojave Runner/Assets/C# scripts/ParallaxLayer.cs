using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax
{
    public enum Layer
    {
        Foreground, Midground, Background
    }
    public static float speed = 2f;

    public static float GetSpeed(Layer layer)
    {
        switch (layer) //returns how fast you want an object on that layer to be.
        {
            case Layer.Foreground:
            return speed * 3f;

            case Layer.Midground:
            return speed * 0.5f;
           
            case Layer.Background:
            return speed * 0.1f;
            default:
            return speed * 1f;
           
        }
    }
}

public class ParallaxLayer : MonoBehaviour
{
    public Transform[] tiles;

    public float left = -19f;
    public Vector3 right = new Vector3(19f, 0f, 0f);

    public Parallax.Layer layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].position += Vector3.left * Time.deltaTime * Parallax.GetSpeed(layer);

            // Tile has gone too far to the left <-
            if(tiles[i].position.x <= left)
            {
                // Reset tile position to the right ->
                tiles[i].position = right;
            }
        }
    }
}
