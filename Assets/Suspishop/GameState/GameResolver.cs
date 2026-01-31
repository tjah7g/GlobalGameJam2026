using NUnit.Framework.Interfaces;
using UnityEngine;
using static ShoppingManager;

public static class GameResolver
{
    public static void Resolve(ShoppingResult shoppingResult)
    {
        // Lock the game
        GameStateManager.Instance.ChangeState(GameState.Evaluating);

        // Evaluate mask vs monster result
        MonsterData currentMonster = MonsterController.Instance.currentMonster;
        MaskData currentMask = MaskManager.Instance.selectedMask;

        ServiceResult result = EncounterCalculator.Calculate(currentMask, currentMonster);
        var sm = ScoreManager.Instance;

        // apply suspicion changes
        sm.AddSuspicion(result.suspicionGrowth);

        // apply gold changes
        if (shoppingResult == ShoppingResult.Success)
            sm.AddGold(result.goldEarned);
        else
            sm.AddGold(0);

        // Tell the day system we're done with this monster
        DayManager.Instance.OnMonsterServed();
    }
}
