using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MaskResult
{
    Weak,
    Match,
    Strong
}
public class MaskManager : MonoBehaviour
{
    public static MaskManager Instance { get; private set; }

    public List<MaskData> masks = new();

    [field: SerializeField]
    public MaskData selectedMask { get; private set; }

    public event System.Action<MaskData> OnMaskChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
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

    public void SetSelectedMask(MaskData maskData)
    {
        selectedMask = maskData;
        OnMaskChanged?.Invoke(maskData);
    }
}
