using System.Collections;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class Ball : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] private float ballSpeed;
    [SerializeField] private float rotationBallSpeed = 360f;
    [SerializeField] private float timeToMoveBall;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        Invoke("Launch", timeToMoveBall);
    }
    private void Update()
    {
        transform.Rotate(0, 0, rotationBallSpeed * Time.deltaTime);
    }
    private void Launch()
    {
        Vector2 direction = Vector2.zero;

        if (Random.value <= 0.5f)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }

        direction.y = Random.Range(-0.5f, 0.5f);
        rb.linearVelocity = direction * ballSpeed;
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;

        //Invoke("Launch", timeToMoveBall);
        StartCoroutine(PlayBallRoutine());
    }

    private IEnumerator PlayBallRoutine()
    {
        sr.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sr.enabled = true;

        Launch();
    }
}
