using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAct : MonoBehaviour
{
    [SerializeField] PlayerButton currentButton = null;

    [Tooltip("Masher button")]
    [SerializeField] KeyCode masher = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(masher) && currentButton != null)
            currentButton.Act();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerButton button = collision.GetComponent<PlayerButton>();
        if (button == null)
            return;
        currentButton = button;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerButton pressable = collision.GetComponent<PlayerButton>();
        if (pressable == currentButton)
            currentButton = null;
    }
}
