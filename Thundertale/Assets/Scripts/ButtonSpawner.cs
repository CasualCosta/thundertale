using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    [SerializeField] Transform[] boundaries = new Transform[2];
    [Tooltip("The interval at which attacks are spawned. X is minimum, Y is maximum.")]
    [SerializeField] Vector2 spawnInterval = Vector2.zero;
    [Tooltip("List of all buttons that can be spawned. Odds are weighted by repetition.")]
    [SerializeField] List<GameObject> Buttons = new List<GameObject>();
    public bool isCombatOn = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnButton());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnButton()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(spawnInterval.x, spawnInterval.y));
            if (!BattleManager.Instance.isCombatOn)
                continue;
            int randomButton = Random.Range(0, Buttons.Count);
            Vector3 spawnPoint = new Vector3(
                Random.Range(boundaries[0].position.x, boundaries[1].position.x),
                Random.Range(boundaries[0].position.y, boundaries[1].position.y));
            GameObject instance = Instantiate(Buttons[randomButton], spawnPoint, Quaternion.identity);
        }
    }
}
