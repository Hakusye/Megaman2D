using UnityEngine;

public class Player : MonoBehaviour
{
    //�ړ��X�s�[�h
    [SerializeField] private float moveSpeed = 10.0f;

    //�W�����v��
    [SerializeField] private float jumpForce = 15.0f;

    //�v���C���[�̑����ɂ���q�I�u�W�F�N�g
    [SerializeField] private Transform groundChecker;
    //�n�ʂ��`�F�b�N����~�̔��a
    [SerializeField] private float checkerRadius = 0.1f;
    //�n�ʂ̃��C���[
    [SerializeField] private LayerMask groundLayer;

    //�n�ʂɒ��n���Ă���Ƃ���true�A����Ă���Ƃ���false
    private bool isGround;

    private Rigidbody2D rb;

    private Animator anim;

    private Vector2 defaultScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        defaultScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
    }

    /// ���s���\�b�h
    private void Walk()
    {
        // ���͕��@�𒲂ׂ�(�E�Ȃ�1/���Ȃ�-1/�������Ȃ��Ƃ���0)
        float direction = Input.GetAxisRaw("Horizontal");

        //Rigidbody2D�̑��x���g���č��E�ɓ�����
        rb.linearVelocityX = direction * moveSpeed;

        //�E�̏ꍇ
        if (direction > 0)
        {
            transform.localScale = defaultScale;
        }
        //���̏ꍇ
        if (direction < 0)
        {
            transform.localScale = new Vector2 (-defaultScale.x, defaultScale.y);
        }

        if (direction != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

    }

    /// �W�����v���\�b�h
    private void Jump()
    {
        //OverlapCircle(�~�̒��S, �~�̔��a, ���m���郌�C���[);
        //�����̃`�F�b�J�[���n�ʂ����m������
        if (Physics2D.OverlapCircle(groundChecker.position, checkerRadius, groundLayer))
        {
            isGround = true;
        }
        //���m���Ă��Ȃ��Ƃ�
        else
        {
            isGround = false;
        }

        // W�L�[�܂��̓X�y�[�X�L�[���������^�C�~���O�ŃW�����v
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGround == true)
        {
            //������ɗ͂�������
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    ///// �ڐG���m
    ///// <param name = "collision"></param> 
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // �ڐG�����I�u�W�F�N�g����������
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGround = true;
    //    }
    //}

    ///// ��ڐG���m
    ///// <param name = "collision"></param> 
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    // �ڐG�����I�u�W�F�N�g����������
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGround = false;
    //    }

    //}
}
