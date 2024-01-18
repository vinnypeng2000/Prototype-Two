using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    public bool jumped;
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
        animator.SetBool("Move", !Mathf.Approximately(moveHorizontal, 0));

        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            animator.SetBool("Move", false);
            onGround = false;
            // jumped = true;
        }

        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.Mouse0))
        {
            attack = true;
            animator.SetBool("Attack", true);
        }
        else
        {
            attack = false;
            animator.SetBool("Attack", false);
        }

    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (collision.gameObject.CompareTag("Terrain")) 
        { 
            onGround = true;
            animator.SetBool("Jump", false);
        } 
    } 
}
