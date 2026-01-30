using UnityEngine;

public static class SuspicionCounter
{

    public static float CounterSusGrowth(int maskLevel, int monsterLevel, float maxSusGrowth = 0.5f)
    {
       maskLevel = MaskManager.Instance.selectedMask.maskLevel;
       monsterLevel = MonsterController.Instance.currentMonster.monsterLevel;

        if (maskLevel >= monsterLevel)
        {
            return 0;
        }

        float growth = (float)(monsterLevel - maskLevel) / monsterLevel ;

        return Mathf.Clamp(growth, 0f, maxSusGrowth);
    }
}
