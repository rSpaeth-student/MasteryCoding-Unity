using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Vector3 offset = new Vector3(3,0,0);
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SummonMonster();
        }
    }
    [SerializeField] private LineRenderer tracerPrefab;
    private List<Monster> monsters = new List<Monster>();
    [SerializeField] LayerMask layerMask;
    [SerializeField] private GameObject launchPosition;
    [SerializeField] private GameObject cardPrefab;
    private bool isMonsterSummoned = false;
    private Transform playerTransform;

    private void Shoot(Vector3 shootPosition, Vector3 targetPosition, float duration)
    {
        GameObject card = Instantiate(cardPrefab, shootPosition, Quaternion.identity);
        Vector3 shootDirection = (targetPosition - shootPosition).normalized;


        card.GetComponent<Card>().Setup(shootDirection, this, duration);
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
                Shoot(launchPosition.transform.position, hit.transform.position, 5f);
            }
            else
            {
                Debug.DrawRay(launchPosition.transform.position, launchPosition.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

    }

    private void SummonMonster()
    {

        if (isMonsterSummoned) return;

        StartCoroutine(cardRoutine());
    }

    private IEnumerator cardRoutine()
    {
        isMonsterSummoned = true;
        //get player transform
        
        
        
        playerTransform = GetComponent<Transform>();
        Debug.Log(playerTransform.position);

        playerTransform.position += offset; //offset player transform
        Debug.Log(playerTransform.position);

        Shoot(launchPosition.transform.position, playerTransform.position + offset, 1f);

        //shoot card at offset transform
        yield return new WaitForSeconds(1);

        monsters[0].gameObject.SetActive(true);
        //change monster transform to players offset transform
        monsters[0].gameObject.transform.position = playerTransform.position + offset;
        

       // monsters[0].gameObject.SetActive(true);

        //summon monster
        isMonsterSummoned = false;
    }
}
