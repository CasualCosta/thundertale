using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 40f;
    [Tooltip("Whether or not the attack is destroyed when it touches the player")]
    [SerializeField] bool isDestroyed = true;

    void Start()
    {
        Health.OnDeath += Delete;
    }

    private void OnDisable() => Health.OnDeath -= Delete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health h = collision.GetComponent<Health>();
        if (h == Health.Player)
        {
            Health.Player.ChangeHealth(-damage);
            if(isDestroyed)
                Destroy(gameObject);
        }
    }

    void CheckForDamage(Collider2D collision)
    {
        Health h = collision.GetComponent<Health>();
        if (h == Health.Player)
        {
            Health.Player.ChangeHealth(-damage);
            Destroy(gameObject);
        }
    }
    void Delete(bool b) => Destroy(gameObject);
}
