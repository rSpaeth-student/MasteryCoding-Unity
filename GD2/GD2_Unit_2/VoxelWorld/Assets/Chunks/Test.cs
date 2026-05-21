using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Chunk.SetVoxelType(0, 2, 0, Voxel.Type.Grass);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
