using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private int score = 0;
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private GameObject scoreText;
    
    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("Score Text");
        
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
            
            {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";           
               
        }
       if (score > 0)
        { scoreText.GetComponent<Text>().text = score.ToString();}
    }
    
    
   
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        if(collision.gameObject.tag == "LargeStarTag")
        {            
            score += 20;
        }
        if(collision.gameObject.tag == "SmallCloudTag")
        {
            score += 30;
        }
        if(collision.gameObject.tag == "LargeCloudTag")
        {
            score += 50;
        }

        Debug.Log(collision.gameObject.name + score);
       
    }
}
