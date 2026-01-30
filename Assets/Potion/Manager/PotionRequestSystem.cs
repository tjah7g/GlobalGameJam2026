using System.Collections.Generic;
using UnityEngine;

public class PotionRequestSystem : MonoBehaviour
{
    public static PotionRequestSystem instance;

    public int[] playerSubmit;
    public List<int> monsterReq = new();

    public int[] potions = { 1,2,3,4,5,6 };

    int submittedItemCount;
    int requestedItemCount;

    void Start()
    {
        requestedItemCount = MonsterController.Instance.currentMonster.monsterLevel;
        RandomMonsterReq();
    }

    void PlayerSubmit()
    {
        
    }

    public void RandomMonsterReq()
    {
        for (int i = 0; i < requestedItemCount; i++)
        {
            int itemSelected = Random.RandomRange(0, potions.Length);
            monsterReq.Add(itemSelected);
        }
    }
}
