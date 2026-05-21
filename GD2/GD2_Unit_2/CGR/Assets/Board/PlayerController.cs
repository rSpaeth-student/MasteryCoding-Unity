using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Board hand;
    BoardItem dragTarget;
    Player player;

    Board enemyBoard;
    Creature targetCreature;

    void Awake()
    {
        hand = GetComponent<Board>();
        player = GetComponent<Player>();
        // Find enemy board
        enemyBoard = FindAnyObjectByType<Enemy>().GetComponent<Board>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player.StartTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            player.EndTurn();
            return;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        BoardItem focusTarget = hand.GetNearestBoardItem(mousePosition);
        hand.focusTarget = focusTarget;

        // New Section
        targetCreature = enemyBoard.GetNearestBoardItem(mousePosition) as Creature;
        // end new section

        if (Input.GetMouseButtonDown(0)) dragTarget = hand.GetNearestBoardItem(mousePosition);
        //if (Input.GetMouseButtonUp(0)) dragTarget = null;
        if (Input.GetMouseButtonUp(0))
        {
            // if (!hand.InBoardArea(mousePosition)) player.TryPlayCard(dragTarget as Card);

            if (!hand.InBoardArea(mousePosition) && targetCreature) player.TryPlayCard(dragTarget as Card, targetCreature);
            //the && is check to make sure if the targetCreature is null
            dragTarget = null;
        }

        // Set drag target even if null
        hand.SetDragTarget(dragTarget, mousePosition);
    }
}
