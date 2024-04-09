using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float initialSpeed = 30f; // Tốc độ ban đầu của quả bóng
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        CancelInvoke();
        Invoke(nameof(SetRandom), 1f);
    }

    private void SetRandom()
    {
        gameObject.SetActive(true);
        rb.transform.position = new Vector3(-1.71f, -2f, 0f);
        rb.velocity = new Vector2(Random.Range(-1, 1), -1).normalized*initialSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Paddle"))
        {
            float Width = (other.collider.bounds.size.x)/2;
            float hitPosition = (transform.position.x - other.transform.position.x) / Width;
            Vector2 hitDirection = new Vector2(hitPosition, -1).normalized;
            rb.velocity = new Vector2(hitDirection.x*5f, 7f);
        }

        if (other.gameObject.CompareTag("Dead"))
        {
            gameObject.SetActive(false);
            ResetBall();
           // GameManager.Instance.lives -= 1;
        }
    }
}
