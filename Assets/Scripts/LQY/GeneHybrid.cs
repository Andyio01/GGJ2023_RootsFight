using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneHybrid 
{
    // Start is called before the first frame update
    public string GeneType1 = "Aa";
    public string GeneType2 = "aa";
    
    
    public string GeneHybridAlgorithm(string Type1,string Type2)
    {
        string TypeA = "";
        string TypeB = "";
        string FinalType = "";
        
        for(int index = 0; index < Type1.Length-1 ; index++)
        {
            int Probability = Random.Range(0,10);
            // Debug.Log(Probability);
            if(Probability < 5)
            {
                TypeA += Type1[index];
                index++;
            }
            else
            {
                // Debug.Log("进入ELSE");
                TypeA += Type1[index+1];
                // Debug.LogFormat("角标为{0}",index+1);
                // Debug.Log("新进基因为"+Type1[0]);
                index += 1;
                
                
            }
            // Debug.Log("A基因型现为" + TypeA);
        }
        for(int index = 0; index < Type2.Length-1 ; index++)
        {
            int Probability = Random.Range(0,10);
            // Debug.Log(Probability);
            if(Probability < 5)
            {
                TypeB += Type2[index];
                
                index++;
            }
            else
            {
                
                TypeB += Type2[index+1];
                index++;
            }
            // Debug.Log("B基因型现为" + TypeB);
        }
        for(int i = 0; i < TypeA.Length; i++)
        {
            if((int)TypeA[i] > (int)TypeB[i])
            {
                FinalType += TypeB[i];
                FinalType += TypeA[i];
            }
            else
            {
                FinalType += TypeA[i];
                FinalType += TypeB[i];
            }
        }
        Debug.Log(FinalType);
        return FinalType;
    }
    void Start()
    {
        Debug.Log(GeneHybridAlgorithm(GeneType1,GeneType2));
        
        // Debug.Log("测试");
        // Debug.Log(GeneType1[0]);
        // Debug.Log(GeneType1[1]);
        // Debug.Log(GeneType1[2]);
        // Debug.Log(GeneType2[0]);


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
