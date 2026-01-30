using System.Collections.Generic;
using UnityEngine;
public struct ServiceResult
{
    public float suspicionGrowth;
    public int goldEarned;
}

public static class EncounterCalculator
{
    private static readonly Dictionary<int, float> GoldBonusTable = new()
    {
        {1, 0.2f },
        {2, 0.5f }
    };
    public static ServiceResult Calculate(MaskData mask, MonsterData monster)
    {
        float susGrowth = CalculateSusGrowth(mask.maskLevel, monster.monsterLevel);
        int gold = CalculateGold(monster.baseGold, mask.maskLevel, monster.monsterLevel);

        return new ServiceResult
        {
            suspicionGrowth = susGrowth,
            goldEarned = gold
        };
    }

    private static int CalculateGold(int baseGold, int maskLevel, int monsterLevel)
    {
        int diff = maskLevel - monsterLevel;
        if (diff <= 0) return baseGold;

        float bonusMultiplier = GoldBonusTable.TryGetValue(diff, out float bonus)
            ? bonus
            : 0f;

        return Mathf.RoundToInt(baseGold * (1f + bonusMultiplier));
    }

    public static float CalculateSusGrowth(int maskLevel, int enemyLevel)
    {
        int diff = maskLevel - enemyLevel;

        if (diff == 0) return 0f;

        if (diff == 1)
            return 0.25f;
        else
            return 0.5f;
    }

    public static float CalculateGoldBonus(int maskLevel, int enemyLevel)
    {
        int diff = maskLevel - enemyLevel;

        if (diff <= 0)
            return 0f;

        return GoldBonusTable.TryGetValue(diff, out float bonus)
            ? bonus
            : 0f;
    }
}
