using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (CompareTag("AIWall"))
            {
                gameManager.PlayerAddPoint();
            }

            if (CompareTag("PlayerWall"))
            {
                gameManager.AIAddPoint();
            }
        }
    }
}

