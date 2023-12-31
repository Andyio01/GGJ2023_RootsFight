using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelController : MonoBehaviour
{
    public GameObject Player1;
    public GameObject player2;
    
    public void TestHP(float curHP1, float curHP2)
    {
        string TimeEND = GameObject.FindWithTag("CountDownText").GetComponent<TMP_Text>().text;
        if(TimeEND != "0")
        {
            if(curHP1 == 0 || curHP2 == 0 )
            {
                // GameOver!
                if(curHP1 == 0)
                {
                    // Player2 win!!
                }
                if(curHP2 == 0)
                {
                    // Player1 win!!
                }
            }
        }
        else
        {
            if(curHP1 > curHP2)
            {
                // Player1 win!
            }
            else if(curHP1 < curHP2)
            {
                // Player2 win!
            }
            else
            {
                int Probability = Random.Range(0,10);
                if(Probability > 5)
                {
                    // Player1 win!!
                }
                else
                {
                    // Player2 win!!
                }
            }
        }
            
    }
    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        float P1CurHp = Player1.GetComponent<PlayerController>().curHp;
        float P2CurHp = player2.GetComponent<PlayerController>().curHp;

        
    }
}
