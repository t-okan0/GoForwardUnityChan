using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    private GameObject gameOverText;

    private GameObject runLengthText;

    private float len = 0;

    private float speed = 5f;

    private bool isGameOver = false;

     

        void Start()
    {
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
        
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバーじゃないとき
        if (this.isGameOver == false)
        {
            //走行距離の更新をして
            this.len += this.speed * Time.deltaTime;
            //表示する
            this.runLengthText.GetComponent<Text>().text = "Distance" + len.ToString("F2") + "m";
        }
         
        //ゲームオーバーのとき
        if(this.isGameOver == true)
        {
            //クリックしたら
            if (Input.GetMouseButtonDown(0))
            {
                 //引数のシーンを読み込む
                 SceneManager.LoadScene("SampleScene");
            }

        }
        
    }
    public void GameOver()
    {
        //ゲームオーバーのとき
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}
