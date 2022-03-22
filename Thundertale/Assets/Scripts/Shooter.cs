using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Animator animator = null;
    [SerializeField] float waitBeforeFiring = 0.5f;
    [SerializeField] float waitBetweenShots = 0.2f;
    [SerializeField] Vector2Int bulletsPerVolley = Vector2Int.one;
    [SerializeField] bool keepsLooking = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
        Health.OnDeath += Delete;
        transform.up = Health.Player.transform.position - transform.position;
    }

    private void OnDisable() => Health.OnDeath -= Delete;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(keepsLooking)
            transform.up = Health.Player.transform.position - transform.position;
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(waitBeforeFiring);
        int ammoCount = Random.Range(bulletsPerVolley.x, bulletsPerVolley.y + 1);
        for (int i = 0; i < ammoCount; i++)
        {
            GameObject instance = Instantiate(bulletPrefab, transform.position, transform.rotation);
            if (i < ammoCount - 1)
                yield return new WaitForSeconds(waitBetweenShots);
        }
        animator.SetBool("isShooting", false);
        Destroy(transform.parent.gameObject, waitBeforeFiring);
    }

    void Delete(bool b) => Destroy(gameObject);
}
