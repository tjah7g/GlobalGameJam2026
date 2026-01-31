using UnityEngine;

public class MonsterRenderer : MonoBehaviour
{
    public SpriteRenderer monster;
    public SpriteRenderer monsterSiluet;

    public void SetMonsterVisual()
    {
        this.monster.sprite = MonsterController.Instance.currentMonster.sprite;
        this.monsterSiluet.sprite = MonsterController.Instance.currentMonster.spriteSiluet;
    }
}
