using SmallHedge.SoundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    public int currentDay = 1;
    public int maxDay = 3;
    public int monstersPerDay = 5;

    [SerializeField]
    private int monstersServed;

    public List<MonsterData> monsterLevel1 = new();
    public List<MonsterData> monsterLevel2 = new();
    public List<MonsterData> monsterLevel3 = new();

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
            GameStateManager.Instance.EndState();
        }
    }

    void SetupMonster()
    {
        // // Set CurrentMonster
        // var mc = MonsterController.Instance;
        // mc.SetCurrentMonster(mc.GetRandomMonsterByLevel(currentDay));
        // 
        // // Set Monster Item Request
        // StartCoroutine(ShoppingManager.Instance.GetCurrentMonster());

        if (currentDay == 1)
        {
            int randomIndex = Random.Range(0, monsterLevel1.Count);
            MonsterController.Instance.SetCurrentMonster(monsterLevel1[randomIndex]);

            monsterLevel1.Remove(monsterLevel1[randomIndex]);
            StartCoroutine(ShoppingManager.Instance.GetCurrentMonster());
        }
        else if (currentDay == 2)
        {
            int randomIndex = Random.Range(0, monsterLevel2.Count);
            MonsterController.Instance.SetCurrentMonster(monsterLevel2[randomIndex]);

            monsterLevel2.Remove(monsterLevel2[randomIndex]);
            StartCoroutine(ShoppingManager.Instance.GetCurrentMonster());
        }
        else if (currentDay == 3)
        {
            int randomIndex = Random.Range(0, monsterLevel3.Count);
            MonsterController.Instance.SetCurrentMonster(monsterLevel3[randomIndex]);

            monsterLevel3.Remove(monsterLevel3[randomIndex]);
            StartCoroutine(ShoppingManager.Instance.GetCurrentMonster());
        }
        StartCoroutine(PlayKnockSound());
    }

    IEnumerator PlayKnockSound()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.PlaySound(SoundType.KnockSFX);
    }
}