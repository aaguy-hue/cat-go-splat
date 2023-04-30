using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private SpriteRenderer render;
    private float inpX;

    [SerializeField] private float movement_velocity = 7f;
    [SerializeField] private float jump_velocity = 12f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState {idle, running};

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        inpX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inpX * movement_velocity, rb.velocity.y);
        

        if(Input.GetButtonDown("Jump")){
            if(IsGrounded()){
                rb.velocity = new Vector2(rb.velocity.x, jump_velocity);
            }
        }
        UpdateAnimationState();
        
    }

    private void UpdateAnimationState(){
        MovementState state;
        if(inpX > 0f){
            state = MovementState.running;
            render.flipX = false;
        }
        else if(inpX < 0f){
            state = MovementState.running;
            render.flipX = true;
        }
        else{
            state = MovementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }
    
    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
