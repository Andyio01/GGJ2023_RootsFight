using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
  private void Awake()
  {
    GameObject gb = GlobalManager.LoadGlobalPrefabObject(); 
    if (gb != null)
    {
      Instantiate(gb);
    }
  }

  // Start is called before the first frame update
  void Start()
  {
    Button btn1 = GameObject.Find("RoundBattle").GetComponent<Button>();
    btn1.onClick.AddListener(delegate { OnBattleButtonPress(); });

    Button btn2 = GameObject.Find("gameOver").GetComponent<Button>();
    btn2.onClick.AddListener(delegate { OnGameOverButtonPress(); });
    
  }

  public void OnBattleButtonPress()
  {
    Debug.Log("on press: 003_RoundX");
    SceneManager.LoadScene("003_RoundX");
    GlobalManager.SetN(GlobalManager.GetN() + 1);
    Debug.Log("GlobalManager n = " + GlobalManager.GetN());
  }

  public void OnGameOverButtonPress()
  {
    Debug.Log("on press: 004_End");
    SceneManager.LoadScene("004_GameOver");
    GlobalManager.SetN(GlobalManager.GetN() + 1);
    Debug.Log("GlobalManager n = " + GlobalManager.GetN());  }
  
  // Update is called once per frame
  void Update()
  {

  }
}
