using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public GameState CurrentState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartDay(); // entry point
    }

    public void StartDay()
    {
        DayManager.Instance.StartNewDay();
        StartServing();
    }

    public void StartServing()
    {
        ChangeState(GameState.Serving);
    }

    public void StartEvaluation()
    {
        ChangeState(GameState.Evaluating);
    }

    public void EndState()
    {

        // Penentuan ending disini
        if (ScoreManager.Instance.gold >= 75)
            SceneLoader.Instance.Load("Ending_Good");
        else
            SceneLoader.Instance.Load("Ending_Bad");
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log("State: " + newState);
    }
}
