using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Board))]
public class Enemy : MonoBehaviour
{
    public GameEvent Defeated;
    public Board board;

    [Header("Creatures")]
    public GameObject creaturePrefab;
    public List<Creature_SO> creatureTypes = new List<Creature_SO>();
    Queue<Creature_SO> creatureQueue = new Queue<Creature_SO>();
    List<Creature> creatures = new List<Creature>();

    [Header("Turn Sequence")]
    public float startDelay = 2f; 
    public float attackDelay = 1f;
    public float spawnDelay = 1f;

    public void StartTurn()
    {
        //Debug.Log(TurnStateMachine.TurnState);
        if (TurnStateMachine.TurnState == TurnStateMachine.State.GameOver) return;
        
        TurnStateMachine.TurnState = TurnStateMachine.State.EnemyTurn;
        StartCoroutine(TurnSequence());
    }

    public void EndTurn()
    {
        if (TurnStateMachine.TurnState == TurnStateMachine.State.GameOver) return;
        FindFirstObjectByType<Player>().StartTurn();
    }

    void Awake()
    {
        board = GetComponent<Board>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < creatureTypes.Count; i++) creatureQueue.Enqueue(creatureTypes[i]);
        SpawnCreature(creatureQueue.Dequeue());
        SpawnCreature(creatureQueue.Dequeue());
        SpawnCreature(creatureQueue.Dequeue());

        StartCoroutine(TurnSequence());
    }

    void SpawnCreature(Creature_SO creatureType)
    {
        Creature newCreature = board.NewBoardItem(creaturePrefab).GetComponent<Creature>();
        newCreature.CreatureType = creatureType;
        creatures.Add(newCreature);
    }

    void DestroyCreature(Creature creature)
    {
        board.DestroyBoardItem(creature);
        creatures.Remove(creature);
        Destroy(creature.gameObject);
    }

    IEnumerator TurnSequence()
    {
        //Debug.Log(TurnStateMachine.TurnState);
        if (TurnStateMachine.TurnState != TurnStateMachine.State.PlayerTurn)
        {
            yield return new WaitForSeconds(startDelay);
            Player player = FindFirstObjectByType<Player>();

            for (int i = 0; i < creatures.Count; i++)
            {
                creatures[i].offset = Vector3.down;
                player.Health -= creatures[i].Attack;
                CameraShake.Shake();
                yield return new WaitForSeconds(attackDelay); //put a check to see if any creatures left 
                                                              //if (creatures.length <= 0) break;
                creatures[i].offset = Vector3.zero;
                //
            }

            yield return new WaitForSeconds(spawnDelay);

            if (creatureQueue.Count > 0) SpawnCreature(creatureQueue.Dequeue());

            EndTurn();
        }

    }

    public void PostCardPlayed()
    {
        List<Creature> deadCreatures = new List<Creature>();

        foreach (Creature c in creatures) if (c.Health <= 0) deadCreatures.Add(c);
        foreach (Creature c in deadCreatures) DestroyCreature(c);

        if (creatures.Count == 0 && creatureQueue.Count == 0) Defeated.RaiseEvent();
    }
}
