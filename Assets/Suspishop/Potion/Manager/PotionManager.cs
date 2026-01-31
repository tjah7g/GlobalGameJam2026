using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotionManager : MonoBehaviour
{
    public static PotionManager Instance { get; set; }

    public List<PotionData> potionDatas = new List<PotionData>();

    public List<Potion> potions = new List<Potion>();

    public Sprite defaultSprite;

    public UnityEvent onPotionSubmitted;

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

    void Start()
    {
        LoadPotionData();
    }

    public void LoadPotionData()
    {
        for (int i = 0; i < potions.Count; i++)
        {
            potions[i].SetupPotion(potionDatas[i].potionId, potionDatas[i].sprite ? potionDatas[i].sprite : defaultSprite);
        }
    }

    public void SubmitPotion()
    {
        foreach (var potion in potions)
        {
            if (potion.potionStatus == PotionStatus.Selected)
            {
                ShoppingManager.Instance.SetPlayerSubmit(potion.potionId);
            }
        }

        onPotionSubmitted?.Invoke();
    }

    public void CancelSubmission()
    {
        foreach (var potion in potions)
        {
            if (potion.potionStatus == PotionStatus.Selected)
            {
                potion.potionStatus = PotionStatus.Available;
                potion.SetPotionBacktoOriginalPos();
            }
        }
    }
}
