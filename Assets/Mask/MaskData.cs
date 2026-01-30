using UnityEngine;

[CreateAssetMenu(fileName = "MaskData", menuName = "Scriptable Objects/MaskData")]
public class MaskData : ScriptableObject
{
    public int durability;
    public int maskLevel;
    public Sprite sprite;
}
