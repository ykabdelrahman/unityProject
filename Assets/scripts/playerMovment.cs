using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite ; 
    private Animator anim;
    private float dirx = 0f;
    //[SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField]private float jumpforce = 14f;    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
         dirx = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirx*moveSpeed,rb.velocity.y);


        if (Input.GetButtonDown("Jump")) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        UpdateAnimationSate();
    }

    private void UpdateAnimationSate()
    {
        if (dirx > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;

        }
        else
        {
            anim.SetBool("running", false);
        }
    }
   
}
