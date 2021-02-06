using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    //スクロールスピード
    private float scrollSpeed = -1;
    //背景終了位置
    private float deadLine = -16;
    //背景開始位置
    private float startLine = 15.8f;
    void Start()
    {
        
    }

    
    void Update()
    {
        //背景の移動
        transform.Translate(this.scrollSpeed * Time.deltaTime, 0, 0);

        //画面外に出たら、画面右端に移動する
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }
    }
}
