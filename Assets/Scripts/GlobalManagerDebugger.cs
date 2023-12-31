using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManagerDebugger : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {
        Debug.Log($"Root: {GlobalManager.rootDNA_str}");
        Debug.Log($"P1CurDNA: {GlobalManager.P1CurDNA_str}");
        Debug.Log($"P2CurDNA: {GlobalManager.P2CurDNA_str}");
        Debug.Log("RoundCount: " + GlobalManager.RoundCount);
        Debug.Log($"P1Fight: {GlobalManager.P1FightDNA}");
        Debug.Log($"P2Fight: {GlobalManager.P2FightDNA}");
        // if (GlobalManager.RoundCount == 1) {
        //     // GlobalManager.P1CurDNA_str = "AA";
        //     // GlobalManager.P2CurDNA_str = "AA";
        //     GlobalManager.FreeMateP1 = 1;
        //     GlobalManager.FreeMateP2 = 0;
        // }
        // if (GlobalManager.RoundCount == 2) {
        //     // GlobalManager.P1CurDNA_str = "AAbb";
        //     // GlobalManager.P2CurDNA_str = "AABb";
        //     GlobalManager.FreeMateP1 = 1;
        //     GlobalManager.FreeMateP2 = 1;
        // }
        // if (GlobalManager.RoundCount == 3) {
        //     // GlobalManager.P1CurDNA_str = "AAbbCC";
        //     // GlobalManager.P2CurDNA_str = "AABbCc";
        //     GlobalManager.FreeMateP1 = 1;
        //     GlobalManager.FreeMateP2 = 1;
        // }
        //
        // if (GlobalManager.RoundCount == 3 && SceneManager.GetActiveScene().name == "005_Predict") {
        //     GlobalManager.FinalWinner = "P1";
        //     SceneManager.LoadScene("End");
        // }
    }


}