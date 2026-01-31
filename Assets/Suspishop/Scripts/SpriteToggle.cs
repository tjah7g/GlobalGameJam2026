using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class SpriteToggle : MonoBehaviour
{
    [SerializeField] private GameObject spriteB;

    private void OnMouseDown()
    {
        this.gameObject.SetActive(false);
        spriteB.SetActive(true);
    }
}
