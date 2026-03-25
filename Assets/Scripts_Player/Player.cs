using UnityEngine;

public class Player : MonoBehaviour
{
    //移動スピード
    [SerializeField] private float moveSpeed = 10.0f;

    //ジャンプ力
    [SerializeField] private float jumpForce = 15.0f;

    //プレイヤーの足元にある子オブジェクト
    [SerializeField] private Transform groundChecker;
    //地面をチェックする円の半径
    [SerializeField] private float checkerRadius = 0.1f;
    //地面のレイヤー
    [SerializeField] private LayerMask groundLayer;

    //地面に着地しているときはtrue、離れているときはfalse
    private bool isGround;

    private Rigidbody2D rb;

    private Vector2 defaultScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        defaultScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
    }

    /// 歩行メソッド
    private void Walk()
    {
        // 入力方法を調べる(右なら1/左なら-1/何もしないときは0)
        float direction = Input.GetAxisRaw("Horizontal");

        //Rigidbody2Dの速度を使って左右に動かす
        rb.linearVelocityX = direction * moveSpeed;

        //右の場合
        if (direction > 0)
        {
            transform.localScale = defaultScale;
        }
        //左の場合
        if (direction < 0)
        {
            transform.localScale = new Vector2 (-defaultScale.x, defaultScale.y);
        }

    }

    /// ジャンプメソッド
    private void Jump()
    {
        //OverlapCircle(円の中心, 円の半径, 検知するレイヤー);
        //足元のチェッカーが地面を検知したら
        if (Physics2D.OverlapCircle(groundChecker.position, checkerRadius, groundLayer))
        {
            isGround = true;
        }
        //検知していないとき
        else
        {
            isGround = false;
        }

        // Wキーまたはスペースキーを押したタイミングでジャンプ
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGround == true)
        {
            //上方向に力をかける
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    ///// 接触検知
    ///// <param name = "collision"></param> 
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // 接触したオブジェクトが床か判定
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGround = true;
    //    }
    //}

    ///// 非接触検知
    ///// <param name = "collision"></param> 
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    // 接触したオブジェクトが床か判定
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGround = false;
    //    }

    //}
}
