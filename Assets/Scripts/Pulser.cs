using UnityEngine;

/// <summary>
/// Repeats the idle animation
/// </summary>
public class Pulser : MonoBehaviour
{
    /// <summary>
    /// Sprites to repeat
    /// </summary>
    public Sprite[] Sprites;
    /// <summary>
    /// How long each frame is displayed
    /// </summary>
    public int frameTime = 40;

    private SpriteRenderer sprRenderer;
    private int moveTime = 0;

    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        moveTime = 0;
    }

    void Update()
    {
        moveTime++;
        int frame = (moveTime / frameTime) % Sprites.Length;
        sprRenderer.sprite = Sprites[frame];
    }
}
