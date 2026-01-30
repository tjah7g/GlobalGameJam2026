using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Story", menuName = "Scriptable Objects/Cutscenes")]
public class Cutscenes_SObj : ScriptableObject
{
    public List<Sprite> scenes;
}
