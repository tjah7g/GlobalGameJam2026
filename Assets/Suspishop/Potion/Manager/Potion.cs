using UnityEngine;

public enum PotionStatus
{
    Available,
    Selected
}

public class Potion : MonoBehaviour
{
    public int potionId;
    public SpriteRenderer spriteRenderer;
    public PotionStatus potionStatus;

    void Awake()
    {
        if (!spriteRenderer)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetupPotion(int id, Sprite sprite)
    {
        potionId = id;
        spriteRenderer.sprite = sprite;
    }

    public void SetPotionSelected()
    {
        potionStatus = PotionStatus.Selected;
    }
}
