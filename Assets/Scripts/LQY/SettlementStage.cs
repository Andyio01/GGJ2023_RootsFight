using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementStage : MonoBehaviour
{
    // 获取Winner
    private string Winner = GlobalManager.Winner;
    // 获取P1 & P2当前的基因型
    private string P1GeneType = string.Join("", GlobalManager.P1CurDNA);
    private string P2GeneType = string.Join("", GlobalManager.P2CurDNA);
    // 获取本轮出战基因(角标形式)
    private string curFightDNA_P1 = GlobalManager.P1FightDNA;
    private string curFightDNA_P2 = GlobalManager.P2FightDNA;
    private int P1FightIndex;
    private int P2FightIndex;
    // 出战基因互相配种
    GeneHybrid Hybridration = new GeneHybrid();
    public string AfterGene;
    // 基因排序算法
    public string GeneSort(string GeneType)
    {
        if(GeneType.Contains("A"))
        {
            Debug.Log("找到A");
            int indexA = GeneType.IndexOf("A");
            string Temp = string.Concat(GeneType[indexA],GeneType[indexA+1]);
            GeneType = GeneType.Remove(indexA, 2);
            Debug.Log("移除原基因" + GeneType);
            GeneType = GeneType.Insert(0,Temp);
        }
        else if(GeneType.Contains("a"))
        {
            Debug.Log("找到a");
            int indexa = GeneType.IndexOf("a");
            string Temp = string.Concat(GeneType[indexa],GeneType[indexa+1]);
            GeneType = GeneType.Remove(indexa, 2);
            Debug.Log("移除原基因" + GeneType);
            GeneType = GeneType.Insert(0,Temp);
        }
        if(GeneType.Contains("C"))
        {
            Debug.Log("找到C");
            int indexC = GeneType.IndexOf("C");
            string Temp = string.Concat(GeneType[indexC],GeneType[indexC+1]);
            GeneType = GeneType.Remove(indexC, 2);
            Debug.Log("移除原基因" + GeneType);
            GeneType = GeneType + Temp;
        }
        else if(GeneType.Contains("c"))
        {
            Debug.Log("找到c");
            int indexc = GeneType.IndexOf("c");
            string Temp = string.Concat(GeneType[indexc],GeneType[indexc+1]);
            GeneType = GeneType.Remove(indexc, 2);
            Debug.Log("移除原基因" + GeneType);
            GeneType = GeneType + Temp;
        }
        return GeneType;
    }
    // 配种函数
    public string Mating(string Winner)
    {
        // 胜者替换基因
        if(Winner == "P1")
        {
            if(!P1GeneType.Contains(curFightDNA_P2.ToLower()[0]) && !P1GeneType.Contains(curFightDNA_P2.ToUpper()[0]))
            {
                P1GeneType += curFightDNA_P2;
                P1GeneType = GeneSort(P1GeneType);
            }
            else
            {
                // Debug.Log(string.Concat(P1GeneType[P2FightIndex],P1GeneType[P2FightIndex+1]));
                AfterGene = Hybridration.GeneHybridAlgorithm(string.Concat(P1GeneType[P2FightIndex],P1GeneType[P2FightIndex+1]), GlobalManager.P2FightDNA);
                AfterGene = Mutation(AfterGene);
                Debug.Log("配种结果" + AfterGene);
                P1GeneType = P1GeneType.Remove(P2FightIndex, 2);
                P1GeneType = P1GeneType.Insert(P2FightIndex,AfterGene);
            }
            
            
            return P1GeneType;
        }
        else
        {   
            if(!P2GeneType.Contains(curFightDNA_P1.ToLower()[0]) && !P2GeneType.Contains(curFightDNA_P1.ToUpper()[0]))
            {
                P2GeneType += curFightDNA_P1;
                P1GeneType = GeneSort(P1GeneType);
            }
            AfterGene = Hybridration.GeneHybridAlgorithm(string.Concat(P2GeneType[P1FightIndex],P2GeneType[P1FightIndex+1]), GlobalManager.P1FightDNA);            
            AfterGene = Mutation(AfterGene);
            P2GeneType = P2GeneType.Remove(P1FightIndex, 2);
            P2GeneType = P2GeneType.Insert(P1FightIndex,AfterGene);

            return P2GeneType;
        }
    }
    // 突变函数
    string Mutation(string AfterGene)
    {
        int Probability = Random.Range(0,100);
        // 突变概率写死0.1
        
        if(Probability < 10)
        {
            // 发生基因突变
            // 动画 or 提示
            if(Probability > 50)
            {
                // 判断大小写
                if((int)AfterGene[0] >= 65 && (int)AfterGene[0] < 97) 
                {
                    // 大写转小写
                    AfterGene.ToLower();
                }
                else
                {
                    // 小写转大写
                    AfterGene.ToUpper();
                }
            }
        }
        return AfterGene;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(GeneSort("aaCc"));
        // Debug.Log("aabbDc"[^1]);
        Debug.Log(P1GeneType);
        Debug.Log(P2GeneType);
        
        
        P1FightIndex = P1GeneType.ToLower().IndexOf(curFightDNA_P1.ToLower()[0]);
        P2FightIndex = P2GeneType.ToLower().IndexOf(curFightDNA_P2.ToLower()[0]);
        Debug.Log(P1FightIndex);
        Debug.Log(P2FightIndex);

        if(Winner == "P1")
        {
            // GlobalManager.P1CurDNA = new List<char>(Mating(Winner).ToCharArray());
            GlobalManager.FreeMateP1 += 1;
        }
        else
        {
            // GlobalManager.P2CurDNA = new List<char>(Mating(Winner).ToCharArray());
            GlobalManager.FreeMateP2 += 1;
        }
        
        // Debug.Log(P1GeneType[P2FightIndex]+P1GeneType[P2FightIndex+1]);
        
        
        
        
        // Debug.Log(P2GeneType);
        Debug.Log(string.Join("", GlobalManager.P1CurDNA));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
