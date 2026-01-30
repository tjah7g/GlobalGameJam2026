using UnityEngine;

public class GameManager : MonoBehaviour
{
    MonsterData currentMonsterLevel;
    MaskData currentMaskStrength;

    void ResolveGameState()
    {
        currentMonsterLevel = MonsterController.Instance.currentMonster;
        currentMaskStrength = MaskManager.Instance.selectedMask;

        ServiceResult result = EncounterCalculator.Calculate(currentMaskStrength, currentMonsterLevel);
        ScoreManager.Instance.ApplyServiceResult(result);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("ASDASD");
            ResolveGameState();
        }
    }
}
