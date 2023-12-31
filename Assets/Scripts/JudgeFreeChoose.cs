using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JudgeFreeChoose : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.Find("GenePanel_P2").GetComponent<P2FreeMate>().IfP2Completed && this.transform.Find("GenePanel_P1").GetComponent<P1FreeMate>().ifP1Completed)
        {
            if (GlobalManager.rootDNA_str == GlobalManager.P1CurDNA_str) {
                GlobalManager.FinalWinner = "P1";
                SceneManager.LoadScene("End");
                return;
            }
            if (GlobalManager.rootDNA_str == GlobalManager.P2CurDNA_str) {
                GlobalManager.FinalWinner = "P2"; 
                SceneManager.LoadScene("End");
                return;
            }
            
        
            SceneManager.LoadScene("005_Predict");
        }
    }
}
