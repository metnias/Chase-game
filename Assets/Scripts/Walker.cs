using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Displays walk cycle animation for cardinal directions
/// </summary>
public class Walker : MonoBehaviour
{
    public Sprite[] SpritesDown;
    public Sprite[] SpritesUp;
    public Sprite[] SpritesLeft;
    public Sprite[] SpritesRight;
    public int frameTime = 10;
    private SpriteRenderer sprRenderer;

    private enum Direction
    {
        Down,
        Up,
        Left,
        Right
    }

    private Direction dir;
    private int moveTime;

    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        dir = Direction.Down;
        moveTime = 0;
    }

    private Vector3 lastPos;

    void FixedUpdate()
    {
        bool moving = false;
        if (!Mathf.Approximately(lastPos.x, transform.position.x))
        {
            moving = true;
            dir = transform.position.x > lastPos.x ? Direction.Right : Direction.Left;
        }
        if (!Mathf.Approximately(lastPos.y, transform.position.y))
        {
            moving = true;
            dir = transform.position.y > lastPos.y ? Direction.Up : Direction.Down;
        }
        lastPos = transform.position;
        if (moving) moveTime++;
        else moveTime = 0;
        Sprite[] sprites = dir switch
        {
            Direction.Right => SpritesRight,
            Direction.Up => SpritesUp,
            Direction.Left => SpritesLeft,
            _ => SpritesDown,
        };
        int frame = ((moveTime + frameTime - 1) / frameTime) % sprites.Length;
        sprRenderer.sprite = sprites[frame];
    }


}
