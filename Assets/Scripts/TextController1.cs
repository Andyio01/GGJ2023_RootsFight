using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextController1 : MonoBehaviour
{
    string Winner = GlobalManager.Winner;
    public TMP_Text P1Choose;
    public TMP_Text P2Choose;
    public TMP_Text P1Predict;
    public TMP_Text P2Predict;
    public Image P1Right;
    public Image P2Right;
    public Image DamageP1;
    public Image DamageP2;
    public Image HealathP1;
    public Image HealathP2;
    int time = 1;
    int interval = 3;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        P1Choose.text = GlobalManager.P1FightDNA;
        P2Choose.text = GlobalManager.P2FightDNA;
        P1Predict.text = GlobalManager.P1PredictDNA;
        P2Predict.text = GlobalManager.P2PredictDNA;

        StartCoroutine(JudgeP1());
        StartCoroutine(JudgeP2());
        StartCoroutine(JudgeBoth());
        yield return new WaitForSecondsRealtime(7.5f);
        SceneManager.LoadScene("Act"); 
    }
    IEnumerator JudgeP1()
    {
        if(GlobalManager.P1PredictDNA == GlobalManager.P2FightDNA)
        {
            // P1 Right
            yield return new WaitForSecondsRealtime(4f);
            P1Right.enabled = true;
            DamageP1.enabled = true;
            GlobalManager.P1PredictResult = PredictResult.ImproveDamage;
        }
        else if(GlobalManager.P1PredictDNA != GlobalManager.P2FightDNA)
        {
            // P1 Wrong
            yield return new WaitForSecondsRealtime(4f);
            HealathP1.enabled = true;
            GlobalManager.P1PredictResult = PredictResult.LostHp;
        }
    }
    IEnumerator JudgeP2()
    {
        if(GlobalManager.P2PredictDNA == GlobalManager.P1FightDNA)
        {
            // P2 Right
            yield return new WaitForSecondsRealtime(4f);
            P2Right.enabled = true;
            DamageP2.enabled = true;
            GlobalManager.P2PredictResult = PredictResult.ImproveDamage;
        }
        else if(GlobalManager.P2PredictDNA != GlobalManager.P1FightDNA)
        {
            // P2 Wrong
            yield return new WaitForSecondsRealtime(4f);
            HealathP2.enabled = true;
            GlobalManager.P2PredictResult = PredictResult.LostHp;
        }
    }
    IEnumerator JudgeBoth()
    {
        if(GlobalManager.P1PredictDNA == GlobalManager.P2FightDNA && GlobalManager.P2PredictDNA == GlobalManager.P1FightDNA)
        {
            // P1 && P2 Both Right
            yield return new WaitForSecondsRealtime(4f);
            P1Right.enabled = true;
            P2Right.enabled = true;
            DamageP1.enabled = true;
            DamageP2.enabled = true;
        }
        else if(GlobalManager.P1PredictDNA != GlobalManager.P2FightDNA && GlobalManager.P2PredictDNA != GlobalManager.P1FightDNA)
        {
            // Both Wrong
            yield return new WaitForSecondsRealtime(4f);
            HealathP1.enabled = true;
            HealathP2.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
