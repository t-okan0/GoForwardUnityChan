using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅ライン
    private float deadLine = -10;

   

    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        //移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外で消滅
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "Cube" || gameObject.tag == "Ground") 
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
