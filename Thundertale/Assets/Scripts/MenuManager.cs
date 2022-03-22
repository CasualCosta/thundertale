using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] float loadWait = 0.6f;
    public static event Action OnStartClick;
    public static event Action OnLoad;

    private void Start() => OnLoad?.Invoke();
    public void StartGame()
    {
        animator.SetBool("startGame", true);
        OnStartClick?.Invoke();
        StartCoroutine(LoadLevel());
    }

    public static void LoadMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(loadWait);
        SceneManager.LoadSceneAsync(1);
    }
    public void EndGame() => Application.Quit();
}
