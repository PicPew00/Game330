using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int maxJumpsToPerfom;

    [SerializeField] float speed = 20.0f;
    public float jumpForce = 100.0f;
    private float horizontalInput;
    private float forwardInput;

    bool isGrounded;

    int currentNumberOfJumpsToPerfom;

    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody= GetComponent<Rigidbody2D>();

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
        if (Input.GetKeyDown(KeyCode.Space) && currentNumberOfJumpsToPerfom<maxJumpsToPerfom)
        {

            rigidbody.velocity= Vector3.zero;

            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);



            currentNumberOfJumpsToPerfom++;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
        {

            currentNumberOfJumpsToPerfom= 0;

        }

    }

}






