
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int maxJumpsToPerfom;
    [SerializeField] float speed = 20.0f;
    [SerializeField] SpriteRenderer spriteRenderer;
    // [SerializeField] float rotationSpeed = 200.0f;
    public GameObject projectilePrefab;
    public float jumpForce = 100.0f;
    private float horizontalInput;
    private float verticalInput;
    private float forwardInput;
    public float projectileSpeed = 10f;

    public List<BoxCollider2D> boxCollider2Ds = new List<BoxCollider2D>();


    public bool isGrounded1 = false;
    bool isOnLadder = false;
    bool isGrounded;

    int currentNumberOfJumpsToPerfom;

    new Rigidbody2D rigidbody;

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
        if (!Input.GetKey(KeyCode.E) && !Input.GetKeyDown(KeyCode.E)) // Apply translation only when not firing or just starting to fire a projectile
        {
            rigidbody.velocity = new Vector2(speed * horizontalInput, rigidbody.velocity.y);
        }

        // Rotate the character's sprite to face left when the left arrow is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
    }



    private bool isPassingThrough = false;
    private PlatformEffector2D platformEffector;

    private Vector3 projectileSpawnOffset = new Vector3(0.5f, 0f, 0f); // Offset from player's position to spawn the projectile
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentNumberOfJumpsToPerfom < maxJumpsToPerfom)
        {

            rigidbody.velocity = Vector3.zero;

            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);



            currentNumberOfJumpsToPerfom++;

        }

        GoingUpOnLadder();

        if (isPassingThrough)
        {
            // Disable the platform effector to stop passing through
            platformEffector.rotationalOffset = 0;
            isPassingThrough = false;
        }



        if (Input.GetKeyDown(KeyCode.E))
        {
            // Store the direction based on player's flipX value
            Vector2 throwDirection = spriteRenderer.flipX ? -transform.right : transform.right;

            // Calculate the spawn position of the projectile
            Vector3 projectileSpawnPosition = transform.position + (spriteRenderer.flipX ? -projectileSpawnOffset : projectileSpawnOffset);

            // Launch a projectile from the calculated spawn position
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPosition, Quaternion.Euler(0f, 0f, 90f));
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();

            // Set the initial position of the projectile relative to the player
            projectile.transform.position += (Vector3)throwDirection.normalized * 0.5f;

            projectileRigidbody.AddForce(throwDirection * projectileSpeed, ForceMode2D.Impulse);
        }










    }
    private void GoingUpOnLadder()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.UpArrow) && isOnLadder)
        {

            Debug.Log("On Ladder ");
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
        
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                // Get the colliders involved in the collision
                Collider2D characterCollider = GetComponent<Collider2D>();
                Collider2D obstacleCollider = collision.collider;

                // Ignore collision between character and obstacle colliders
                Physics2D.IgnoreCollision(characterCollider, obstacleCollider);
            }
        

       
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                // Get the colliders involved in the collision
                Collider2D characterCollider = GetComponent<Collider2D>();
                Collider2D obstacleCollider = collision.collider;

                // Re-enable collision between character and obstacle colliders
                Physics2D.IgnoreCollision(characterCollider, obstacleCollider, false);
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






