using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All scripts wrote and developed in conjuction with youtube.com @Brackeys, @JasonWeiman and @CodeMonkey

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;

    public Rigidbody2D _rigidbody;

    //public HealthBar healthBar;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    //public int maxHealth = 100;
    //public int currentHealth;

    private void Start()
    {
        //currentHealth = maxHealth;
        //healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            FindObjectOfType<AudioManager>().Play("PlayerCrouch");
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
        //FindObjectOfType<AudioManager>().Play("PlayerLanding");

    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        _rigidbody = GetComponent<Rigidbody2D>();

        if (_rigidbody.position.y < -6.4f)
        {
            
            animator.SetTrigger("Falling");
            animator.SetBool("isJumping", false);

            FindObjectOfType<GameManager>().EndGame();
        }

    }

    //void TakeDamage(int damage)
    //{
        //currentHealth -= damage;

        //healthBar.SetHealth(currentHealth);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {

            FindObjectOfType<AudioManager>().Play("CoinSound");

            Destroy(other.gameObject);
        }
    }
}
