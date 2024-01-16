using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    private bool jumped;
    public bool onGround;
    public Collider2D terrain;
    public ContactFilter2D terrtainFilter;
    public Animator animator;
    public bool move;
    public SpriteRenderer playerSprite;
    public bool attack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumped = false;
        onGround = false;
        move = false;
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        if (moveHorizontal > 0f)
        {
            playerSprite.flipX = false;
        }
        if (moveHorizontal < 0f)
        {
            playerSprite.flipX = true;
        }
 
        // rb.AddForce(new Vector2 (moveHorizontal * moveSpeed, rb.velocity.y), ForceMode2D.Force);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            move = true;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        
        {
            move = false;
        }

        if (move)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
        
        if (jumped)
        {
            jumped = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            animator.SetBool("Move", false);
            if (Input.GetKeyDown(KeyCode.J))
            {
                attack = true;
                animator.SetBool("Attack", true);
                animator.SetBool("Jump", false);
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                attack = false;
                animator.SetBool("Attack", false);
                animator.SetBool("Jump", false);
            }
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        onGround = terrain.IsTouching(terrtainFilter);

        if (!jumped && Input.GetKeyDown(KeyCode.Space) && onGround)
            jumped = true;

        if (Input.GetKeyDown(KeyCode.J))
        {
            attack = true;
            animator.SetBool("Attack", true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            attack = false;
            animator.SetBool("Attack", false);
        }

    }

    // void FixedUpdate()
    // {
    //     rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
        
    //     if (jumped)
    //     {
    //         jumped = false;
    //         rb.AddForce(Vector2.Up * jumpForce, ForceMode2D.Impulse);
    //     }
    // }
}
