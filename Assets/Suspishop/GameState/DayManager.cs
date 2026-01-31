using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    public int currentDay = 1;
    public int maxDay = 3;
    public int monstersPerDay = 5;

    [SerializeField]
    private int monstersServed;

    void Awake()
    {
        Instance = this;
    }

    public void StartNewDay()
    {
        monstersServed = 0;

        Debug.Log("Starting the dayyy");

        SetupMonster();
    }

    public void OnMonsterServed()
    {
        monstersServed++;
        ShoppingManager.Instance.ClearOrders();
        Debug.Log("Monster Served!");

        if (monstersServed >= monstersPerDay)
        {
            EndDay();
        }
        else
        {
            GameStateManager.Instance.StartServing();
            SetupMonster();
        }
    }

    void EndDay()
    {
        Debug.Log("Day " + currentDay + " End!");

        if(currentDay <= maxDay)
        {
            currentDay++;
            StartNewDay();
        }
        else
        {
            GameStateManager.Instance.EndDay();
        }
    }

    void SetupMonster()
    {
        // Set CurrentMonster
        var mc = MonsterController.Instance;
        mc.SetCurrentMonster(mc.GetRandomMonster());

        // Set Monster Item Request
        StartCoroutine(ShoppingManager.Instance.GetCurrentMonster());
    }
}