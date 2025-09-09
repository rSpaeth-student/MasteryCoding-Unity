using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        
    }
    [SerializeField] private LineRenderer tracerPrefab;
    private List<Monster> monsters = new List<Monster>();
    [SerializeField] LayerMask layerMask;
    [SerializeField] private GameObject launchPosition;
    [SerializeField] private GameObject cardPrefab;

    private void Shoot(Vector3 shootPosition, Vector3 targetPosition)
    {
        GameObject card = Instantiate(cardPrefab, shootPosition, Quaternion.identity);
        Vector3 shootDirection = (targetPosition - shootPosition).normalized;

        card.GetComponent<Card>().Setup(shootDirection, this);
    }

    public List<Monster> GetMonsters()
    {
        return monsters;
    }

    public void DisplayMonsters()
    {
        foreach (Monster monster in monsters)
        {
            Debug.Log(monster.getMonsterName()); //displays every monster we have   
        }

    }
    
    void Awake()
    {
        layerMask = LayerMask.GetMask("Wall", "Character");
    }
    
    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LineRenderer line = Instantiate(tracerPrefab, launchPosition.transform.position, Quaternion.identity);
            line.SetPosition(0, launchPosition.transform.position);
            line.SetPosition(1, launchPosition.transform.position + launchPosition.transform.TransformDirection(Vector3.forward) * 100f);
            Destroy(line.gameObject, 5f);

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(launchPosition.transform.position, launchPosition.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))

            {
                Debug.DrawRay(launchPosition.transform.position, launchPosition.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                Debug.Log("Did Hit");
                Shoot(launchPosition.transform.position, hit.transform.position);
            }
            else
            {
                Debug.DrawRay(launchPosition.transform.position, launchPosition.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

    }
}
