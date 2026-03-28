using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // �U���I�u�W�F�N�g
    [SerializeField] private Collider2D attackCollider;

    // �U������
    [SerializeField] private float attackTime = 0.5f;

    // �U������true
    private bool isAttacking = false;

    private Animator anim;

    void Start()
    {
        attackCollider.enabled = false;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //左クリックを押すかつ
        if (Input.GetMouseButtonDown(0) && isAttacking  == false)
        {
            //攻撃開始
            StartCoroutine(Attack());
        }
    }

    // �U�����郁�\�b�h
    private IEnumerator Attack()
    {
       //�U�����ł��邽��true�ɂ���
       isAttacking = true;

       //�U���p�̃I�u�W�F�N�g�̓����蔻���ON�ɂ���B
       attackCollider.enabled = true;

       //攻撃アニメーション開始
       anim.SetBool("Attack", true);

       //�w��ҋ@����
       yield return new WaitForSeconds(attackTime);

       anim.SetBool("Attack", false);

       //�U���p�̃I�u�W�F�N�g�̓����蔻���OFF�ɂ���
       attackCollider.enabled = false; 

       //�U���I���������false�ɂ���
       isAttacking=false;
    }
}
