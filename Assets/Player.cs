using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Rigidbody2D rb2d;

    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isJumping;

    [Header("Pause")]
    [SerializeField] GameObject PauseScreen;
    [SerializeField] bool isPaused;

    private Vector2 input;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb2d.position += input * speed * Time.fixedDeltaTime;
    }


    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            isPaused = true;
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
        

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!isJumping)
        {
            isJumping = true;
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
