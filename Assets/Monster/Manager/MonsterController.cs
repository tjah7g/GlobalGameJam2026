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
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentMonster = GetMonster(0);
    }

    public MonsterData GetMonster(int MonsterLevel)
    {
        return monsterDatas[MonsterLevel];
    }


}
