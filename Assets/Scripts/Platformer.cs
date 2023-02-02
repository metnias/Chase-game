using UnityEngine;

/// <summary>
/// Moves this character with Arrow keys and Jump key
/// </summary>
public class Platformer : MonoBehaviour
{
    /// <summary>
    /// The speed of this object
    /// </summary>
    public float speed = 1f;

    public int jumpLength = 5;
    public float jumpStrength = 5f;

    public float gravityScale = 1f;

    private Rigidbody2D rigid2D;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.gravityScale = gravityScale;
        rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        wantToJump = 0; jumpPow = 0;
    }

    private int wantToJump = 0, jumpPow = 0;

    void FixedUpdate()
    {
        float vx = 0f;
        if (Input.GetKey(KeyCode.RightArrow)) vx = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow)) vx = -1f;
        vx *= speed * 0.02f;
        transform.Translate(vx, 0f, 0f);

        if (Input.GetKey(KeyCode.Z)) wantToJump = 5;
        if (wantToJump > 0) { wantToJump = 0; jumpPow = jumpLength; }
        if (jumpPow > 0)
        {
            jumpPow--; rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpStrength);
        }
    }

}
