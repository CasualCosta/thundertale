using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Reaction
{
    public Sprite sprite;
    public Color enemyColor;
    public Color effectColor = Color.white;
}
public class EnemyReaction : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;
    [SerializeField] SpriteRenderer childRenderer = null;
    [SerializeField] Color originalColor = Color.white;
    [SerializeField] string triggerName = "damage";
    [SerializeField] Reaction iceReaction = null;
    [SerializeField] Reaction fireReaction = null;
    [SerializeField] Reaction thunderReaction = null;


    // Start is called before the first frame update
    void Start() => PlayerButton.OnAttackPress += TriggerReaction;
    private void OnDisable() => PlayerButton.OnAttackPress -= TriggerReaction;

    void TriggerReaction(ButtonType bt)
    {
        animator.SetTrigger(triggerName);
        Reaction reaction = null;
        switch(bt)
        {
            case ButtonType.Thunder: reaction = thunderReaction; break;
            case ButtonType.Ice: reaction = iceReaction; break;
            case ButtonType.Fire: reaction = fireReaction; break;
        }
        spriteRenderer.color = reaction.enemyColor;
        childRenderer.sprite = reaction.sprite;
        childRenderer.color = reaction.effectColor;
    }

    void TurnColorsBack()
    {
        spriteRenderer.color = originalColor;
        childRenderer.sprite = null;
    }
}
