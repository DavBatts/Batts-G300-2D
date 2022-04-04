using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rB2D;

    public float runSpeed;
    public float jumpForce;

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    float currentZRotation = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButtonDown("Jump"))
        {
            int levelMask = LayerMask.GetMask("Level");

            if (Physics2D.BoxCast(transform.position, new Vector2(1f, .1f), 0f, Vector2.down, .01f, levelMask))
            {
                Jump();
            }
               
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        /*
        Quaternion rot = transform.rotation;

        currentZRotation += horizontalInput * Time.deltaTime;

        rot.SetEulerRotation(new Vector3(0, 0, currentZRotation));

        transform.rotation = rot;
        */


        rB2D.velocity = new Vector2(horizontalInput * runSpeed * Time.deltaTime, rB2D.velocity.y);

        //rB2D.AddForce(new Vector2(0, 1000));

        //rB2D.AddForce(new Vector2(horizontalInput, 0));

        if( rB2D.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }


        if ( Mathf.Abs(horizontalInput) > 0f )
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        
    }

    void Jump()
    {
        rB2D.velocity = new Vector2(rB2D.velocity.x, jumpForce);
    }
}
