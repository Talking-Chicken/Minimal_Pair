using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerControl : MonoBehaviour
{
    [SerializeField, BoxGroup("Movement")] private float speed, jumpForce, jumpTime;
    private float horizontalMoveInput, verticalMoveInput, jumpTimeCounter;
    [SerializeField]private bool isClimbing = false, isGrounded = false, isJumping = false;
    [SerializeField, BoxGroup("Jump")] private Transform feetPos;
    [SerializeField, BoxGroup("Jump")] private float feetRadius;
    [SerializeField, BoxGroup("Jump")] private LayerMask groundLayer;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;

    public bool IsClimbing {get=>isClimbing; set=>isClimbing = value;}
    public bool IsGrounded {get=>isGrounded; set=>isGrounded = value;}
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (!IsClimbing)
            isGrounded = Physics2D.OverlapCircle(feetPos.position, feetRadius, groundLayer);

        if (horizontalMoveInput > 0) 
            transform.eulerAngles = Vector3.zero;
        else if (horizontalMoveInput < 0)
            transform.eulerAngles = new Vector3(0,180,0); 

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rigidBody.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetKey(KeyCode.Space)) {
            if (jumpTimeCounter > 0) {
                rigidBody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }
    }

    void FixedUpdate() {
        horizontalMoveInput = Input.GetAxisRaw("Horizontal");
        verticalMoveInput = Input.GetAxisRaw("Vertical");
        if (!IsClimbing)
            rigidBody.velocity = new Vector2(horizontalMoveInput * speed, rigidBody.velocity.y);
        else
            rigidBody.velocity = new Vector2(horizontalMoveInput * speed, verticalMoveInput*speed);
    }
}
