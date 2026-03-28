using UnityEngine;

public class Enemy : MonoBehaviour
{
    //移動スピード
    [SerializeField] private float moveSpeed = 5.0f;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
    private void Walk()
    {
        if(transform.localScale.x > 0)
        {
            //左方向
            rb.linearVelocityX = -moveSpeed;
        }
        else if(transform.localScale.x < 0)
        {
            //右方向
            rb.linearVelocityX = moveSpeed;
        }
    }
}
        
