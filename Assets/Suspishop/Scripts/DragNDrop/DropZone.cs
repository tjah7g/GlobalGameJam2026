using UnityEngine;

public class DropZone : MonoBehaviour, IObjectDropArea
{
    public void OnObjectDrop(ObjectDrag obj)
    {
        obj.transform.position = transform.position;
        Debug.Log("Potion Dropped.");

        if (obj.TryGetComponent(out Potion potion))
        {
            potion.SetPotionSelected();
        }
    }
}
