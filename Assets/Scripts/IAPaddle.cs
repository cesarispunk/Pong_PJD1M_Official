using UnityEngine;

public class IAPaddle : MonoBehaviour
{
    [SerializeField] private float speed;

    private Ball ball;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = FindAnyObjectByType(typeof(Ball)) as Ball;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            if (ball.transform.position.y > transform.position.y)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }

        }
    }
}
