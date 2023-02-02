using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Flips this objects' sprite horizontally according to Horizontal movement
/// </summary>
public class Flipper : MonoBehaviour
{
    private SpriteRenderer sprRenderer;

    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        lastX = transform.position.x;
    }

    private float lastX;
    void Update()
    {
        if (Mathf.Approximately(lastX, transform.position.x)) return; // no X input
        sprRenderer.flipX = transform.position.x < lastX; // change flipX according to X input
        lastX = transform.position.x;
    }
}
