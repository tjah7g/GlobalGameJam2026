using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class SubmitOrderButton : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color normalColor = Color.white;
    public Color pressedColor = Color.gray;

    public UnityEvent onClick;

    void Awake()
    {
        if (!spriteRenderer)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OMouseDown()
    {
        spriteRenderer.color = pressedColor;
    }

    private void OnMouseUpAsButton()
    {
        spriteRenderer.color = normalColor;
        onClick?.Invoke();
    }

    private void OnMouseEnter()
    {
        spriteRenderer.color = normalColor;
    }
}
