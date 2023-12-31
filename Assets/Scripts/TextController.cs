using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    string Winner = GlobalManager.Winner;
    public Image Winner1;
    public Image Winner2;
    public Text Note1;
    public Text Note2;
    int time = 1;
    int interval = 3;

    public AudioSource changedAudio;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if(Winner == "P1")
        {
            Winner1.enabled = true;
            Note1.enabled = true;
            Note1.text = "自由配种 + 1";
            yield return new WaitForSecondsRealtime(3.2f);
            Note1.text = "生成新基因...";
            yield return new WaitForSecondsRealtime(3.2f);
            string P1curDNA = string.Join("",GlobalManager.P1CurDNA);
            Note1.text = "新基因：" + P1curDNA;
            yield return new WaitForSecondsRealtime(3.2f);
        }
        else if(Winner == "P2")
        {
            Winner2.enabled = true;
            Note2.enabled = true;
            Note2.text = "自由配种 + 1";
            yield return new WaitForSecondsRealtime(3.2f);
            Note2.text = "生成新基因...";
            yield return new WaitForSecondsRealtime(3.2f);
            string P2curDNA = string.Join("",GlobalManager.P2CurDNA);
            Note2.text = "新基因：" + P2curDNA;
            yield return new WaitForSecondsRealtime(3.2f);
        }
        
        
        if (GlobalManager.rootDNA_str == GlobalManager.P1CurDNA_str) {
            GlobalManager.FinalWinner = "P1";
            SceneManager.LoadScene("End");
            yield break;
        }
        if (GlobalManager.rootDNA_str == GlobalManager.P2CurDNA_str) {
            GlobalManager.FinalWinner = "P2"; 
            SceneManager.LoadScene("End");
            yield break;
        }
        SceneManager.LoadScene("FreeMate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
