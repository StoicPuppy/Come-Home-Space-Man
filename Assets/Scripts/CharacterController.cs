using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Check if grounded
    private bool isGrounded = false;
    [SerializeField] private Transform groundCheck; //obj where to the test if grounded
    [SerializeField] private LayerMask whatIsGround; //List of layers
    const float checkRadius = 0.6f;

    //jump variables
    private Rigidbody2D rigid;
    [SerializeField] private float jumpHeight = 6f;

    //Move variables
    [SerializeField] private float speed = 6f;
    private Vector2 refVelocity = Vector2.zero;
    [SerializeField] private float movementSmoothing = 0.05f;

    //Face Left
    private bool faceLeft = false;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Move(float move, bool jump)
    {
        Jumping(jump);
        Movement(move);
        CheckOrientation(move);
    }

    void CheckOrientation(float move)
    {
        if ((move > 0 && faceLeft) || (move < 0 && !faceLeft))
        {
            faceLeft = !faceLeft;
            sprite.flipX = faceLeft;
        }
    }

    void Jumping(bool jump)
    {
        if(jump && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void Movement(float move)
    {
        Vector2 targetVelocity = new Vector2(move * speed, rigid.velocity.y);
        rigid.velocity = Vector2.SmoothDamp(rigid.velocity, targetVelocity, ref refVelocity, movementSmoothing);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void CheckGround()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isGrounded = (collider != null) ? true : false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = isGrounded ? Color.blue : Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }



}
