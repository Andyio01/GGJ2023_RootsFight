using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class P2FreeMate : MonoBehaviour
{
    public TMP_Text P2GeneDisplay;
    // public TMP_Text P2GeneDisplay;
    public TMP_Text RemainCounter;
    public Image P2Note;
    public Image P2End;
    int RemainChance_P2 = GlobalManager.FreeMateP2;
    // string P2GeneType = string.Join("",GlobalManager.P2CurDNA);
    private List<char> TempGeneType = GlobalManager.P2CurDNA;
    public bool IfP2Completed = false;

    private int useCnt = 0;
    
    // GlobalManager.P2CurDNA = new List<char>(P2GeneType.ToCharArray());
    // Start is called before the first frame update
    void Start() {
        P2GeneDisplay.text = string.Join("  ", TempGeneType);
        RemainCounter.text = GlobalManager.FreeMateP2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(";"))
        {
            GlobalManager.P2CurDNA = TempGeneType;
            P2Note.enabled = false;
            P2End.enabled = true;
            IfP2Completed = true;
            GlobalManager.FreeMateP1 += useCnt;
        }
        if(RemainChance_P2 > 0)
        {
            
            if(Input.GetKeyDown(KeyCode.Keypad1))
            {
                Debug.Log("Getkey1");
                Debug.Log(TempGeneType[2]);
                if((int)TempGeneType[0] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[0] = TempGeneType[0].ToString().ToLower()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P2CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                        
                    
                    Debug.Log(P2GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {   
                    Debug.Log(TempGeneType);
                    TempGeneType[0] = TempGeneType[0].ToString().ToUpper()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                
                }
                ++useCnt;
            }
            if(Input.GetKeyDown(KeyCode.Keypad2))
            {
                Debug.Log("Getkey2");
                if((int)TempGeneType[1] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[1] = TempGeneType[1].ToString().ToLower()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P2CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                    Debug.Log(P2GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {
                    Debug.Log(TempGeneType[1]);
                    TempGeneType[1] = TempGeneType[1].ToString().ToUpper()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                }
                ++useCnt;
            }
            if(Input.GetKeyDown(KeyCode.Keypad3))
            {
                Debug.Log("Getkey3");
                if((int)TempGeneType[2] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[2] = TempGeneType[2].ToString().ToLower()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P2CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                   
                    Debug.Log(P2GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {
                    TempGeneType[2] = TempGeneType[2].ToString().ToUpper()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                
                }
                ++useCnt;
            }
            if(Input.GetKeyDown(KeyCode.Keypad4))
            {
                Debug.Log("Getkey4");
                if((int)TempGeneType[3] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[3] = TempGeneType[3].ToString().ToLower()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P2CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                   
                    Debug.Log(P2GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {
                    TempGeneType[3] = TempGeneType[3].ToString().ToUpper()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                }
                ++useCnt;
            }
            if(Input.GetKeyDown(KeyCode.Keypad5))
            {
                Debug.Log("Getkey5");
                if((int)TempGeneType[4] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[4] = TempGeneType[4].ToString().ToLower()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P2CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                    Debug.Log(P2GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {
                    TempGeneType[4] = TempGeneType[4].ToString().ToUpper()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                }
                ++useCnt;
            }
            if(Input.GetKeyDown(KeyCode.Keypad6))
            {
                Debug.Log("Getkey6");
                if((int)TempGeneType[5] - 90 <= 0)
                // 该基因为大写
                {
                    TempGeneType[5] = TempGeneType[5].ToString().ToLower()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    // Debug.Log(TempGeneType[0]);
                    // Debug.Log(GlobalManager.P2CurDNA[0]);
                    
                    Debug.Log("修改基因");
                    if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                    Debug.Log(P2GeneDisplay.text = string.Join("  ", TempGeneType));
                }
                else
                // 该基因为小写
                {
                    TempGeneType[5] = TempGeneType[5].ToString().ToUpper()[0];
                    P2GeneDisplay.text = string.Join("  ", TempGeneType);
                    
                   if(RemainChance_P2 > 0)
                    {
                        RemainChance_P2 -= 1;
                        RemainCounter.text = RemainChance_P2.ToString();
                        Debug.Log("Remain is inefficient!");
                    }
                    
                }
                ++useCnt;
            }
            
        }
    }
}
