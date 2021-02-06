using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーターを入れる
    Animator animator;
    //移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;
    //地面の位置
    private float groundLevel = -3.0f;
    //ジャンプ速度の減衰
    private float dump = 0.8f;
    //ジャンプの速度
    float jumpVelocity = 20;
    //
    private float deadLine = -9;

  
    void Start()
    {
        //アニメのコンポーネント取得
        this.animator = GetComponent<Animator>();
        //rigid2Dのコンポーネント取得
        this.rigid2D = GetComponent<Rigidbody2D>();

    }

   
    void Update()
    {
        //走るアニメを再生するため、Animatorのパラメータを調整する
        this.animator.SetFloat("Horizontal", 1);   

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ中は足音が鳴らない
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0; 

        //着地状態でクリクされた場合
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            //上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックを止めたら上方向への速度を減速
        if (Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //デッドラインを超えたら終わり
        if (transform.position.x < this.deadLine) 
        {
            //キャンバス内のコンポーネントにあるゲームオーバー判定クラスを呼び出し
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            //クラスの内容からゲームオーバーが表示され、かつユニティちゃんが滅する
            Destroy(gameObject);
        } 
    
    }
}
