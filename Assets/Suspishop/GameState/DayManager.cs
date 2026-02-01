using SmallHedge.SoundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    public int currentDay = 1;
    public int maxDay = 3;
    public int monstersPerDay = 5;

    private Transform cam;

    [SerializeField]
    private int monstersServed;

    public List<MonsterData> monsterLevel1 = new();
    public List<MonsterData> monsterLevel2 = new();
    public List<MonsterData> monsterLevel3 = new();

    void Awake()
    {
        Instance = this;
        cam = Camera.main.transform;
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

        var sm = ScoreManager.Instance;

        if (sm.suspicion >= 1)
        {
            sm.SubtractSuspicion(sm.suspicion);
            sm.SubtractGold(20);
            cam.DOShakePosition(.2f, 1f);
        }

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

        if(currentDay < maxDay)
        {
            StartCoroutine(WaitBeforeNextDay());
        }
        else
        {
            GameStateManager.Instance.EndState();
        }
    }

    IEnumerator WaitBeforeNextDay()
    {
        currentDay++;
        UIManager.Instance.TriggerDayTransition();
        yield return new WaitForSeconds(3);

        StartNewDay();
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