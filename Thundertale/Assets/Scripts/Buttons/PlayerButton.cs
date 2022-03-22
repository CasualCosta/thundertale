using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType { Thunder = 0, Ice = 1, Fire = 2, Cure = 3 }
public abstract class PlayerButton : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer = null;
    [SerializeField] Animator animator = null;
    [SerializeField] Sprite pressedSprite = null;
    [SerializeField] AudioSource audioSource = null;
    [Tooltip("How long the button will last. X is minimum duration, Y is maximum.")]
    [SerializeField] Vector2 lifeSpan = new Vector2(2f, 5f);
    [SerializeField] ButtonType type = ButtonType.Thunder;

    public static event Action<ButtonType> OnAttackPress;
    protected virtual void Start() 
    {
        Destroy(gameObject, UnityEngine.Random.Range(lifeSpan.x, lifeSpan.y));
        Health.OnDeath += Delete;
    }

    protected void OnDisable() => Health.OnDeath -= Delete;

    public virtual void Act()
    {
        audioSource.Play();
        StartCoroutine(PressAnimation());
        //StartCoroutine(PressByAnimator());
        if (type != ButtonType.Cure)
            OnAttackPress?.Invoke(type);
        
    }

    IEnumerator PressAnimation()
    {
        Sprite original = spriteRenderer.sprite;
        spriteRenderer.sprite = pressedSprite;
        yield return null;
        spriteRenderer.sprite = original;
    }

    IEnumerator PressByAnimator()
    {
        animator.SetTrigger("pressing");
        yield return null;
        animator.ResetTrigger("pressing");
    }

    void Delete(bool b) => Destroy(gameObject);
}
