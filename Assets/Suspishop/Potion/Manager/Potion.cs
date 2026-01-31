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
    Vector3 initialPosition;

    void Awake()
    {
        if (!spriteRenderer)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        initialPosition = transform.position;
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

    public void SetPotionBacktoOriginalPos()
    {
        this.transform.position = initialPosition;
    }
}
