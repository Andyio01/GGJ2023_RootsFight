using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PredictManager : MonoBehaviour {
    public AudioSource clickAudio;
    
    public int countP1 = 0;
    public int countP2 = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        GlobalManager.P1PredictDNA = "";
        GlobalManager.P2PredictDNA = "";
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.Alpha1) && countP1 == 0)
        {
            // Debug.Log("按下1");
            GlobalManager.P1PredictDNA = "AA";
            clickAudio.Play();
            countP1 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && countP1 == 0)
        {
            GlobalManager.P1PredictDNA = "BB";
            clickAudio.Play();
            countP1 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && countP1 == 0)
        {
            GlobalManager.P1PredictDNA = "CC";
            clickAudio.Play();
            countP1 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && countP1 == 0)
        {
            GlobalManager.P1PredictDNA = "aa";
            clickAudio.Play();
            countP1 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && countP1 == 0)
        {
            GlobalManager.P1PredictDNA = "bb";
            clickAudio.Play();
            countP1 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && countP1 == 0)
        {
            GlobalManager.P1PredictDNA = "cc";
            clickAudio.Play();
            countP1 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1) && countP2 == 0)
        {
            GlobalManager.P2PredictDNA = "AA";
            clickAudio.Play();
            countP2 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && countP2 == 0)
        {
            GlobalManager.P2PredictDNA = "BB";
            clickAudio.Play();
            countP2 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) && countP2 == 0)
        {
            GlobalManager.P2PredictDNA = "CC";
            clickAudio.Play();
            countP2 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) && countP2 == 0)
        {
            GlobalManager.P2PredictDNA = "aa";
            clickAudio.Play();
            countP2 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5) && countP2 == 0)
        {
            GlobalManager.P2PredictDNA = "bb";
            clickAudio.Play();
            countP2 += 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6) && countP2 == 0)
        {
            GlobalManager.P2PredictDNA = "cc";
            clickAudio.Play();
            countP2 += 1;
        }
        Debug.Log(GlobalManager.P1PredictDNA);
        if (GameObject.FindWithTag("CountDownText").GetComponent<TMP_Text>().text != "00")
        {
            if (GameObject.FindWithTag("HideLayer1").GetComponent<Image>().enabled == true && GameObject.FindWithTag("HideLayer2").GetComponent<Image>().enabled == true)
            {
                SceneManager.LoadScene("ChooseFightDNA");
                return;
            }
        }
        else 
        {
            if(GlobalManager.P1PredictDNA == "")
            {
                GlobalManager.P1PredictDNA = "AA";
                
            }
            else if(GlobalManager.P2PredictDNA == "")
            {
                GlobalManager.P2PredictDNA = "AA";
                
            }
            else if(GlobalManager.P2PredictDNA == "" && GlobalManager.P1PredictDNA == "")
            {
                GlobalManager.P1PredictDNA = "AA";
                GlobalManager.P2PredictDNA = "AA";
                
            }
            SceneManager.LoadScene("ChooseFightDNA");
            
        }
        
    }
}
