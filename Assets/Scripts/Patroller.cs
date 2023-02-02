using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves horizontally until it meets Block, and turns around
/// </summary>
public class Patroller : MonoBehaviour
{
    public float speed = 1f;
    public string blockTag = "Block";

    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private bool flip = false;
    private int flipCount = 0;

    void FixedUpdate()
    {
        if (flipCount > 0) flipCount--;
        Vector3 move = flip ? Vector3.right : Vector3.left;
        move *= speed * 0.02f;
        transform.position += move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (flipCount < 1 && collision.collider.CompareTag(blockTag))
        { flip = !flip; flipCount = 4; }
    }
}
