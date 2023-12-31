using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BattleSceneMgr : MonoBehaviour {
    public CountDown cd;
    // [FormerlySerializedAs("audio")] public AudioSource battleAudio;
    [SerializeField] private Image player1Hp;
    [SerializeField] private Image player2Hp;
    [SerializeField] private GameObject topStatusBanner;
    [SerializeField] private GameObject gameSetBanner;
    private PlayerController player1;
    private PlayerController player2;

    // Start is called before the first frame update
    void Start() {
        player1 = GameObject.FindWithTag("Player1").GetComponent<PlayerController>();
        player2 = GameObject.FindWithTag("Player2").GetComponent<PlayerController>();

        topStatusBanner.SetActive(true);
        gameSetBanner.SetActive(false);
        
        Time.timeScale = 0;
        StartCoroutine(StartBattle());
    }

    IEnumerator StartBattle() {
        yield return new WaitForSecondsRealtime(2f);
        cd.enabled = true;
        Time.timeScale = 1;
        // battleAudio.Play();
        ++GlobalManager.RoundCount;
    }

    // Update is called once per frame
    void Update() {
        player1Hp.fillAmount = player1.curHp / player1.maxHp;
        player2Hp.fillAmount = player2.curHp / player2.maxHp;

        if (player1.curHp <= 0 || player2.curHp <= 0 || cd.second <= 0) {
            StartCoroutine(WinnerCheck());
        }
    }

    private void OnDestroy() {
        StopAllCoroutines();
    }

    private IEnumerator WinnerCheck() {
        Time.timeScale = 0.2f;
        topStatusBanner.SetActive(false);
        gameSetBanner.SetActive(true);
        if (player1.curHp == player2.curHp) GlobalManager.Winner = (Random.Range(0, 100) > 50) ? "P1" : "P2";
        GlobalManager.Winner = player1.curHp > player2.curHp ? "P1" : "P2";
        // battleAudio.Pause();

        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1;
        SceneManager.LoadScene("006_BattleSettlement 1");
    }
}