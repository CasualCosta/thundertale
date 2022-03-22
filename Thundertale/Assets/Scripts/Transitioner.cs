using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitioner : MonoBehaviour
{
    public static Transitioner Instance { get; private set; }
    [SerializeField] Animator animator = null;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        MenuManager.OnStartClick += SetOn;
        MenuManager.OnLoad += SetOff;
        BattleManager.OnSceneLoad += SetOff;
        BattleManager.OnSceneOver += SetOn;
    }
    private void OnDisable()
    {
        MenuManager.OnStartClick -= SetOn;
        MenuManager.OnLoad -= SetOff;
        BattleManager.OnSceneLoad -= SetOff;
        BattleManager.OnSceneOver -= SetOn;
    }

    void SetOn() => animator.SetBool("isTransitioning", true);
    void SetOn(bool b) => animator.SetBool("isTransitioning", true);
    void SetOff() => animator.SetBool("isTransitioning", false);
}
