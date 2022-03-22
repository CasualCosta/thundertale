using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Don't touch these:")]
    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] AudioSource dashSound = null;

    [Header("Adjustable:")]
    [Tooltip("How fast the player moves")]
    [SerializeField] float moveForce = 100f;
    [Tooltip("How much faster the player gets when mashing SPACE")]
    [SerializeField] float mashMultiplier = 1.5f;

    private Vector2 movement;
    private float moveMultiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if (movement != Vector2.zero && moveMultiplier != 1)
            dashSound.Play();
    }

    private void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveForce * moveMultiplier * Time.fixedDeltaTime;
    }

    void HandleInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        moveMultiplier = Input.GetKeyDown(KeyCode.Space) ? mashMultiplier : 1f;
    }
}
