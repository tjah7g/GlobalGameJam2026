using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score;

    private void Awake()
    {
        instance = this;
    }
    
    public void AddScore(int amount)
    {
        score += amount;
    }
}
