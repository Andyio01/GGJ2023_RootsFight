using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseFightDNA : MonoBehaviour {
    //流程控制
    private bool is1PChooseABC = true;
    private bool is1PChooseAa = false;
    private bool is2PChooseABC = true;
    private bool is2PChooseAa = false;
    //UI控制
    public Image image1PA;
    public Image image2PA;
    public Image image1PB;
    public Image image2PB;
    public Image image1PC;
    public Image image2PC;
    public Image text1P;
    public Image text2P;

    public AudioSource clickAudio;

    private void Update() {
        if (is1PChooseABC) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                //切换阶段
                is1PChooseABC = false;
                is1PChooseAa = true;
                //UI切换
                image1PA.enabled = false;
                image1PB.enabled = false;
                image1PC.enabled = false;
                text1P.enabled = true;
                //登记信息
                GlobalManager.P1FightDNA = "AA";
                clickAudio.Play();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                //切换阶段
                is1PChooseABC = false;
                is1PChooseAa = true;
                //UI切换
                image1PA.enabled = false;
                image1PB.enabled = false;
                image1PC.enabled = false;
                text1P.enabled = true;
                //登记信息
                GlobalManager.P1FightDNA = "BB";
                clickAudio.Play();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                //切换阶段
                is1PChooseABC = false;
                is1PChooseAa = true;
                //UI切换
                image1PA.enabled = false;
                image1PB.enabled = false;
                image1PC.enabled = false;
                text1P.enabled = true;
                //登记信息
                GlobalManager.P1FightDNA = "CC";
                clickAudio.Play();
            }
        } else if (is1PChooseAa) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                text1P.enabled = false;
                //登记信息//不用变
                is1PChooseAa = false;
                clickAudio.Play();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                text1P.enabled = false;
                //登记信息
                GlobalManager.P1FightDNA = GlobalManager.P1FightDNA.ToLower();
                is1PChooseAa = false;
                clickAudio.Play();
            }
        }

        if (is2PChooseABC) {
            if (Input.GetKeyDown(KeyCode.Keypad1)) {
                //切换阶段
                is2PChooseABC = false;
                is2PChooseAa = true;
                //UI切换
                image2PA.enabled = false;
                image2PB.enabled = false;
                image2PC.enabled = false;
                text2P.enabled = true;
                //登记信息
                GlobalManager.P2FightDNA = "AA";
                clickAudio.Play();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2)) {
                //切换阶段
                is2PChooseABC = false;
                is2PChooseAa = true;
                //UI切换
                image2PA.enabled = false;
                image2PB.enabled = false;
                image2PC.enabled = false;
                text2P.enabled = true;
                //登记信息
                GlobalManager.P2FightDNA = "BB";
                clickAudio.Play();
            }
            if (Input.GetKeyDown(KeyCode.Keypad3)) {
                //切换阶段
                is2PChooseABC = false;
                is2PChooseAa = true;
                //UI切换
                image2PA.enabled = false;
                image2PB.enabled = false;
                image2PC.enabled = false;
                text2P.enabled = true;
                //登记信息
                GlobalManager.P2FightDNA = "CC";
                clickAudio.Play();
            }
        } else if (is2PChooseAa) {
            if (Input.GetKeyDown(KeyCode.Keypad1)) {
                text2P.enabled = false;
                //登记信息//不用变
                is2PChooseAa = false;
                clickAudio.Play();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2)) {
                text2P.enabled = false;
                //登记信息
                GlobalManager.P2FightDNA = GlobalManager.P2FightDNA.ToLower();
                is2PChooseAa = false;
                clickAudio.Play();
            }
        }

        if (!(is1PChooseABC || is1PChooseAa || is2PChooseABC || is2PChooseAa)) {
            print(GlobalManager.P1FightDNA);
            print(GlobalManager.P2FightDNA);
            switch (GlobalManager.P1FightDNA) {
                case "AA":
                case "Aa":
                case "aA":
                case "aa": 
                    GlobalManager.P1CurDNA[0] = GlobalManager.P1FightDNA[0];
                    GlobalManager.P1CurDNA[1] = GlobalManager.P1FightDNA[1];
                    break;  
                case "BB":
                case "Bb":
                case "bB":
                case "bb": 
                    GlobalManager.P1CurDNA[2] = GlobalManager.P1FightDNA[0];
                    GlobalManager.P1CurDNA[3] = GlobalManager.P1FightDNA[1];
                    break;  
                case "CC":
                case "Cc":
                case "cC":
                case "cc": 
                    GlobalManager.P1CurDNA[4] = GlobalManager.P1FightDNA[0];
                    GlobalManager.P1CurDNA[5] = GlobalManager.P1FightDNA[1];
                    break;  
            }
            switch (GlobalManager.P2FightDNA) {
                case "AA":
                case "Aa":
                case "aA":
                case "aa": 
                    GlobalManager.P2CurDNA[0] = GlobalManager.P2FightDNA[0];
                    GlobalManager.P2CurDNA[1] = GlobalManager.P2FightDNA[1];
                    break;  
                case "BB":
                case "Bb":
                case "bB":
                case "bb": 
                    GlobalManager.P2CurDNA[2] = GlobalManager.P2FightDNA[0];
                    GlobalManager.P2CurDNA[3] = GlobalManager.P2FightDNA[1];
                    break;  
                case "CC":
                case "Cc":
                case "cC":
                case "cc": 
                    GlobalManager.P2CurDNA[4] = GlobalManager.P2FightDNA[0];
                    GlobalManager.P2CurDNA[5] = GlobalManager.P2FightDNA[1];
                    break;  
            }

            //说明双方都已选择完毕，切换下一个场景
            if (GlobalManager.RoundCount == 0) {
                SceneManager.LoadScene("Act");
            } else {
                SceneManager.LoadScene("007_PredictSettlement");
            }
        }
    }
}