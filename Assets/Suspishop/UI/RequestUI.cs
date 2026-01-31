using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestUI : MonoBehaviour
{
    public static RequestUI Instance;

    [Header("Request Slots (Max 3)")]
    [SerializeField] private List<SpriteRenderer> requestSlots;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RefreshUI(List<int> monsterReq)
    {
        // Clear semua slot dulu
        for (int i = 0; i < requestSlots.Count; i++)
        {
            requestSlots[i].sprite = null;
            requestSlots[i].gameObject.SetActive(false);
        }

        // Isi slot sesuai jumlah request (1–3)
        int count = Mathf.Min(monsterReq.Count, requestSlots.Count);

        for (int i = 0; i < count; i++)
        {
            Sprite sprite = GetPotionSprite(monsterReq[i]);
            requestSlots[i].sprite = sprite;
            requestSlots[i].gameObject.SetActive(true);
        }
    }

    private Sprite GetPotionSprite(int potionId)
    {
        var data = PotionManager.Instance.potionDatas
            .Find(p => p.potionId == potionId);

        if (data == null)
        {
            Debug.LogWarning($"PotionData not found for ID {potionId}");
            return PotionManager.Instance.defaultSprite;
        }

        return data.sprite;
    }
}
