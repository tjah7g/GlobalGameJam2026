using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class MonsterController : MonoBehaviour
{
    public static MonsterController Instance { get; set; }

    public List<MonsterData> monsterDatas = new();

    [field: SerializeField]
    public MonsterData currentMonster { get; private set; }

    public UnityEvent SetMonster;

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
        // GetRandomMonsterByLevel(1);
    }

    public MonsterData GetRandomMonster()
    {
        int randomIndex = Random.Range(0, monsterDatas.Count);
        return monsterDatas[randomIndex];
    }

    public MonsterData GetRandomMonsterByLevel(int level)
    {
        List<MonsterData> monsterLevelData = new();

        monsterLevelData.Clear();

        foreach(var monster in monsterDatas)
        {
            if (monster.monsterLevel == level)
            {
                monsterLevelData.Add(monster);
            }
        }

        int randomIndex = Random.Range(0, monsterLevelData.Count);
        return monsterLevelData[randomIndex];
    }

    public MonsterData GetMonsterByLevel(int level)
    {
        return monsterDatas[level];
    }

    public void SetCurrentMonster(MonsterData monsterData)
    {
        currentMonster = monsterData;
        SetMonster?.Invoke();
    }

    public void MonsterOut()
    {
        currentMonster = null;
    }
}
