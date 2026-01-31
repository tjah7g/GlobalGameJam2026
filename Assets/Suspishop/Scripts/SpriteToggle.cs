using SmallHedge.SoundManager;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class SpriteToggle : MonoBehaviour
{
    [SerializeField] private GameObject spriteB;
    public UnityEvent OnClicked;

    private void OnMouseDown()
    {
        PlayOpenSFX();
        CloseDoor();
    }

    public void CloseDoor()
    {
        this.gameObject.SetActive(false);
        spriteB.SetActive(true);
        PlayClosedSFX();
    }

    void PlayClosedSFX()
    {
        SoundManager.PlaySound(SoundType.DoorClosedSFX);
    }

    void PlayOpenSFX()
    {
        SoundManager.PlaySound(SoundType.DoorOpenSFX);
    }
}
