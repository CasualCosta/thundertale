using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    public bool isCombatOn = true;

    public static event Action OnSceneLoad;
    public static event Action OnSceneOver;

    private void Awake() => Instance = this;
    // Start is called before the first frame update
    void Start()
    {
        Health.OnDeath += EndCombat;
        OnSceneLoad?.Invoke();
    }

    private void OnDisable() => Health.OnDeath -= EndCombat;

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndCombat (bool b)
    {
        isCombatOn = false;
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(1f);
        OnSceneOver?.Invoke();
        yield return new WaitForSeconds(0.6f);
        MenuManager.LoadMenu();
    }
}
