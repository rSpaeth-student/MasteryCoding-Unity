using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;


    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
        TurnStateMachine.TurnState = TurnStateMachine.State.EnemyTurn;
    }

    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void GameOver() => TurnStateMachine.TurnState = TurnStateMachine.State.GameOver;

    void Start()
    {
        
    }
}
