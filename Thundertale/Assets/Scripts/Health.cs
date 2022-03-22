using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Player { get; private set; }
    public static Health Enemy { get; private set; }
    [SerializeField] GameObject deathSound = null;
    [SerializeField] AudioSource damageSound = null, healSound = null;
    [SerializeField] Vector2 health = new Vector2(100, 100);
    [Range(0, 1)][SerializeField] float criticalPercentage = 0.33f;
    [SerializeField] bool isPlayer = false;
    private bool hasEnteredCritical = false;

    public static event Action<Vector2, bool> OnHealthChange;
    public static event Action<bool> OnDeath; //bool is for whether or not it's the player
    public static event Action OnEnemyCritical;

    private void Awake()
    {
        if (isPlayer)
            Player = this;
        else
            Enemy = this;
    }

    void Start()
    {
        OnHealthChange?.Invoke(health, isPlayer);
    }

    public void ChangeHealth(float value)
    {
        health.x = Mathf.Clamp(health.x + value, 0, health.y);
        OnHealthChange?.Invoke(health, isPlayer);
        if (health.x == 0)
        {
            Die();
            return;
        }
        else if (health.x / health.y <= criticalPercentage && !hasEnteredCritical && !isPlayer)
        {
            OnEnemyCritical?.Invoke();
            hasEnteredCritical = true;
        }
        if (value > 0)
            healSound.Play();
        else
            damageSound.Play();
    }

    void Die()
    {
        //Do death stuff
        OnDeath?.Invoke(isPlayer);
        Instantiate(deathSound);
        //Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
