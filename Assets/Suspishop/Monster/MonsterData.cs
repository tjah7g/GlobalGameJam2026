using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/MonsterData")]
public class MonsterData : ScriptableObject
{
    public int baseGold;
    public int monsterLevel;
    public Sprite sprite;
    public Sprite spriteSiluet;
}
