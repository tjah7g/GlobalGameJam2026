using UnityEngine;

public class MaskSceneObject : MonoBehaviour
{
    [SerializeField]
    private MaskData maskData;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = maskData.sprite;
    }

    private void OnMouseEnter()
    {
        spriteRenderer.sprite = maskData.spriteHover;
    }
    
    private void OnMouseExit()
    {
        spriteRenderer.sprite = maskData.sprite;
    }
}
