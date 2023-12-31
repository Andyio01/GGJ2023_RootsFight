using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class P1FreeMate : MonoBehaviour
{
    public TMP_Text P1GeneDisplay;
    // public TMP_Text P2GeneDisplay;
    public TMP_Text RemainCounter;
    public Image P1Note;
    public Image P1End;
    int RemainChance_P1 = GlobalManager.FreeMateP1;
    // string P1GeneType = string.Join("",GlobalManager.P1CurDNA);
    private List<char> TempGeneType = GlobalManager.P1CurDNA;
    public bool ifP1Completed = false;

    private int useCnt = 0;
    
    // GlobalManager.P1CurDNA = new List<char>(P1GeneType.ToCharArray());
    // Start is called before the first frame update
    void Start() {
        P1GeneDisplay.text = string.Join("  ", TempGeneType);
        RemainCounter.text = GlobalManager.FreeMateP1.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("f"))
        {
            GlobalManager.P1CurDNA = TempGeneType;
            P1Note.enabled = false;
            P1End.enabled = true;
            ifP1Completed = true;
            GlobalManager.FreeMateP2 += useCnt;
        }
        if(RemainChance_P1 > 0)
        {
            
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Getkey1");
                Debug.Log(TempGeneType[2]);
                if((int)TempGeneType[0] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[0] = TempGeneType[0].ToString().ToLower()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P1CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                        
                    
                    Debug.Log(P1GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {   
                    Debug.Log(TempGeneType);
                    TempGeneType[0] = TempGeneType[0].ToString().ToUpper()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                }
                ++useCnt;
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Getkey2");
                if((int)TempGeneType[1] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[1] = TempGeneType[1].ToString().ToLower()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P1CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                    Debug.Log(P1GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {
                    Debug.Log(TempGeneType[1]);
                    TempGeneType[1] = TempGeneType[1].ToString().ToUpper()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                
                }
                ++useCnt;
            }
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Getkey3");
                if((int)TempGeneType[2] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[2] = TempGeneType[2].ToString().ToLower()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P1CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                    Debug.Log(P1GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {
                    TempGeneType[2] = TempGeneType[2].ToString().ToUpper()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                }
                ++useCnt;
            }
            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                Debug.Log("Getkey4");
                if((int)TempGeneType[3] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[3] = TempGeneType[3].ToString().ToLower()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P1CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                    Debug.Log(P1GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {
                    TempGeneType[3] = TempGeneType[3].ToString().ToUpper()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                }
                ++useCnt;
            }
            if(Input.GetKeyDown(KeyCode.Alpha5))
            {
                Debug.Log("Getkey5");
                if((int)TempGeneType[4] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[4] = TempGeneType[4].ToString().ToLower()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P1CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                   
                    Debug.Log(P1GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {
                    TempGeneType[4] = TempGeneType[4].ToString().ToUpper()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                
                }
                ++useCnt;
            }
            if(Input.GetKeyDown(KeyCode.Alpha6))
            {
                Debug.Log("Getkey6");
                if((int)TempGeneType[5] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[5] = TempGeneType[5].ToString().ToLower()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P1CurDNA[0]);
                
                    Debug.Log("修改基因");
                    if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                  
                    Debug.Log(P1GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {
                    TempGeneType[5] = TempGeneType[5].ToString().ToUpper()[0];
                    P1GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                   if(RemainChance_P1 > 0)
                    {
                        RemainChance_P1 -= 1;
                        RemainCounter.text = RemainChance_P1.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                }
                ++useCnt;
            }
            
        }
    }
}
