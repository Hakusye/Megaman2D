using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 攻撃オブジェクト
    [SerializeField] private Collider2D attackCollider;

    // 攻撃時間
    [SerializeField] private float attackTime = 0.5f;

    // 攻撃中はtrue
    private bool isAttacking = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //// 攻撃するメソッド
    //private void IEnumerator Attack()
    //{
    //    //攻撃中であるためtrueにする
    //    isAttacking = true;

    //    //攻撃用のオブジェクトの当たり判定をONにする。
    //    attackCollider.enabled = true;

    //    //指定待機時間
    //    yield return new WaitForSeconds(attackTime);

    //    //攻撃用のオブジェクトの当たり判定をOFFにする
    //    attackCollider.enabled = false; 

    //    //攻撃終わったためfalseにする
    //    isAttacking=false;

    //}
}
