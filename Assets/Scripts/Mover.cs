using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves this character in four direction with Arrow keys
/// </summary>
public class Mover : MonoBehaviour
{
    /// <summary>
    /// The speed of this object
    /// </summary>
    public float speed = 1f;

    void Start()
    {
        var rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.gravityScale = 0f;
        rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        float vx = 0f, vy = 0f;
        if (Input.GetKey(KeyCode.RightArrow)) vx = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow)) vx = -1f;
        if (Input.GetKey(KeyCode.UpArrow)) vy = 1f;
        else if (Input.GetKey(KeyCode.DownArrow)) vy = -1f;
        vx *= speed * 0.02f; vy *= speed * 0.02f;

        transform.Translate(vx, vy, 0f);
    }

}
