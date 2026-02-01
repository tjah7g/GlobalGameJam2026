using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class SpriteButton : MonoBehaviour
{
    public UnityEvent onClick;

    private void OnMouseUpAsButton()
    {
        onClick?.Invoke();
    }
}
