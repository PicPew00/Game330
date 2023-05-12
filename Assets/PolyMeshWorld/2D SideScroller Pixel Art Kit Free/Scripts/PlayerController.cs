
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int maxJumpsToPerfom;

    [SerializeField] float speed = 20.0f;
    public float jumpForce = 100.0f;
    private float horizontalInput;
    private float verticalInput;
    private float forwardInput;

    public List<BoxCollider2D> boxCollider2Ds = new List<BoxCollider2D>();


    public bool isGrounded1 = false;
    bool isOnLadder = false;
    bool isGrounded;

    int currentNumberOfJumpsToPerfom;

    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        currentNumberOfJumpsToPerfom = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Read horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        // Move the player left or right
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentNumberOfJumpsToPerfom < maxJumpsToPerfom)
        {

            rigidbody.velocity = Vector3.zero;

            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);



            currentNumberOfJumpsToPerfom++;

        }

        GoingUpOnLadder();
    }
    private void GoingUpOnLadder()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.UpArrow) && isOnLadder)
        {

            Debug.Log("onladderrr....");
            rigidbody.gravityScale = 0f;
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
            //TRANSLATE THE PLAYER UP ( MOVING 1.0 tile at the time )

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            Debug.Log(" YOU ARE ON A LADDER");
            isOnLadder = true;
        }

    }

    private void ResetAllTrigger()
    {
        isOnLadder = false;
        rigidbody.gravityScale = 1f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ResetAllTrigger();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            if (boxCollider2Ds[1].IsTouching(collision.collider))
            {
                isGrounded1 = true;
                currentNumberOfJumpsToPerfom = 0;
            }
          
        }

        


        //if (collision.CompareTag("Ground"))
        //{

        //    //isGrounded1 = true;
        //    //currentNumberOfJumpsToPerfom = 0;
        //}

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded1 = false;
        }

    }

}






