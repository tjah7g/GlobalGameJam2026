using UnityEngine;
using System.Collections.Generic;

public class MonsterController : MonoBehaviour
{
    public static MonsterController Instance { get; set; }

    public List<MonsterData> monsterDatas = new();
    public MonsterData currentMonster;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentMonster = GetRandomMonster();
    }

    public MonsterData GetRandomMonster()
    {
        int randomIndex = Random.Range(0, monsterDatas.Count);
        return monsterDatas[randomIndex];
    }

    public void FinishService()
    {
        MaskData currentMask = MaskManager.Instance.selectedMask;
        ServiceResult result = EncounterCalculator.Calculate(currentMask, currentMonster);
        ScoreManager.Instance.ApplyServiceResult(result);

        //MonsterOut();
    }

    //Test Button
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FinishService();
        }
    }
    public void MonsterOut()
    {
        //animasi monster out
    }
}
