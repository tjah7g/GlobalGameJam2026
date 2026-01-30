using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {  get; private set; }

    public int gold;
    public float suspicion;

    public event Action<int> OnSuspicionChanged;
    public event Action<int> OnGoldChanged;

    private void Awake()
    {
        Instance = this;
    }
    public void ResolveEncounter(int maskLevel, int monsterLevel)
    {
        maskLevel = MaskManager.Instance.selectedMask.maskLevel;
        monsterLevel = MonsterController.Instance.currentMonster.monsterLevel;

        float susGrowth = EncounterCalculator.CalculateSusGrowth(maskLevel, monsterLevel);
        float goldBonus = EncounterCalculator.CalculateGoldBonus(maskLevel, monsterLevel);

        ApplySuspicion(susGrowth);
        ApplyGoldBonus(goldBonus);
    }

    private void ApplySuspicion(float value)
    {
        if (value <= 0f)
        {
            return;
        }

        suspicion = Mathf.Clamp01(suspicion + value);
        OnSuspicionChanged?.Invoke((int)suspicion);
    }

    private void ApplyGoldBonus(float bonusMultiplier)
    {
        if(bonusMultiplier <= 0f)
        {
            return;
        }
        int baseGold = 10;
        int bonusGold = Mathf.RoundToInt(baseGold * bonusMultiplier);

        gold += bonusGold;
        OnGoldChanged?.Invoke(gold);
    }

    public void ApplyServiceResult(ServiceResult result)
    {
        suspicion = Mathf.Clamp01(suspicion + result.suspicionGrowth);
        gold += result.goldEarned;

        Debug.Log($"Service done → Gold +{result.goldEarned}, Sus +{result.suspicionGrowth}");
    }

    //AddGold
    //SubtractGold

    //AddSuspicion
    //SubtractSuspicion
}
