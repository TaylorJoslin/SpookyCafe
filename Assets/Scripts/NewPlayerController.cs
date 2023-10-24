using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed, jumpForce;
    public SpriteRenderer sr;

    private Vector2 moveInput;

    public LayerMask Ground;
    public Transform groundPoint;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y ,moveInput.y * moveSpeed);

        //flip the spite in the direction player is walking
        if (moveInput.x < 0)
        {
            sr.flipX = true;
        }else if (moveInput.x > 0)
        {
            sr.flipX = false;

        }

        //detect the ground in order to jump
        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, Ground))
        {
            isGrounded= true;
        }else
        {
            isGrounded= false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded) 
        {
            rb.velocity += new Vector3(0f, jumpForce, 0f);
        }



    }



}
