using UnityEngine;

/// <summary>
/// Triggers either GameOver or win on colliding with Player
/// </summary>
public class PlayerCollider : MonoBehaviour
{
    /// <summary>
    /// Whether to trigger win or game over
    /// </summary>
    public bool isWinFlag = false;

    private void Collide(GameObject hit)
    {
        if (hit.CompareTag("Player"))
        {
            if (isWinFlag) { GameController.GameWin(); gameObject.SetActive(false); }
            else { GameController.GameOver(); }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collide(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collide(collision.gameObject);
    }

}
