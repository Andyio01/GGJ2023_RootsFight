using System.Collections.Generic;
using System.Text;
using Player;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Utils;

static public class GlobalManager {
    // this is an example to store data
    private static int n = 0;

    public static int RoundCount;
    public static List<char> _1P_rootDNA = new List<char>(3);
    public static List<char> _2P_rootDNA = new List<char>(3);
    public static List<char> rootDNA = new List<char>(6);

    public static string rootDNA_str {
        get {
            var sb = new StringBuilder();
            foreach (var c in rootDNA) sb.Append(c);
            return sb.ToString();
        }
    }

    public static List<char> P1CurDNA = new List<char>(6) { 'a', 'a', 'b', 'b', 'c', 'c' };
    public static List<char> P2CurDNA = new List<char>(6) { 'a', 'a', 'b', 'b', 'c', 'c' };

    public static string P1CurDNA_str {
        get {
            var sb = new StringBuilder();
            foreach (var c in P1CurDNA) sb.Append(c);
            return sb.ToString();
        }
    }

    public static string P2CurDNA_str {
        get {
            var sb = new StringBuilder();
            foreach (var c in P2CurDNA) sb.Append(c);
            return sb.ToString();
        }
    }

    public static string P1PredictDNA = "AA";
    public static string P2PredictDNA = "BB";
    public static string P1FightDNA = "BB";
    public static string P2FightDNA = "CC";
    public static string Winner = "P1";
    public static int FreeMateP1 = 0;
    public static int FreeMateP2 = 0;

    public static PredictResult P1PredictResult;
    public static PredictResult P2PredictResult;

    public static string FinalWinner = "";

    public static GameObject LoadGlobalPrefabObject() {
        GameObject checkGb = GameObject.FindGameObjectWithTag("GlobalObject");
        if (checkGb == null) {
            // GameObject gb = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/GlobalObject.prefab", typeof(GameObject)) as GameObject;
            var gb = ResMgr.GetInstance().Load<GameObject>("GlobalObject");
            return gb;
        }
        return null;
    }

    // this is an example to set data
    public static void SetN(int v) {
        n = v;
    }

    // this is an example to get data
    public static int GetN() {
        return n;
    }
}