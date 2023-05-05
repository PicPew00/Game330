using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;
public class LadderManager : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;

    public bool hitTheLadder = false;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hitTheLadder = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hitTheLadder = false;
    }
}
