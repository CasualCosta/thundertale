using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource regularMusic = null;
    [SerializeField] AudioSource franticMusic = null;
    [SerializeField] Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
        Health.OnEnemyCritical += TriggerFrantic;
        Health.OnDeath += TriggerSilence;
    }
    void OnDisable()
    {
        Health.OnEnemyCritical -= TriggerFrantic;
        Health.OnDeath -= TriggerSilence;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TriggerFrantic()
    {
        animator.SetTrigger("frantic");
        franticMusic.Play();
        StartCoroutine(Stop(regularMusic));
    }
    IEnumerator Stop(AudioSource audioSource)
    {
        yield return new WaitForSeconds(5f);
        audioSource.Stop();
    }

    void TriggerSilence(bool b)
    {
        animator.SetBool("isRunning", false);
        animator.SetTrigger("silence");
        StartCoroutine(Stop(regularMusic));
        StartCoroutine(Stop(franticMusic));
    }
}
