using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Chases the target
/// </summary>
public class Chaser : MonoBehaviour
{
    /// <summary>
    /// Target (Player if not set)
    /// </summary>
    public GameObject target;

    /// <summary>
    /// Chase speed
    /// </summary>
    public float speed = 1f;


    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (target != null) return;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector3 offset = target.transform.position - transform.position;
        offset = offset.normalized * speed * 0.02f;
        transform.position += offset;
    }
}
