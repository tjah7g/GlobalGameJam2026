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

    public void EndDay()
    {
        ChangeState(GameState.DayEnd);


        // Penentuan ending disini
        if (true)
            SceneLoader.Instance.Load("EndingScene1");
        else
            SceneLoader.Instance.Load("EndingScene2");
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log("State: " + newState);
    }
}
