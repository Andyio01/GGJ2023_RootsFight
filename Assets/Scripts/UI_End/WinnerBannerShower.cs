using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerBannerShower : MonoBehaviour {
    public GameObject player1Banner;
    public GameObject player2Banner;

   // Start is called before the first frame update
    void Start() {
        if (GlobalManager.FinalWinner == "P1") {
            player1Banner.SetActive(true);
            player2Banner.SetActive(false);
        } else {
            player1Banner.SetActive(false);
            player2Banner.SetActive(true);
        }
    }
}
