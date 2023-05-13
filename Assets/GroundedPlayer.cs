using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedPlayer : MonoBehaviour
{

    public bool isGrounded = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {

            isGrounded = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {

            isGrounded = false;

        }
    }
}
