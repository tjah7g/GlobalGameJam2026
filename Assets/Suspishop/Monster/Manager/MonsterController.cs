using UnityEngine;
using System.Collections.Generic;

public class MonsterController : MonoBehaviour
{
    public static MonsterController Instance { get; set; }

    public List<MonsterData> monsterDatas = new();

    [field: SerializeField]
    public MonsterData currentMonster { get; private set; }

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
        
    }

    public MonsterData GetRandomMonster()
    {
        int randomIndex = Random.Range(0, monsterDatas.Count);
        return monsterDatas[randomIndex];
    }

    public MonsterData GetMonsterByLevel(int level)
    {
        return monsterDatas[level];
    }

    public void SetCurrentMonster(MonsterData monsterData)
    {
        currentMonster = monsterData;
    }

    public void MonsterOut()
    {
        currentMonster = null;
    }
}
