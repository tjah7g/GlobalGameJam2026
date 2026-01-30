using System.Collections.Generic;
using UnityEngine;


public enum MaskResult
{
    Weak,
    Match,
    Strong
}
public class MaskManager : MonoBehaviour
{
    public static MaskManager Instance { get; set; }

    public MaskData selectedMask;
    void Awake()
    {
        Instance = this;
    }
    
    public MaskResult EvaluateMask()
    {
        int monsterStrength = MonsterController.Instance.currentMonster.monsterLevel;

        if(selectedMask.maskLevel < monsterStrength)
        {
            return MaskResult.Weak;
        }

        if(selectedMask.maskLevel > monsterStrength)
        {
            return MaskResult.Strong;
        }

        return MaskResult.Match;
    }
}
